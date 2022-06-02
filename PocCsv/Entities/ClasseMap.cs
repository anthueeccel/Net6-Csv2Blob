using CsvHelper.Configuration;

namespace PocCsv.Entities
{
    public class ClasseMap : ClassMap<ClasseModel>
    {
        public ClasseMap()
        {
            Map(m => m.Id).Index(0).Name("Id");
            Map(m => m.Product).Index(1).Name("Product");
            Map(m => m.Price).Index(2).Name("Price");
            Map(m => m.Description).Index(3).Name("Description");
        }
    }
}
