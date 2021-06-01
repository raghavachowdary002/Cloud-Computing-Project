using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudProject.Common
{
    public interface IStorageProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">The name of the local file where the input is downloaded.</param>
        /// <returns></returns>
        Task<string> DownloadInputFile(string filename);

         Task<byte[]> UploadResultFile(string fileName, byte[] data);
        
        Task UploadExperimentResult(ExperimentResult result);

        Task download_from_blob();

     //   void DownloadBlobResult(string filename);

    }
}
