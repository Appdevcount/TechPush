using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPush.Core.CMS
{

    public class HotNews
    {

        [Key]
        public int Id
        { get; set; }

        [Required(ErrorMessage = "HotNewsText: Field is required")]
        [StringLength(500, ErrorMessage = "HotNewsText: Length should not exceed 500 characters")]
        public string HotNewsText
        { get; set; }

        [Required(ErrorMessage = "Description: Field is required")]
        [StringLength(800, ErrorMessage = "Description: Length should not exceed 500 characters")]
        public string Description
        { get; set; }
        [Required(ErrorMessage = "Advertiser: Field is required")]
        public Advertiser Advertiser
        { get; set; }
        [Required(ErrorMessage = "PostedOn: Field is required")]
        public DateTime PostedOn
        { get; set; }
        public bool Enable
        { get; set; }


    }
}
