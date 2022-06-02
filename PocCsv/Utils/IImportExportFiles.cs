using CsvHelper.Configuration;

namespace PocCsv.Utils
{
    public interface IImportExportFiles
    {
        IEnumerable<T> ImportCsv<T, TMap>(Stream streamReader) where T : class where TMap : ClassMap<T>;
    }
}
