using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestAPIBackend.Data
{
    public partial class LikedMoviesUsers
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        
        public bool Liked { get; set; }

        public string User { get; set; }
    }
}
