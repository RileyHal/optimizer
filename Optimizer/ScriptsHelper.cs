using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer

{
    public class Script
    {
        public string Name {  get; set; }
        public string Type { get; set; }
        public string Path { get; set; }

        public Script(string name, string type, string path) {
            this.Name = name;
            this.Type = type;
            this.Path = path;
        }
    }

    internal class DirectoryConverter
    {
        public static List<Script> ConvertFilesToScripts()
        {
            List<Script> scripts = new List<Script>();
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Scripts");

            try
            {
                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    throw new DirectoryNotFoundException($"Directory '{directoryPath}' not found.");
                }

                // Get all files in the directory
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    string extension = Path.GetExtension(file).ToLower();

                    // Map file extensions to types
                    string type;
                    switch (extension)
                    {
                        case ".bat":
                        case ".exe":
                        case ".ps1":
                        case ".reg":
                            type = extension.Substring(1); // Remove the dot
                            break;
                        default:
                            // Skip files with unrecognized extensions
                            continue;
                    }

                    // Create a new Script instance and add it to the list
                    Script script = new Script(fileName, type, file);
                    scripts.Add(script);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return scripts;
        }
    }
}
