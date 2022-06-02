using PocCsv.Entities;
using PocCsv.Utils;

namespace PocCsv.Services
{
    public class ImportExportService : IImportExportService
    {
        public IImportExportFiles _importExportFiles;
        public IAzureBlobService _blob;

        public ImportExportService(IImportExportFiles importExportFiles, IAzureBlobService blob)
        {
            _importExportFiles = importExportFiles;
            _blob = blob;
        }

        public bool DeleteFile(string fileName)
        {
            return _blob.Delete(fileName);
        }

        public void ImportCsv(IFormFile file)
        {
            var csvEnumerable = _importExportFiles.ImportCsv<ClasseModel, ClasseMap>(file.OpenReadStream());
            //do your job here
            //_repository.Persist(csvEnumerable);

            _blob.Upload(file);
        }
    }
}
