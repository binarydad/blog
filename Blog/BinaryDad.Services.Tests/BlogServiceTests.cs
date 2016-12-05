using BinaryDad.Data.Repositories;
using BinaryDad.Models;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BinaryDad.Services.Tests
{
    [TestClass]
    public class BlogServiceTests
    {
        private ContentService BlogService;

        private static readonly Guid blogId = new Guid("08a85d1b-d78a-4461-a8e2-b43aa684557f");

        public BlogServiceTests()
        {
            var container = new UnityContainer();

            container.RegisterType<IContentRepository, StubContentRepository>();

            BlogService = container.Resolve<ContentService>();
        }

        //[TestMethod]
        //public void Get_Blogs()
        //{
        //    var blogs = BlogService.GetBlogs();

        //    Assert.IsTrue(blogs != null);
        //    Assert.IsTrue(blogs.Any());
        //}

        [TestMethod]
        public void Get_Blog()
        {
            var blog = BlogService.Get<Blog>(blogId);

            Assert.IsTrue(blog != null);
            Assert.AreEqual(blogId, blog.ID);
            Assert.AreEqual("Test blog", blog.Title);
        }

        [TestMethod]
        public void Get_Blog_Posts()
        {
            var blog = BlogService.Get<Blog>(blogId);
            var posts = blog.Entries;

            Assert.IsNotNull(blog);
            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Any());

        }
    }
}
