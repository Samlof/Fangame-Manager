using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Compression;

namespace Fangame_Manager
{
    public partial class MainForm : Form
    {
        class MySettings : AppSettings<MySettings>
        {
            public List<String> exenames = new List<string>();
            public List<String> recentGames = new List<String>();
            public List<String> newGames = new List<String>();
            public List<String> hiddenFilenames = new List<string>();
        }



        MySettings settings;
        Dictionary<string, string> gamenameToFilename = new Dictionary<string, string>();


        private static MainForm instance;
        Process runningGame;
        Thread statsFormThread;
        Thread waitFormThread;


        public static MainForm Instance
        {
            get { return instance; }
        }



        public MainForm()
        {
            InitializeComponent();
            CreateHandle();
            instance = this;

            runningGame = new Process();
            runningGame.EnableRaisingEvents = true;
            runningGame.Exited += new EventHandler(runningGame_exited);


            LoadOptions();
            if (Properties.Settings.Default.startAutoScriptOnAppStart)
                loadAutoStartScript();
            if (Properties.Settings.Default.extractArchivesOnStartup)
                UnpackNewgames();
            if (Properties.Settings.Default.openStatsOnAppStart)
                StartStatsForm();

            checkDirectoryForGames();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Properties.Settings.Default.oldWidth = Size;
            Properties.Settings.Default.oldPosition = Location;
            Properties.Settings.Default.Save();
            loadAutoEndScript();
            settings.Save();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Utility functions


        private bool CompleteGame(string gamename)
        {
            string filename = gamenameToFilename[gamename];
            string dir = Path.GetDirectoryName(filename);
            string dirName = Path.GetFileName(dir);
            string destDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Properties.Settings.Default.foldernameForCompleted + Path.DirectorySeparatorChar + dirName;
            if (Directory.Exists(destDir))
            {
                if (MessageBox.Show($"Directory \"{dirName}\" exists already in the {Properties.Settings.Default.foldernameForCompleted} folder. Replace?", "Directory Conflict", MessageBoxButtons.OKCancel)
                    == DialogResult.Cancel)
                    return false;
            }

            if (Properties.Settings.Default.driveSheetInsertOn)
                AddToGoogleSheet(gamename);

            if (Properties.Settings.Default.moveCompletedGamesAway)
            {
                MoveDirectory(dir, destDir);
                recentGamesListbox.Items.Remove((object)gamename);
                newGamesListbox.Items.Remove((object)gamename);
                fangamesListbox.Items.Remove((object)gamename);
            }
            return true;
        }

        private delegate void UpdateProgressLabelDelegate(string status);
        public void UpdateProgressLabel(string status)
        {
            if (WaitForm.Instance.InvokeRequired)
            {
                this.Invoke(new UpdateProgressLabelDelegate(WaitForm.Instance.updateProgress), status);
            }
            else {
                WaitForm.Instance.updateProgress(status);
            }
        }

        private void CloseWaitForm()
        {
            if (!waitFormThread.IsAlive) return;
            if (WaitForm.Instance.InvokeRequired)
            {
                this.Invoke(new closeFormDelegate(WaitForm.Instance.Close));
            }
            else
            {
                WaitForm.Instance.Close();
            }
        }

        public void addCurrentCompletedToSheet()
        {
            string dirsPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Properties.Settings.Default.foldernameForCompleted;
            string[] dirs = Directory.GetDirectories(dirsPath);

            WaitForm wf = new WaitForm("Please wait while pushing data");
            waitFormThread = new Thread(() => wf.ShowDialog());
            waitFormThread.Start();

            int endProg = dirs.Length + 1;
            int curProgress = 1;
            UpdateProgressLabel($"{curProgress}/{endProg}");

            foreach (string dir in dirs)
            {
                curProgress++;
                string[] filenames = Directory.GetFiles(dir, "*.exe");
                if (filenames.Length > 1)
                {
                    // TODO: select the right .exe file
                }
                else if (filenames.Length == 0)
                {
                    continue;
                }
                string filename = filenames[0];
                string exeName = Path.GetFileNameWithoutExtension(filename);
                string gamename = Path.GetFileName(dir);
                if (exeName.Length > gamename.Length)
                    gamename = exeName;
                gamenameToFilename.Add(gamename, filename);
                AddToGoogleSheet(gamename, false);
                UpdateProgressLabel($"{curProgress}/{endProg}");
            }

            CloseWaitForm();
        }
        

        private void AddToGoogleSheet(string gamename, bool askRating = true)
        {
            int[] timeAndDeath = GetGameTimeAndDeath(gamename);
            if (timeAndDeath == null) return;

            // Time parameter
            string timeString = "0";
            int time = timeAndDeath[0];
            if (time > 0)
            {
                int hrs = time / 3600;
                int mins = (time % 3600) / 60;
                int secs = time % 60;
                timeString = $"{timeIntoStringPart(hrs)}:{timeIntoStringPart(mins)}:{timeIntoStringPart(secs)}";
            }

            int deaths = timeAndDeath[1];

            int rating = 0;
            if (askRating)
                rating = GetRating(gamename);

            string spreadsheetname = Properties.Settings.Default.spreadSheetnameForGoogle;
            int startRow = (int)Properties.Settings.Default.startRowForSheet;
            int startColumn = (int)Properties.Settings.Default.startColumnForSheet;
            FileInfo fi = new FileInfo(gamenameToFilename[gamename]);
            string dateC = getDateCompleted(fi);

            bool complete = GoogleSheetsInserter.run(timeString, deaths, rating, gamename, spreadsheetname, startRow, startColumn, dateC);
            if (!complete)
            {
                if (MessageBox.Show("Error happened while trying to send the command", "Error!", MessageBoxButtons.RetryCancel)
                    == DialogResult.Retry)
                    AddToGoogleSheet(gamename);
            }
        }

        private string getDateCompleted(FileSystemInfo fsi)
        {
            DateTime time = fsi.LastAccessTime;
            return time.ToShortDateString();
        }
        private int GetRating(string gamename)
        {
            PromptForRating prompt = new PromptForRating(gamename);
            DialogResult result = prompt.ShowDialog();
            int rating = 0;
            if (result == DialogResult.OK)
            {
                rating = 1;
            }
            else if (result == DialogResult.Cancel)
            {
                rating = 2;
            }
            else if (result == DialogResult.Abort)
            {
                rating = 3;
            }
            else if (result == DialogResult.Retry)
            {
                rating = 4;
            }
            else if (result == DialogResult.Ignore)
            {
                rating = 5;
            }
            return rating;
        }

        private string timeIntoStringPart(int time)
        {
            if (time < 10)
            {
                return "0" + time.ToString();
            }
            else
            {
                return time.ToString();
            }
        }

        private int[] GetGameTimeAndDeath(string gamename)
        {
            string dir = Path.GetDirectoryName(gamenameToFilename[gamename]);
            int[] times = new int[3];
            int[] deaths = new int[3];
            bool[] rightSave = new bool[3];
            int amountOfRight = 0;
            for (int i = 0; i < 3; i++)
            {
                times[i] = 0;
                deaths[i] = 0;
                rightSave[i] = false;
            }
            string[] savefile = Directory.GetFiles(dir, "DeathTime", SearchOption.AllDirectories);
            if (savefile.Length == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    using (var fs = new FileStream(savefile[0], FileMode.Open))
                    {
                        fs.Seek(i * 8, SeekOrigin.Begin);

                        deaths[i] = fs.ReadByte() * 1000000;
                        deaths[i] += fs.ReadByte() * 10000;
                        deaths[i] += fs.ReadByte() * 100;
                        deaths[i] += fs.ReadByte();

                        times[i] = fs.ReadByte() * 1000000;
                        times[i] += fs.ReadByte() * 10000;
                        times[i] += fs.ReadByte() * 100;
                        times[i] += fs.ReadByte();
                    }
                    if (times[i] > 60)
                    {
                        rightSave[i] = true;
                        amountOfRight++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    savefile = Directory.GetFiles(dir, "save" + (i + 1).ToString(), SearchOption.AllDirectories);
                    if (savefile.Length == 1)
                    {
                        using (var fs = new FileStream(savefile[0], FileMode.Open))
                        {
                            fs.Seek(10, SeekOrigin.Begin);

                            deaths[i] = fs.ReadByte() * 1000000;
                            deaths[i] += fs.ReadByte() * 10000;
                            deaths[i] += fs.ReadByte() * 100;
                            deaths[i] += fs.ReadByte();

                            times[i] = fs.ReadByte() * 1000000;
                            times[i] += fs.ReadByte() * 10000;
                            times[i] += fs.ReadByte() * 100;
                            times[i] += fs.ReadByte();
                        }
                        if (times[i] > 60)
                        {
                            rightSave[i] = true;
                            amountOfRight++;
                        }
                    }
                }
            }
            if (amountOfRight == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (rightSave[i])
                    {
                        int[] returnvalues = new int[2];
                        returnvalues[0] = times[i];
                        returnvalues[1] = deaths[i];
                        return returnvalues;
                    }
                }
                return null;
            }
            else if (amountOfRight > 1)
            {
                PromptForSavefile prompt = new PromptForSavefile(rightSave[0], rightSave[1], rightSave[2], gamename);
                DialogResult result = prompt.ShowDialog();
                int[] returnvalues = new int[2];
                if (result == DialogResult.OK)
                {
                    returnvalues[0] = times[0];
                    returnvalues[1] = deaths[0];
                }
                else if (result == DialogResult.Cancel)
                {
                    returnvalues[0] = times[1];
                    returnvalues[1] = deaths[1];
                }
                else
                {
                    returnvalues[0] = times[2];
                    returnvalues[1] = deaths[2];
                }
                return returnvalues;
            }
            else
            {
                int[] returnvalues = new int[2];
                returnvalues[0] = 0;
                returnvalues[1] = 0;
                return returnvalues;
            }
        }

