#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace TechPush.Core
{
    /// <summary>
    /// Represents a blog entry - article, presentation or any thing.
    /// </summary>

    public class Post
    {
        [Key]
        //[Required(ErrorMessage = "Id: Field is required")]
        public int Id
        { get; set; }

        /// <summary>
        /// The heading of the post.
        /// </summary>
        [Required(ErrorMessage = "Title: Field is required")]
        [StringLength(500, ErrorMessage = "Title: Length should not exceed 500 characters")]
        public string Title
        { get; set; }

        /// <summary>
        /// A brief paragraph about the post.
        /// </summary>
        [Required(ErrorMessage = "ShortDescription: Field is required")]
        public string ShortDescription
        { get; set; }

        /// <summary>
        /// The complete post content.
        /// </summary>
        [Required(ErrorMessage = "Description: Field is required")]
        public string Description
        { get; set; }

        /// <summary>
        /// The information about the post that has to be displayed in the &lt;meta&gt; tag (SEO).
        /// </summary>
        /// <remarks>
        /// Not sure Google still uses this for ranking but other search providers might be.
        /// </remarks>
        [Required(ErrorMessage = "Meta: Field is required")]
        [StringLength(1000, ErrorMessage = "Meta: Length should not exceed 1000 characters")]
        public string Meta
        { get; set; }

        /// <summary>
        /// The url slug that is used to define the post address.
        /// </summary>
        [Required(ErrorMessage = "Meta: Field is required")]
        [StringLength(1000, ErrorMessage = "Meta: UrlSlug should not exceed 50 characters")]
        public string UrlSlug
        { get; set; }

        /// <summary>
        /// Flag to represent whether the article is published or not.
        /// </summary>
        public bool Published
        { get; set; }

        /// <summary>
        /// The post published date.
        /// </summary>
        [Required(ErrorMessage = "PostedOn: Field is required")]
        public DateTime PostedOn
        { get; set; }

        /// <summary>
        /// The post's last modified date.
        /// </summary>
        public DateTime? Modified
        { get; set; }

        /// <summary>
        /// The category to which the post belongs to.
        /// </summary>
        public Category Category
        { get; set; }

        /// <summary>
        /// Collection of tags labelled over the post.
        /// </summary>
        public virtual ICollection<Tag> Tags
        { get; set; }

        /// <summary>
        /// Shed column for POST and Comments for ignoring/deleting old/inappropriate messages 
        /// </summary>
        public bool  Shed
        { get; set; }

        /// <summary>
        /// Region column for differentiating Region specific POST/Ads 
        /// </summary>
        [Required(ErrorMessage = "Region: Field is required")]
        [StringLength(50, ErrorMessage = "Region: Region should not exceed 50 characters")]
        [Column( "RegionId")]
        public Region Region
        { get; set; }

        /// <summary>
        /// Region column for differentiating Region specific POST/Ads 
        /// </summary>
        [Required(ErrorMessage = "Publisher: Field is required")]
        [StringLength(50, ErrorMessage = "Publisher: Publisher should not exceed 50 characters")]
        public string Publisher
        { get; set; }

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo
        { get; set; }
    }
}
