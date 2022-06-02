namespace PocCsv.Services
{
    public interface IImportExportService
    {
        void ImportCsv(IFormFile file);
        bool DeleteFile(string fileName);
    }
}
