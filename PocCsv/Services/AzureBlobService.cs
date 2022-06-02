using Azure.Storage.Blobs;

namespace PocCsv.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly BlobServiceClient _blobService;
        private BlobContainerClient? _blobContainer;

        public AzureBlobService()
        {
            _blobService = new BlobServiceClient("yourAzureAccountConnectionString");
        }
        public bool Delete(string fileName)
        {
            try
            {
                _blobContainer = _blobService.GetBlobContainerClient("fileShareName");
                BlobClient blobClient = _blobContainer.GetBlobClient(fileName);
                blobClient.Delete();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var newFileName =
                    string.Concat(
                        fileName, 
                        Convert.ToString(Guid.NewGuid()),
                        Path.GetExtension(fileName));

                _blobContainer = _blobService.GetBlobContainerClient("fileShareName");
                _blobContainer.CreateIfNotExists();

                BlobClient blobClient = _blobContainer.GetBlobClient(newFileName);

                using Stream stream = file.OpenReadStream();
                blobClient.Upload(stream);
                
                //return fileUrl @ blobStorage
                var fileUrl = blobClient.Uri.AbsoluteUri;
            }
        }
    }
}