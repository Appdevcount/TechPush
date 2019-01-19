using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPush.Core;
using TechPush.Infrastructure.CMS;

namespace TechPush.Model.CMS
{
    public class PostViewModel
    {
        public List<Category> Categories { get; set; }
        public int Category { get; set; }
        public Post Post { get; set; }
        public List<Region> Regions { get; set; }
        public TagViewModel Tag { get; set; }
        public int Region { get; set; }

    }
    public class TagViewModel    
    {
        //BlogDBContext dbctx = new BlogDBContext();
        ////IEnumerable<Tag> _AvalableTags;
        //IEnumerable<Tag> _SelectedTags;

        public IEnumerable<Tag> AvalableTags { get; set; }//{ return dbctx.Tags.ToList<Tag>(); } }  // set { this._AvalableTags = value; } }
        public IEnumerable<Tag> SelectedTags { get; set; }// { return new List<Tag>(); } set { this._SelectedTags = value; } }
    
        public string[] PostedTags { get; set; }
    }
}
