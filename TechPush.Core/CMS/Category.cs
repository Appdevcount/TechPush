
#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace TechPush.Core
{

    public class Category
    {

        [Key]
        public int Id
        { get; set; }

        [Required(ErrorMessage = "Category Name: Field is required")]
        [StringLength(500, ErrorMessage = "Category Name: Length should not exceed 500 characters")]
        public string Name
        { get; set; }

        [Required(ErrorMessage = "UrlSlug: Field is required")]
        [StringLength(500, ErrorMessage = "UrlSlug: Length should not exceed 500 characters")]
        public string UrlSlug
        { get; set; }

        public string Description
        { get; set; }

        public bool Enable
        { get; set; }

        public virtual ICollection<Post> Posts
        { get; set; }
    }
}


