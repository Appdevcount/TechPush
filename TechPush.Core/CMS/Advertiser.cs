using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPush.Core.CMS
{

    public class Advertiser
    {

        [Key]
        public int Id
        { get; set; }

        [Required(ErrorMessage = "Category Name: Field is required")]
        [StringLength(500, ErrorMessage = "Category Name: Length should not exceed 500 characters")]
        public string AdvertiserName
        { get; set; }

        [Required(ErrorMessage = "UrlSlug: Field is required")]
        [StringLength(800, ErrorMessage = "UrlSlug: Length should not exceed 500 characters")]
        public string Description
        { get; set; }

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo
        { get; set; }

        [Required(ErrorMessage = "PostedOn: Field is required")]
        public DateTime CreatedOn
        { get; set; }

        public bool Enable
        { get; set; }

    }
}
