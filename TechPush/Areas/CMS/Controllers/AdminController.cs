using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechPush.Core;
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
            PostViewModel pvm = new PostViewModel();
            //BlogDBContext dbctx = new BlogDBContext();

            //List<Tag> tgs= dbctx.Tags.ToList<Tag>();

        //    TagViewModel tvm = new TagViewModel() { AvalableTags = tgs, SlectedTags= new List<Tag>()
        //};
        //    pvm.Tag = tvm;


        return View(pvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(PostViewModel Post)
        {
            Post.Post.Description = HttpUtility.HtmlEncode(Post.Post.Description);
            IBlogRepository.AddPost(Post.Post);
            return View();
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