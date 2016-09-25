using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Linq;

namespace Fangame_Manager
{
    class IOHelper
    {
        // First value is time, second deaths
        public static int[] GetGameTimeAndDeath(string filePath)
        {
            string dir = filePath;
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

            // Search the save files. No support for milliseconds now
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

            // Find the right save or prompt for it
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
                // Shouldn't ever be reached
                return null;
            }
            else if (amountOfRight > 1)
            {
                // TODO: prompt to choose
                int[] returnvalues = new int[2];
                returnvalues[0] = 0;
                returnvalues[1] = 0;
                return returnvalues;
            }
            // No savefiles found. Create a dummy one
            else
            {
                int[] returnvalues = new int[2];
                returnvalues[0] = 0;
                returnvalues[1] = 0;
                return returnvalues;
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
                foreach (string file in folder)
                {
                    string targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }
            }
            Directory.Delete(source, true);
        }


        public static void MoveArchiveAway(string filename)
        {
            string dir = Path.Combine(Directory.GetCurrentDirectory(), Properties.Settings.Default.foldernameForArchives);
            Directory.CreateDirectory(dir);
            string onlyFilename = Path.GetFileName(filename);
            if (File.Exists(Path.Combine(dir, onlyFilename)) == false)
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

        public static string getDateCompleted(string filePath)
        {
            return new FileInfo(filePath).LastAccessTime.ToShortDateString();
        }

        public static void UnpackNewgames()
        {
            // Search archive files
            string currdir = Directory.GetCurrentDirectory();
            List<string> archiveList = Directory.GetFiles(currdir).ToList(); ;
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

            // Extract them
            int endProg = archiveList.Count + 1;
            int curProgress = 1;

            foreach (string file in archiveList)
            {
                curProgress++;
                string destinationFolder = file.Remove(file.LastIndexOf('.'));
                bool extractSuccess = ExtractArchive(file, destinationFolder);
                if(extractSuccess == false)
                {
                    MessageBox.Show("Failed to extract: " + file);
                    continue;
                }
                bool cleanSuccess = CleanExtractedDir(destinationFolder);
                if(cleanSuccess == false)
                {
                    MessageBox.Show("Failed to cleanup: " + destinationFolder);
                    continue;
                }
                if(extractSuccess && cleanSuccess)
                {
                    if (Properties.Settings.Default.deleteArchivesOnExtract)
                        File.Delete(file);
                    else
                        IOHelper.MoveArchiveAway(file);
                }
            }
        }


        // Returns true if extract was completed, false if not
        private static bool CleanExtractedDir(string destinationFolder)
        {
            string[] filenames = Directory.GetFiles(destinationFolder, "*.exe", SearchOption.AllDirectories);

            // Delete the game from old games
            if (filenames.Length > 1)
            {
                // TODO: select the right .exe file
            }
            else if (filenames.Length == 1)
            {
                GameManager.Instance.deleteFromSettings(filenames[0]);
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
                        IOHelper.MoveDirectory(dir, destinationFolder);
                        return true;
                    }

                    // The 2 directories have different names. Make a new one to move into
                    string dirToMoveInto = Path.Combine(Directory.GetCurrentDirectory(), newdirname);
                    if (Directory.Exists(dirToMoveInto))
                    {
                        MessageBoxResult result = MessageBox.Show("A folder with the name: " + dirToMoveInto + " already exists. Continue?", "Folder Already Exists", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.Cancel)
                        {
                            Directory.Delete(destinationFolder, true);
                            return false;
                        }
                    }
                    MoveDirectory(dir, dirToMoveInto);
                    // destinationFolder is now empty, delete it
                    Directory.Delete(destinationFolder);
                }
            }
            return true;
        }


        // Returns true if extract was completed, false if not
        private static bool ExtractArchive(string filename, string destinationFolder)
        {
            string fileExtension = Path.GetExtension(filename);

            if (Directory.Exists(destinationFolder))
            {
                MessageBoxResult result = MessageBox.Show("A folder with the name: " + destinationFolder + " already exists. Continue?", "Folder Already Exists", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel) return false;
            }

            // Zip doesn't need extract program
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
            return true;
        }

        private static bool FindExtractProgram()
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
    }
}
