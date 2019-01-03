
#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace TechPush.Core
{

    public class Region
    {

        [Key]
        public int RegionId
        { get; set; }

        [Required(ErrorMessage = "Region Name: Field is required")]
        [StringLength(500, ErrorMessage = "Region Name: Length should not exceed 500 characters")]
        public string RegionName
        { get; set; }

        public bool Enable
        { get; set; }

        
    }
}


