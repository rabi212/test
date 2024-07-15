using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ITCGKPLAB.Tags
{
    public interface ICloudStorageServices
    {
        Task DeleteFileAsync(string filenameToDelete);
        Task<string> GetSignUrlAsync(string filenameToRead, int timeOutInMinutes = 30);
        Task<string> UploadFileAsync(IFormFile fileToUpload, string filenameToSave);
    }
}