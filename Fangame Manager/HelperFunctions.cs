using System.IO;

namespace Fangame_Manager
{
    class HelperFunctions
    {
        private static string timeIntoStringPart(int time)
        {
            return (time < 10 ? "0"  : "") + time.ToString();
        }
        public static string timeIntoString(int timeInSeconds)
        {
            string timeString = "0";
            if (timeInSeconds > 0)
            {
                int hrs = timeInSeconds / 3600;
                int mins = (timeInSeconds % 3600) / 60;
                int secs = timeInSeconds % 60;
                timeString = $"{timeIntoStringPart(hrs)}:{timeIntoStringPart(mins)}:{timeIntoStringPart(secs)}";
            }
            return timeString;
        }

        
        /// <summary>
        /// Get the gamename to use in settings and listboxes
        /// </summary>
        /// <param name="filePath">Full path to file, with or without extension</param>
        /// <returns>Either the filename or directoryname, whichever is longer</returns>
        public static string getGameName(string filePath)
        {
            string dirPath = Path.GetDirectoryName(filePath);
            string[] filenames = Directory.GetFiles(dirPath, "*.exe");
            string filename = filenames[0];
            string exeName = Path.GetFileNameWithoutExtension(filename);
            string gamename = Path.GetFileName(dirPath);

            return exeName.Length > gamename.Length ? exeName : gamename;
        }
    }
}
