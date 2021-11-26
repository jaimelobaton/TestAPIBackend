using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPIBackend.Data
{
    public partial class Director
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ? BirthDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DeathDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? YearStart { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? YearEnd { get; set; }
    }
}
