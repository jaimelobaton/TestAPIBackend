using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIBackend.Data
{
    public class Movie
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("ID_GENRER")]
        public int? IdGenrer { get; set; }

        [Column("DURATION")]
        public int? Duration { get; set; }

        [Column("RELEASEDATE")]
        public DateTime? ReleaseDate  { get; set; }

        [Column("LIKED")]
        public bool? Liked { get; set; }

        [Column("IDTYPELIST")]
        public int? IdTypeList { get; set; }

        [Column("CREATOR_USER")]
        public int CreatorUser { get; set; }
    }
}
