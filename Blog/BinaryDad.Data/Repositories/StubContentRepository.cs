using BinaryDad.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDad.Data.Repositories
{
    public class StubContentRepository : IContentRepository
    {
        protected Blog[] Blogs { get; private set; }
        protected BlogEntry[] BlogEntries { get; private set; }

        public StubContentRepository()
        {
            BlogEntries = new BlogEntry[0];

            Blogs = new[]
            {
                new Blog
                {
                    ID = new Guid("ffd93aaf-3479-4995-97f8-6d3a41daaf06"),
                    Title = "Geek blog",
                    Body = "This is the body",
                    Path = "geek-blog",
                    Published = new DateTime(2014, 6, 23, 6, 0, 0),
                    Revision = 1,
                },

                new Blog
                {
                    ID = new Guid("08a85d1b-d78a-4461-a8e2-b43aa684557f"),
                    Title = "Test blog",
                    Body = "Here is some content",
                    Path = "test-blog",
                    Published = new DateTime(2014, 6, 21, 13, 0, 0),
                    Revision = 1,
                },
            };

            BlogEntries = new[]
            {
                new BlogEntry
                {
                    Title = "Hello, world",
                    Body = "This is the content of a blog entry",
                    Path = "hello-world",
                    Blog = Blogs.FirstOrDefault(b => b.ID == new Guid("ffd93aaf-3479-4995-97f8-6d3a41daaf06"))
                },

                new BlogEntry
                {
                    Title = "Another post",
                    Body = "Here is another entry",
                    Path = "another-post",
                    Blog = Blogs.FirstOrDefault(b => b.ID == new Guid("ffd93aaf-3479-4995-97f8-6d3a41daaf06"))
                },

                new BlogEntry
                {
                    Title = "First entry",
                    Body = "Here is my first entry",
                    Path = "first-entry",
                    Blog = Blogs.FirstOrDefault(b => b.ID == new Guid("08a85d1b-d78a-4461-a8e2-b43aa684557f"))
                }
            };

            Blogs
                .FirstOrDefault(b => b.ID == new Guid("ffd93aaf-3479-4995-97f8-6d3a41daaf06"))
                .Entries = BlogEntries.Where(e => e.Blog.ID == new Guid("ffd93aaf-3479-4995-97f8-6d3a41daaf06")).ToList();

            Blogs
                .FirstOrDefault(b => b.ID == new Guid("08a85d1b-d78a-4461-a8e2-b43aa684557f"))
                .Entries = BlogEntries.Where(e => e.Blog.ID == new Guid("08a85d1b-d78a-4461-a8e2-b43aa684557f")).ToList();
        }

        public IQueryable<Blog> GetBlogs()
        {
            return Blogs.AsQueryable();
        }

        public IQueryable<Blog> GetBlogHistory(Guid blogId)
        {
            return null;
        }

        public Blog CreateBlog(Blog blog)
        {
            return blog;
        }

        public BlogEntry CreateBlogEntry(BlogEntry entry)
        {
            var existingBlog = Blogs.FirstOrDefault(b => b.ID == entry.Blog.ID);

            existingBlog.Entries.Add(entry);

            return entry;
        }

        public IQueryable<BlogEntry> GetBlogEntries()
        {
            return BlogEntries.AsQueryable();
        }

        public IQueryable<T> Get<T>() where T : Content
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        Task<T> IContentRepository.Create<T>(T content)
        {
            throw new NotImplementedException();
        }

        Task<T> IContentRepository.Save<T>(T content)
        {
            throw new NotImplementedException();
        }

        Task<bool> IContentRepository.Delete(string path)
        {
            throw new NotImplementedException();
        }
    }
}