        private void HideGame(string gamename)
        {
            string exeName = Path.GetFileNameWithoutExtension(gamenameToFilename[gamename]);
            if (!settings.hiddenFilenames.Contains(exeName))
            {
                settings.hiddenFilenames.Add(exeName);
            }
        }

        private void DeleteGame(string gamename)
        {
            string exeName = Path.GetFileNameWithoutExtension(gamenameToFilename[gamename]);
            settings.exenames.Remove(exeName);
            settings.recentGames.Remove(exeName);
            settings.newGames.Remove(exeName);
            settings.hiddenFilenames.Remove(exeName);
            Directory.Delete(Path.GetDirectoryName(gamenameToFilename[gamename]), true);
        }

        private void LoadOptions()
        {
            if (Properties.Settings.Default.oldWidth.Width > 300)
            {
                this.Size = Properties.Settings.Default.oldWidth;
            }
            if (Properties.Settings.Default.oldPosition.X != 0)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.oldPosition;
            }

            settings = MySettings.Load();
        }

        private delegate void closeFormDelegate();
        private void CloseStatsForm()
        {
            if (!statsFormThread.IsAlive) return;
            if (StatsForm.Instance.InvokeRequired)
            {
                this.Invoke(new closeFormDelegate(StatsForm.Instance.Close));
            }
            else
            {
                StatsForm.Instance.Close();
            }
        }

