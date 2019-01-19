using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechPush.Core;
using TechPush.Infrastructure;
using TechPush.Infrastructure.CMS;
using TechPush.Model.CMS;

namespace TechPush.Areas.CMS.Controllers
{
    public class AdminController : Controller
    {
        private IBlogRepository IBlogRepository = new BlogRepository();
        //public AdminController(IBlogRepository _IBlogRepository)
        //{
        //    this.IBlogRepository = _IBlogRepository;
        //}
        // GET: CMS/Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            Category c = new Category();
            return View(c);
        }
        [HttpPost]
        public ActionResult AddCategory(Category Category)
        {
            IBlogRepository.AddCategory(Category);
            return View();
        }
        public ActionResult AddTag()
        {
            Tag t = new Tag();
            return View(t);
        }
        [HttpPost]
        public ActionResult AddTag(Tag Tag)
        {
            IBlogRepository.AddTag(Tag);
            return View();
        }
        public ActionResult AddPost()
        {

            Helper H = new Helper();
            H.seed();
            //Category Subcategory ||| Region Neighborhood can be added as lvchnnai

            PostViewModel pvm = new PostViewModel();
            BlogDBContext dbctx = new BlogDBContext();

            var d = dbctx.Posts.ToList();

            List<Tag> tgs = dbctx.Tags.ToList<Tag>();

            TagViewModel tvm = new TagViewModel()
            {
                AvalableTags = tgs,
                SelectedTags = new List<Tag>(),
                
            };
            pvm.Tag = tvm;

            List<Region> Rgs = dbctx.Regions.ToList();
            //ViewBag.CityList = Rgs;
            pvm.Regions = Rgs;
            List<Category> ctgs = dbctx.Categories.ToList();
            //ViewBag.CityList = Rgs;
            pvm.Categories = ctgs;

            return View(pvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(PostViewModel Postvm)
        {


            Postvm.Post.Description = HttpUtility.HtmlEncode(Postvm.Post.Description);
            Post p;
            using (BlogDBContext dbctx = new BlogDBContext())
            {
                //Postvm.Post.Category = dbctx.Categories.Find(Postvm.Category);
                p = Postvm.Post;
                //p.Region = dbctx.Regions.Find(Postvm.Region);
                int[] ia = Postvm.Tag.PostedTags.Select(s => int.Parse(s)).ToArray();//Converting string ID array to integer ID Array
                                                                                     //var d = dbctx.Tags.Where(x => ia.Contains(x.Id)).ToList();
                List<Tag> tgs = dbctx.Tags.Where(x => ia.Contains(x.TagId)).ToList(); ;// dbctx.Tags.Where(x=>  Postvm.Tag.PostedTags.Select(s=>int.Parse(s)).ToArray().Contains(x.Id)).ToList();
                //foreach(Tag t in tgs)
                //{
                    p.Tags=tgs;

                //}


                //=========
                List<Tag> tgsS = dbctx.Tags.ToList<Tag>();

                TagViewModel tvm = new TagViewModel()
                {
                    AvalableTags = tgsS,
                    SelectedTags = new List<Tag>(),

                };
                Postvm.Tag = tvm;

                List<Region> Rgs = dbctx.Regions.ToList();
                //ViewBag.CityList = Rgs;
                Postvm.Regions = Rgs;
                List<Category> ctgs = dbctx.Categories.ToList();
                //ViewBag.CityList = Rgs;
                Postvm.Categories = ctgs;

            }


            IBlogRepository.AddPost(p);
            return View(Postvm);
        }
        public ActionResult EditPost(int PostId)
        {
            PostViewModel pvm = new PostViewModel();
            pvm.Post= IBlogRepository.Post(PostId);
            pvm.Post.Description = HttpUtility.HtmlDecode(pvm.Post.Description);
            pvm.Tag = new TagViewModel()
            {
                //AvalableTags = tgs,
                SelectedTags = pvm.Post.Tags// new List<Tag>()
        };

                //BlogDBContext dbctx = new BlogDBContext();

                //List<Tag> tgs= dbctx.Tags.ToList<Tag>();

                //    TagViewModel tvm = new TagViewModel() { AvalableTags = tgs, SlectedTags= new List<Tag>()
                //};
                //    pvm.Tag = tvm;


            return View(pvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(PostViewModel Post)
        {
            Post.Post.Description = HttpUtility.HtmlEncode(Post.Post.Description);
            IBlogRepository.EditPost(Post);
            return View();
        }
    }
}