using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class PostModel 
    {
        public int _id {get; set;}
        public string name {get; set;}
        public string website {get; set;}
        public string description {get; set;}
    }

    public class DatabaseService
    {
        public List<PostModel> GetPosts()
        {
            return _posts;
        }

        public PostModel FindById(int id)
        {
            return _posts.Where(x => x._id == id).First();
        }

        public void Create(PostModel post)
        {
            post._id = _posts.Last()._id + 1;
            _posts.Add(post);
        }

        public void Update(int id, string name, string description, string website)
        {
            var post = _posts.Where(x => x._id == id).First(); 
            post.description = description;
            post.name = name;
            post.website = website;
        }


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
    }
}
