using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;


namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly DatabaseService _service = new DatabaseService();

        [HttpGet("")]
        public JsonResult ListPosts()
        {
            var posts = _service.GetPosts();
            return Json(posts);
        }

        [HttpGet("{id}")]
        public JsonResult GetPost(int id)
        {
            var post = _service.FindById(id);
            return Json(post);
        }


        [HttpPost("")]
        public JsonResult CreatePost([FromBody] PostRequest request)
        {
           var post =  new PostModel()
            {
                name = request.name,
                website = request.website,
                description = request.description 
            };

            _service.Create(post);
            return Json(new {success = true});
        }


        [HttpPost("{id}")]
        public JsonResult UpdatePost(int id, [FromBody] PostRequest request)
        {  
            _service.Update(id, request.name, request.description, request.website);
            return Json(new {success = true });
        }
    }

    public class PostRequest
    {
        public string name {get; set;}
        public string website {get; set;}
        public string description {get; set;}
    }
}