        private void runningGame_exited(object sender, EventArgs e)
        {

            this.Show();
            this.Focus();
            if (Properties.Settings.Default.hideStatsOnGameExit)
            {
                Properties.Settings.Default.statsWindowLocation = StatsForm.Instance.Location;
                CloseStatsForm();
            }
            loadAutoEndScript();

            this.Show();
            this.Focus();
        }

        private void StartGame(string gamename)
        {
            string filename = gamenameToFilename[gamename];
            runningGame.StartInfo.FileName = filename;
            runningGame.StartInfo.WorkingDirectory = Path.GetDirectoryName(filename);
            string exeName = Path.GetFileNameWithoutExtension(filename);

            // Adding or moving the game to recent games list first position
            settings.recentGames.Remove(exeName);
            settings.recentGames.Insert(0, exeName);

            // Removing from new games
            settings.newGames.Remove(exeName);
            newGamesListbox.Items.Remove(gamename);
            fangamesListbox.Items.Remove(gamename);
            if (!recentGamesListbox.Items.Contains(gamename))
                recentGamesListbox.Items.Add(gamename);

            if (Properties.Settings.Default.openStatsOnGameStart)
                StartStatsForm();
            if (Properties.Settings.Default.startAutoScriptOnGameStart)
                loadAutoStartScript();

            //this.Hide();
            runningGame.Start();
        }

        private void StartStatsForm()
        {
            if (statsFormThread != null && statsFormThread.IsAlive) return;

            StatsForm sf = new StatsForm();
            if (Properties.Settings.Default.statsWindowLocation.X != 0)
            {
                sf.StartPosition = FormStartPosition.Manual;
                sf.Location = Properties.Settings.Default.statsWindowLocation;
            }
            statsFormThread = new Thread(() => sf.ShowDialog());
            statsFormThread.Start();
        }

