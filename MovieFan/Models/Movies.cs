using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieFan.Models
{
    public partial class Movies
    {
        public List<string> Likers
        {
            get => this.UserLikeMovie.Select(u => u.User.FullName).ToList();
        }

        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate
        {
            get => this.Release;
            set => this.Release = value;
        }

        public class MoviesMetadata
        {
            [Display(Name = "Résumé")]
            [MinLength(20, ErrorMessage = "Trop court mon coco")]
            [RegularExpression(@"^((?!fuck).)*$", ErrorMessage = "On ne dis pas fuck !")]

            public string Synopsis { get; set; }
            [Display(Name = "Titre")]
            [Required(ErrorMessage = "Il faut un titre")]
            public string Title { get; set; }
            public DateTime? Release { get; set; }
        }
    }
}
