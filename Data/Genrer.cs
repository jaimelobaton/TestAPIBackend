using System.ComponentModel.DataAnnotations;

namespace TestAPIBackend.Data
{
    public partial class Genrer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string YearAppearance { get; set; }
        public int? Popularity { get; set; }
    }
}
