using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIBackend.Data
{
    public class Genrer
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string NAME { get; set; }

        [Column("YEAR_APPEARANCE")]
        public string YearAppearance { get; set; }

        [Column("POPULARITY")]
        public int Popularity { get; set; }
    }
}