        public bool FindExtractProgram()
        {
            if (File.Exists(Properties.Settings.Default.extractProgramFilename))
            {
                return true;
            }
            else if (File.Exists(@"C:\Program Files\7-Zip\7z.exe"))
            {
                Properties.Settings.Default.extractProgramFilename = @"C:\Program Files\7-Zip\7z.exe";
                return true;
            }
            else if (File.Exists(@"C:\Program Files\WinRAR\unrar.exe"))
            {
                Properties.Settings.Default.extractProgramFilename = @"C:\Program Files\WinRAR\unrar.exe";
                return true;
            }
            else
            {
                Properties.Settings.Default.extractProgramFilename = "Not found!";
                return false;
            }
        }

        private void UnpackNewgames()
        {
            string currdir = Directory.GetCurrentDirectory();
            string[] archives = Directory.GetFiles(currdir);
            List<string> archiveList = archives.ToList<string>();
            for (int i = 0; i < archiveList.Count; i++)
            {
                string file = archiveList[i];
                if (file.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".rar", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".7z", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                else
                {
                    archiveList.RemoveAt(i);
                    i--;
                }
            }
            if (archiveList.Count == 0)
            {
                return;
            }
            WaitForm wf = new WaitForm("Please wait while extracting");
            waitFormThread = new Thread(() => wf.ShowDialog());
            waitFormThread.Start();

            int endProg = archiveList.Count + 1;
            int curProgress = 1;
            UpdateProgressLabel($"{curProgress}/{endProg}");

            foreach (string file in archiveList)
            {
                curProgress++;
                if (ExtractArchive(file))
                {
                    if (Properties.Settings.Default.deleteArchivesOnExtract)
                        File.Delete(file);
                    else
                        MoveArchiveAway(file);
                }

                UpdateProgressLabel($"{curProgress}/{endProg}");

            }
            CloseWaitForm();
        }

        // Returns true if extract was completed, false if not
        private bool ExtractArchive(string filename)
        {
            string destinationFolder = filename.Remove(filename.LastIndexOf('.'));
            string fileExtension = Path.GetExtension(filename);

            if (Directory.Exists(destinationFolder))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show("A folder with the name: " + destinationFolder + " already exists. Continue?", "Folder Already Exists", buttons);
                if (result == DialogResult.Cancel) return false;
            }

            if (fileExtension == ".zip")
            {
                using (ZipArchive archive = ZipFile.OpenRead(filename))
                {
                    foreach (ZipArchiveEntry file in archive.Entries)
                    {
                        string completeFileName = Path.Combine(destinationFolder, file.FullName);
                        string directory = Path.GetDirectoryName(completeFileName);

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);

                        if (file.Name != "")
                            file.ExtractToFile(completeFileName, true);
                    }
                }
            }
            else if (FindExtractProgram())
            {
                string extractProgram = Properties.Settings.Default.extractProgramFilename;
                if (extractProgram.EndsWith("7z.exe", StringComparison.OrdinalIgnoreCase))
                {
                    Process p = new Process();
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = extractProgram;
                    p.StartInfo.Arguments = string.Format(@"x ""{0}"" -o""{1}"" -y", filename, destinationFolder);
                    p.Start();
                    p.WaitForExit();
                }
                else if (extractProgram.EndsWith("unrar.exe", StringComparison.OrdinalIgnoreCase))
                {
                    Process p = new Process();
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = extractProgram;
                    p.StartInfo.Arguments = string.Format(@"x -Y ""{0}"" *.* ""{1}\""", filename, destinationFolder);
                    p.Start();
                    p.WaitForExit();
                }
            }
            else
            {
                MessageBox.Show("Couldn't find 7zip or winrar to unpack " + Path.GetFileName(filename));
                return false;
            }


            // Delete the game from old games
            string[] filenames = Directory.GetFiles(destinationFolder, "*.exe", SearchOption.AllDirectories);
            if (filenames.Length > 1)
            {
                // TODO: select the right .exe file
            }
            else if (filenames.Length == 1)
            {
                string exeFullpath = filenames[0];
                string exeName = Path.GetFileNameWithoutExtension(exeFullpath);
                settings.exenames.Remove(exeName);
                settings.recentGames.Remove(exeName);
            }

            // If there is only a single directory inside the extracted file
            string[] dirs = Directory.GetDirectories(destinationFolder);
            if (dirs.Length == 1)
            {
                // If there are no files inside, only the directory
                string[] files = Directory.GetFiles(destinationFolder);
                if (files.Length == 0)
                {

                    // If the directory has the same name as parent
                    string oldparent = Path.GetFileName(destinationFolder);
                    string dir = dirs[0];
                    string newdirname = Path.GetFileName(dir);
                    if (oldparent == newdirname)
                    {
                        MoveDirectory(dir, Directory.GetCurrentDirectory() + "\\" + newdirname);
                        return true;
                    }

                    string dirToMoveInto = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + newdirname;
                    if (Directory.Exists(dirToMoveInto) && (oldparent != newdirname))
                    {
                        DialogResult result = MessageBox.Show("A folder with the name: " + dirToMoveInto + " already exists. Continue?", "Folder Already Exists", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.Cancel)
                        {
                            Directory.Delete(destinationFolder, true);
                            return false;
                        }
                    }
                    MoveDirectory(dir, dirToMoveInto);
                    Directory.Delete(destinationFolder);
                }
            }
            return true;
        }

