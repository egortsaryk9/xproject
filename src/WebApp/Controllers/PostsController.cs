using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private static List<PostModel> _posts = new List<PostModel>()
        {
            new PostModel()
            {
                _id = 1,
                name = "Angular",
                website = "https://angular.io/",
                description = "Angular is a development platform for building mobile and desktop web applications."
            },
            new PostModel()
            {
                _id = 2,
                name = "RxJs",
                website = "http://reactivex.io/",
                description = "Reactive Extensions (Rx) is a library for composing asynchronous and event-based programs using observable sequences and LINQ-style query operators."
            },
            new PostModel()
            {
                _id = 3,
                name = "Babel",
                website = "https://babeljs.io/",
                description = "Babel is a compiler for writing next generation JavaScript."
            }
        };


        [HttpGet("")]
        public JsonResult ListPosts()
        {
            return Json(_posts);
        }

        [HttpGet("{id}")]
        public JsonResult GetPost(int id)
        {
            var post = _posts.Where(x => x._id == id).First();
            return Json(post);
        }


        [HttpPost("")]
        public JsonResult CreatePost([FromBody] PostRequest request)
        {
            _posts.Add(new PostModel()
            {
                _id = _posts.Last()._id + 1, 
                name = request.name,
                website = request.website,
                description = request.description }
            );
            return Json(new {success = true });
        }


        [HttpPost("{id}")]
        public JsonResult UpdatePost(int id, [FromBody] PostRequest request)
        {  
            var post = _posts.Where(x => x._id == id).First();

            post.description = request.description;
            post.name = request.name;
            post.website = request.name;

            return Json(new {success = true });
        }
    }

    public class PostModel 
    {
        public int _id {get; set;}
        public string name {get; set;}
        public string website {get; set;}
        public string description {get; set;}
    }

    public class PostRequest
    {
        public string name {get; set;}
        public string website {get; set;}
        public string description {get; set;}
    }
}