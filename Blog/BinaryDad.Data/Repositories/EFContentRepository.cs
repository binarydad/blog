using AutoMapper;
using BinaryDad.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDad.Data.Repositories
{
    public class EFContentRepository : DbContextRepository<BlogContext>, IContentRepository
    {
        private readonly Guid _defaultBlogId = new Guid("A0BA2F4A-7954-47F0-968B-5D13625BA8CA");

        static EFContentRepository()
        {
            Mapper.Initialize(a =>
            {
                a.CreateMap<Page, Page>()
                    .ForMember(c => c.ID, o => o.Ignore())
                    .ForMember(c => c.Parent, o => o.Ignore());

                a.CreateMap<BlogEntry, BlogEntry>()
                    .ForMember(c => c.ID, o => o.Ignore())
                    .ForMember(c => c.Blog, o => o.Ignore());
            });
        }

        public IQueryable<T> Get<T>() where T : Content
        {
            return Context
                .Content
                .OfType<T>();
        }

        public async Task<T> Create<T>(T content) where T : Content
        {
            if (content is BlogEntry)
            {
                (content as BlogEntry).Blog = await Get<Blog>().FirstOrDefaultAsync(c => c.ID == _defaultBlogId);
            }

            if (content is Page)
            {
                var page = content as Page;

                page.Parent = await Get<Page>().FirstOrDefaultAsync(p => p.ID == page.Parent.ID);
            }

            Context.Set<T>().Add(content);

            await Context.SaveChangesAsync();

            return content;
        }

        public async Task<T> Save<T>(T content) where T : Content
        {
            var existing = await Get<T>().FirstOrDefaultAsync(c => c.ID == content.ID);

            Mapper.Map(content, existing);

            // per-content specifics
            if (content is Page)
            {
                var page = content as Page;
                (existing as Page).Parent = await Get<Page>().FirstOrDefaultAsync(c => c.ID == page.Parent.ID);
            }

            await Context.SaveChangesAsync();

            return content;
        }

        public async Task<bool> Delete(string path)
        {
            var content = await Context.Content.FirstOrDefaultAsync(c => c.Path == path);
            Context.Content.Remove(content);

            await Context.SaveChangesAsync();

            return true;
        }
    }
}
