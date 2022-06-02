namespace PocCsv.Services
{
    public interface IAzureBlobService
    {
        bool Delete(string fileName);
        void Upload(IFormFile file);
    }
}