        private void MoveArchiveAway(string filename)
        {
            string dir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Properties.Settings.Default.foldernameForArchives;
            Directory.CreateDirectory(dir);
            string onlyFilename = Path.GetFileName(filename);
            if (!File.Exists(dir + Path.DirectorySeparatorChar + onlyFilename))
            {
                File.Move(filename, dir + Path.DirectorySeparatorChar + onlyFilename);
            }
            else
            {
                // Try to rename the file
                for (int i = 1; i < 1000; i++)
                {
                    string name = dir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filename) + $"({i})" + Path.GetExtension(filename);
                    if (!File.Exists(name))
                    {
                        File.Move(filename, name);
                        return;
                    }
                }
            }
        }
        public static void MoveDirectory(string source, string target)
        {
            var sourcePath = source.TrimEnd(Path.DirectorySeparatorChar, ' ');
            var targetPath = target.TrimEnd(Path.DirectorySeparatorChar, ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }
            }
            Directory.Delete(source, true);
        }

        private void AddDirectoryToGames(string dir)
        {
            string[] filenames = Directory.GetFiles(dir, "*.exe");
            if (filenames.Length > 1)
            {
                // TODO: select the right .exe file
            }
            else if (filenames.Length == 0)
            {
                return;
                // TODO: check subdirectories
            }
            string filename = filenames[0];
            string exeName = Path.GetFileNameWithoutExtension(filename);
            string gamename = Path.GetFileName(dir);
            if (exeName.Length > gamename.Length)
                gamename = exeName;
            // Is the game found form old games
            if (settings.exenames.Contains(exeName))
            {
                // Is it on hide list
                if (settings.hiddenFilenames.Contains(exeName))
                {
                    settings.recentGames.Remove(exeName);
                    settings.newGames.Remove(exeName);
                }
                // Is the game on recent games list
                else if (settings.recentGames.Contains(exeName))
                {
                    if (settings.recentGames.IndexOf(exeName) + 1 > Properties.Settings.Default.recentGamesMax)
                    {
                        fangamesListbox.Items.Add(gamename);
                        settings.recentGames.Remove(exeName);
                    }
                    else
                    {
                        recentGamesListbox.Items.Add(gamename);
                    }
                }
                // Is the game on new games list
                else if (settings.newGames.Contains(exeName))
                {
                    newGamesListbox.Items.Add(gamename);
                }
                else
                {
                    fangamesListbox.Items.Add(gamename);
                }
            }
            else
            {
                // New game
                settings.exenames.Add(exeName);
                settings.newGames.Add(exeName);
                newGamesListbox.Items.Add(gamename);
            }

            gamenameToFilename.Add(gamename, filename);
            allExenames.Add(exeName);
        }

        private List<string> allExenames;
        private void checkDirectoryForGames()
        {
            string currDir = Directory.GetCurrentDirectory();
            string[] directories = Directory.GetDirectories(currDir);
            allExenames = new List<string>();

            foreach (string dir in directories)
            {
                AddDirectoryToGames(dir);
            }

            for (int i = 0; i < settings.exenames.Count; i++)
            {
                string name = settings.exenames[i];
                if (!allExenames.Contains(name))
                {
                    settings.exenames.RemoveAt(i);
                    i--;
                    settings.newGames.Remove(name);
                    settings.hiddenFilenames.Remove(name);
                }
            }
        }

        private List<String> returnListboxAsListString(ListBox l)
        {
            List<String> ls = new List<string>();
            foreach (object item in l.Items)
            {
                ls.Add(item.ToString());
            }
            return ls;
        }

        private ListBox GetSelectedListBox()
        {
            if (fangamesListbox.SelectedItems.Count == 1)
            {
                return fangamesListbox;
            }
            else if (recentGamesListbox.SelectedItems.Count == 1)
            {
                return recentGamesListbox;
            }
            else if (newGamesListbox.SelectedItems.Count == 1)
            {
                return newGamesListbox;
            }
            else return null;
        }

        private void ShowOptions()
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }

        #endregion

        #region Change settings


        public bool isScriptRunning = false;
        public void loadAutoStartScript()
        {
            if (isScriptRunning) return;
            string filename = Properties.Settings.Default.startScriptFilename;
            if (!File.Exists(filename)) return;

            try
            {
                Process.Start(filename);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Start script file: " + filename + " can't be handled", "File Error!");
            }
            isScriptRunning = true;
        }

        public void loadAutoEndScript()
        {
            if (!isScriptRunning) return;
            string filename = Properties.Settings.Default.stopScriptFilename;
            if (!File.Exists(filename)) return;
            try
            {
                Process.Start(filename);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("End script file: " + filename + " can't be handled", "File Error!");
            }
            isScriptRunning = false;
        }
        #endregion

        #region Forms

        private void fangamesListbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox l = ((ListBox)sender);
            int index = l.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string gamename = l.Items[index].ToString();
                StartGame(gamename);
            }
        }

        private void quitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void recentGamesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fangamesListbox.SelectedIndexChanged -= new System.EventHandler(this.fangamesListbox_SelectedIndexChanged);
            this.newGamesListbox.SelectedIndexChanged -= new System.EventHandler(this.newGamesListbox_SelectedIndexChanged);
            fangamesListbox.ClearSelected();
            newGamesListbox.ClearSelected();
            this.newGamesListbox.SelectedIndexChanged += new System.EventHandler(this.newGamesListbox_SelectedIndexChanged);
            this.fangamesListbox.SelectedIndexChanged += new System.EventHandler(this.fangamesListbox_SelectedIndexChanged);
        }

        private void newGamesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fangamesListbox.SelectedIndexChanged -= new System.EventHandler(this.fangamesListbox_SelectedIndexChanged);
            this.recentGamesListbox.SelectedIndexChanged -= new System.EventHandler(this.recentGamesListbox_SelectedIndexChanged);
            fangamesListbox.ClearSelected();
            recentGamesListbox.ClearSelected();
            this.recentGamesListbox.SelectedIndexChanged += new System.EventHandler(this.recentGamesListbox_SelectedIndexChanged);
            this.fangamesListbox.SelectedIndexChanged += new System.EventHandler(this.fangamesListbox_SelectedIndexChanged);
        }

        private void fangamesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.recentGamesListbox.SelectedIndexChanged -= new System.EventHandler(this.recentGamesListbox_SelectedIndexChanged);
            this.newGamesListbox.SelectedIndexChanged -= new System.EventHandler(this.newGamesListbox_SelectedIndexChanged);
            recentGamesListbox.ClearSelected();
            newGamesListbox.ClearSelected();
            this.newGamesListbox.SelectedIndexChanged += new System.EventHandler(this.newGamesListbox_SelectedIndexChanged);
            this.recentGamesListbox.SelectedIndexChanged += new System.EventHandler(this.recentGamesListbox_SelectedIndexChanged);
        }


        private void openStatsButton_Click(object sender, EventArgs e)
        {
            StartStatsForm();
        }

        private void completeGameButton_Click(object sender, EventArgs e)
        {
            ListBox listBoxtoCheck = GetSelectedListBox();
            if (listBoxtoCheck == null) return;
            string gamename = listBoxtoCheck.SelectedItem.ToString();
            if (CompleteGame(gamename))
                listBoxtoCheck.Items.Remove(gamename);
        }

        private void hideGameButton_Click(object sender, EventArgs e)
        {
            ListBox listBoxtoCheck = GetSelectedListBox();
            if (listBoxtoCheck == null) return;
            string gamename = listBoxtoCheck.SelectedItem.ToString();
            HideGame(gamename);
            listBoxtoCheck.Items.Remove(gamename);
        }

        private void deleteGameButton_Click(object sender, EventArgs e)
        {
            ListBox listBoxtoCheck = GetSelectedListBox();
            if (listBoxtoCheck == null) return;
            string gamename = listBoxtoCheck.SelectedItem.ToString();
            if (MessageBox.Show($"Are you sure you want to delete: {Path.GetDirectoryName(gamenameToFilename[gamename])}?", "Confirmation", MessageBoxButtons.OKCancel)
                == DialogResult.Cancel)
                return;
            DeleteGame(gamename);
            listBoxtoCheck.Items.Remove(gamename);
        }

        #endregion
    }
}
