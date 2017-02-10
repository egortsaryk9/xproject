using System;
using Xunit;
using Core;

namespace CoreTests
{
    public class DatabaseServiceTests
    {
        private readonly DatabaseService _subject;

        public DatabaseServiceTests()
        {
            _subject = new DatabaseService();
        }

        [Fact]
        public void ShouldReturnListOfPosts() 
        {
            var posts = _subject.GetPosts();
            Assert.True(posts.Count > 0);
        }
    }
}
