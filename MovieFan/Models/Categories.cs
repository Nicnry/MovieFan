using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFan.Models
{
    public partial class Categories
    {
    }
    public partial class CategoryMetadata
    {
        [Display(Name = "Catégorie")]
        public string Name { get; set; }

        [Display(Name = "Film dans cette catégorie")]
        public virtual ICollection<Movies> Movies { get; set; }
    }
}
