using Microsoft.AspNetCore.Mvc;
using PocCsv.Services;

namespace PocCsv.Controllers
{
    [ApiController]
    [Route("/")]
    public class ImportExportController : Controller
    {
        public IImportExportService _importExportService;

        public ImportExportController(IImportExportService importExportService)
        {
            _importExportService = importExportService;
        }

        [HttpPost]
        [Route("import-csv")]
        public void ImportCsvFrota([FromForm] IFormFile file)
        {
            if (file.ContentType == "text/csv")
            {
                _importExportService.ImportCsv(file);
            }
        }

        [HttpDelete]
        [Route("delete-file")]
        public bool DeleteFile([FromBody] string fileName)
        {
            return _importExportService.DeleteFile(fileName);
        }
    }
}
