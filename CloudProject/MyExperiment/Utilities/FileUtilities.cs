using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyExperiment.Utilities
{
    public static class FileUtilities
    {
        /// <summary>
        /// Reading the text 
        /// </summary>
        /// <param name="localfilePath"></param>
        /// <returns></returns>
        public static string ReadFile(string localFilePath)
        {
            string jsonString = File.ReadAllText(localFilePath);
            return jsonString;
        }
       // private static object lockObj = new Object();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void WriteDataInFile(string fileName, int[] data, string output)
        // public static void WriteDataInFile(string fileName,  string output)
        {
            // Create a local file in the ./data/ directory for uploading and downloading
            string localfilePath = Path.Combine(Experiment.DataFolder, fileName);

            if (!File.Exists(localfilePath))
            {
                File.Create(localfilePath);
            }
            
            StreamWriter sw = File.AppendText(localfilePath);
             

             try
                {

                    sw.WriteLine();
                    sw.Write(output);
               }
               finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }

                }
            }
        
    


