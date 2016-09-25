using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace Fangame_Manager
{
    class GameManager
    {

        // TODO: Change into HashSets for better performance
        class MySettings : AppSettingsJSON<MySettings>
        {
            public List<String> gameNames = new List<string>();
            public List<String> recentGames = new List<String>();
            public List<String> newGames = new List<String>();
            public List<String> hiddenGames = new List<string>();
        }

        MySettings settings;
        Dictionary<string, string> gamenameToFilename = new Dictionary<string, string>();
        Process runningGame;

        public List<string> RecentGames { get { return settings.recentGames; } }
        public List<string> NewGames { get { return settings.newGames; } }
        private List<string> _games;
        public List<string> Games { get { return settings.gameNames; } protected set { settings.gameNames = value; } }

        public static GameManager Instance { get; set; }
        public GameManager()
        {
            if (Instance != null)
            {
                MessageBox.Show("Error! Multiple GameManagers!");
                return;
            }
            Instance = this;
            LoadSettings();

            runningGame = new Process();
            runningGame.EnableRaisingEvents = true;
            runningGame.Exited += new EventHandler(runningGame_exited);
        }

        public void finishGameLists()
        {
            foreach (string game in settings.gameNames)
            {
                if (settings.recentGames.Contains(game) == false && settings.newGames.Contains(game) == false && settings.hiddenGames.Contains(game) == false)
                {
                    Games.Add(game);
                }
            }
        }

        /// <returns>True is succesful, false if file wasn't moved away</returns>
        public void CompleteGame(string gamename)
        {
            string filename = gamenameToFilename[gamename];
            string dir = Path.GetDirectoryName(filename);
            string dirName = Path.GetFileName(dir);
            string destDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Properties.Settings.Default.foldernameForCompleted + Path.DirectorySeparatorChar + dirName;


            if (Properties.Settings.Default.driveSheetInsertOn)
                AddToGoogleSheet(gamename);

            if (Properties.Settings.Default.moveCompletedGamesAway)
            {
                if (Directory.Exists(destDir))
                {
                    MessageBoxResult result = MessageBox.Show($"Directory \"{dirName}\" exists already in the {Properties.Settings.Default.foldernameForCompleted} folder. Replace?", "Directory Conflict", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.Cancel) return;
                }
                IOHelper.MoveDirectory(dir, destDir);
                deleteFromSettings(gamename);
            }
        }

        public void addCurrentCompletedToSheet()
        {

            // Get directories from completed
            string dirsPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Properties.Settings.Default.foldernameForCompleted;
            string[] dirs = Directory.GetDirectories(dirsPath);


            int endProg = dirs.Length + 1;
            int curProgress = 1;

            foreach (string dir in dirs)
            {
                curProgress++;

                // get name
                string[] filenames = Directory.GetFiles(dir, "*.exe");
                if (filenames.Length > 1)
                {
                    // TODO: choose right one
                }
                else if (filenames.Length == 0)
                {
                }
                else
                {
                    string filename = filenames[0];
                    string gamename = HelperFunctions.getGameName(filename);

                    gamenameToFilename.Add(gamename, filename); // TODO: is this necessary?

                    AddToGoogleSheet(gamename, false);
                }
            }
        }

        private void AddToGoogleSheet(string gamename, bool askRating = true)
        {
            int[] timeAndDeath = IOHelper.GetGameTimeAndDeath(Path.GetDirectoryName(gamenameToFilename[gamename]));
            if (timeAndDeath == null) return;

            // Time parameter
            int time = timeAndDeath[0];
            string timeString = HelperFunctions.timeIntoString(time);

            int deaths = timeAndDeath[1];

            int rating = 0;
            if (askRating)
                rating = GetRating(gamename);

            string spreadsheetname = Properties.Settings.Default.spreadSheetnameForGoogle;
            int startRow = (int)Properties.Settings.Default.startRowForSheet;
            int startColumn = (int)Properties.Settings.Default.startColumnForSheet;

            string dateC = IOHelper.getDateCompleted(gamenameToFilename[gamename]);



            bool complete = GoogleSheetsInserter.run(timeString, deaths, rating, gamename, spreadsheetname, startRow, startColumn, dateC);
            if (!complete)
            {
                if (MessageBox.Show("Error happened while trying to send the command! Retry?", "Error!", MessageBoxButton.OKCancel)
                    == MessageBoxResult.OK)
                    AddToGoogleSheet(gamename);
            }
        }

        private int GetRating(string gamename)
        {
            int rating = -1;
            // TODO:

            return rating;
        }

        public void HideGame(string gamename)
        {
            if (!settings.hiddenGames.Contains(gamename))
            {
                settings.hiddenGames.Add(gamename);
            }
        }

        public void DeleteGame(string gamename)
        {
            MessageBoxResult result = MessageBox.Show($"Delete {gamename}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                settings.gameNames.Remove(gamename);
                settings.recentGames.Remove(gamename);
                settings.newGames.Remove(gamename);
                settings.hiddenGames.Remove(gamename);
                // Move to a backup directory?
                Directory.Delete(Path.GetDirectoryName(gamenameToFilename[gamename]), true);
            }
        }

        private void LoadSettings()
        {
            settings = MySettings.Load();
        }
        public void saveSettings()
        {
            settings.Save();
        }

        private void runningGame_exited(object sender, EventArgs e)
        {
            AutohotkeyScriptManager.Start();
        }

        public void StartGame(string gamename)
        {
            string filePath = gamenameToFilename[gamename];
            runningGame.StartInfo.FileName = filePath;
            runningGame.StartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);

            // Adding or moving the game to recent games list first position
            settings.recentGames.Remove(gamename);
            settings.recentGames.Insert(0, gamename);

            // Removing from new games
            settings.newGames.Remove(gamename);

            if (Properties.Settings.Default.openStatsOnGameStart)
            {
                //StartStatsForm();
            }
            if (Properties.Settings.Default.startAutoScriptOnGameStart)
            {
                AutohotkeyScriptManager.Stop();
            }

            //this.Hide();
            runningGame.Start();
        }

        public void deleteFromSettings(string gamename)
        {
            settings.gameNames.Remove(gamename);
            settings.newGames.Remove(gamename);
            settings.recentGames.Remove(gamename);
            settings.hiddenGames.Remove(gamename);
        }


        private List<string> allGameNames;
        public void checkDirectoryForGames(string dirPathToCheck)
        {
            string[] directories = Directory.GetDirectories(dirPathToCheck);
            if (allGameNames == null)
            {
                allGameNames = new List<string>();
            }
            foreach (string dir in directories)
            {
                AddDirectoryToGames(dir);
            }

            cleanSettings();
        }

        // Run after adding directories to lists
        private void cleanSettings()
        {
            // TODO: make better
            settings.gameNames.AddRange(settings.newGames.Except(settings.gameNames));
            settings.gameNames.AddRange(settings.recentGames.Except(settings.gameNames));
            settings.gameNames.AddRange(settings.hiddenGames.Except(settings.gameNames));

            var nameArray = settings.gameNames.Except(allGameNames);
            // Remove deleted ones from saved names
            foreach (string name in nameArray)
            {
                settings.gameNames.Remove(name);
                settings.newGames.Remove(name);
                settings.recentGames.Remove(name);
                settings.hiddenGames.Remove(name);
            }
            allGameNames = null;
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
            string filePath = filenames[0];
            string gameName = HelperFunctions.getGameName(filePath);

            // Is the game found form old games
            if (settings.gameNames.Contains(gameName))
            {
                // Is it on hide list
                if (settings.hiddenGames.Contains(gameName))
                {
                    settings.recentGames.Remove(gameName);
                    settings.newGames.Remove(gameName);
                }
            }
            else
            {
                // New game
                settings.gameNames.Add(gameName);
                settings.newGames.Add(gameName);
            }

            gamenameToFilename.Add(gameName, filePath);
            allGameNames.Add(gameName);
        }

    }
}