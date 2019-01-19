#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace TechPush.Core
{
    /// <summary>
    /// Represents a tag that is labelled on a post.
    /// </summary>
    public class Tag
    {
        [Key]
        public int TagId
        { get; set; }

        [Required(ErrorMessage = "Tag Name: Field is required")]
        [StringLength(500, ErrorMessage = "Tag Name: Length should not exceed 500 characters")]
        public string Name
        { get; set; }

        [Required(ErrorMessage = "UrlSlug: Field is required")]
        [StringLength(500, ErrorMessage = "UrlSlug: Length should not exceed 500 characters")]
        public string UrlSlug
        { get; set; }

        public string Description
        { get; set; }

        public virtual ICollection<Post> Posts
        { get; set; }
    }
}
