using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestAPIBackend.Data
{
    public partial class Studio

    {
      
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string CityAllocated { get; set; }

        public string  CountryAllocated { get; set; }

        public string Founder { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? YearStart { get; set; }

    }
}
