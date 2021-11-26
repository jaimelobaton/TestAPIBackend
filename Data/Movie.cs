using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPIBackend.Data
{
    public partial class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public int? Duration { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? ReleaseDate  { get; set; }
        public string CreatorUser { get; set; }
        public int GenrerId { get; set; }
        public virtual Genrer Genrer { get; set; }
        public int StudioId { get; set; }
        public virtual Studio Studio { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
    }
}
