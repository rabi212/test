using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using ITCGKPLAB.Utilies.ConfigOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKPLAB.Tags
{
    public class CloudStorageServices : ICloudStorageServices
    {
        private readonly GCSConfigOptions _options;
        private readonly ILogger<CloudStorageServices> _logger;
        public  readonly GoogleCredential _googleCredential;
        public CloudStorageServices(IOptions<GCSConfigOptions> options,ILogger<CloudStorageServices> logger)
        {
            _logger = logger;
            _options = options.Value;
            
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment == Environments.Production)                
            {
                // Store the json file to secrets change git hub
                _googleCredential = GoogleCredential.FromJson(_options.GCPStorageAuthFile);                
            }
            else
            {
                _googleCredential = GoogleCredential.FromFile(_options.GCPStorageAuthFile);
            }
        }
        public async Task DeleteFileAsync(string filenameToDelete)
        {
            try
            {
                using (var storageClient = StorageClient.Create(_googleCredential))
                {
                    await storageClient.DeleteObjectAsync(_options.GoogleCloudStorageBucketName, filenameToDelete);
                }
                _logger.LogInformation($"File {filenameToDelete} deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while deleting file {filenameToDelete} : {ex.Message}");                
                throw;
            }
        }
        public async Task<string> GetSignUrlAsync(string filenameToRead, int timeOutInMinutes = 30)
        {
            try
            {
                var sac = _googleCredential.UnderlyingCredential as ServiceAccountCredential;
                var urlSigner = UrlSigner.FromServiceAccountCredential(sac);
                var signedUrl = await urlSigner.SignAsync(_options.GoogleCloudStorageBucketName, filenameToRead, TimeSpan.FromMinutes(timeOutInMinutes));
                return signedUrl.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while obtaining signed url file {filenameToRead} : {ex.Message}");
                throw;
            }
        }
        public async Task<string> UploadFileAsync(IFormFile fileToUpload , string filenameToSave)
        {
            try
            {
            
                _logger.LogInformation($"Uploading file {filenameToSave} to storage {_options.GoogleCloudStorageBucketName}");
                using (var memoryStream = new MemoryStream())
                {
                    await fileToUpload.CopyToAsync(memoryStream);
                    using (var storageClient = StorageClient.Create(_googleCredential))
                    {
                        var uploadedFile = await storageClient.UploadObjectAsync(_options.GoogleCloudStorageBucketName, filenameToSave, fileToUpload.ContentType, memoryStream);
                        _logger.LogInformation($"Uploaded file {filenameToSave} to storage {_options.GoogleCloudStorageBucketName}");
                        return uploadedFile.MediaLink;

                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error while uploading file {filenameToSave} : {ex.Message}");
                throw;
            }
        }

    }
}
