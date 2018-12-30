using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPush.Core;

namespace TechPush.Model.CMS
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public TagViewModel Tag { get; set; }
        
    }

    public class TagViewModel    
    {
        public IEnumerable<Tag> AvalableTags { get; set; }
        public IEnumerable<Tag> SlectedTags { get; set; }
        public string[] PostedTags { get; set; }
    }
}
