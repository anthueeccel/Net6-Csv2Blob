using CsvHelper;
using CsvHelper.Configuration;
using System.Text;

namespace PocCsv.Utils
{
    public class ImportExportFiles : IImportExportFiles
    {
        public IEnumerable<T> ImportCsv<T, TMap>(Stream streamFile)
            where T : class
            where TMap : ClassMap<T>
        {
            using StreamReader reader = new(streamFile, Encoding.GetEncoding("UTF-8"), true);
            using var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture));

            return csv.GetRecords<T>().ToList();
        }
    }
}
