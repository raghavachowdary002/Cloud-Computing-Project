using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;

namespace MyExperiment.SEProjectCode
{
    /*This class is used to extract content from Zip File*/
    public class ExtractFromBlob
    {
      public  void ExtractMethod(string zipPath,string extractPath)
        {
            
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
