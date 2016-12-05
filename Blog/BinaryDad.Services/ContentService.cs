using BinaryDad.Data.Repositories;
using BinaryDad.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDad.Services
{
    public class ContentService
    {
        protected IContentRepository ContentRepository { get; private set; }

        public ContentService(IContentRepository repository)
        {
            ContentRepository = repository;
        }

        public IQueryable<T> Get<T>() where T : Content
        {
            return ContentRepository.Get<T>();
        }

        public T Get<T>(string path) where T : Content
        {
            return Get<T>().FirstOrDefault(c => c.Path == path);
        }

        public T Get<T>(Guid id) where T : Content
        {
            return Get<T>().FirstOrDefault(c => c.ID == id);
        }

        public async Task<bool> Delete(string path)
        {
            return await ContentRepository.Delete(path);
        }

        public async Task<T> Save<T>(T content) where T : Content
        {
            if (!ValidateContent(content))
            {
                return null;
            }

            content.Revision++;
            content.LastModified = DateTime.Now;

            return await ContentRepository.Save(content);
        }

        public async Task<T> Create<T>(T content) where T : Content
        {
            if (!ValidateContent(content))
            {
                return null;
            }

            if (content.Published == null)
            {
                content.Published = DateTime.Now;
            }

            content.ID = Guid.NewGuid();
            content.LastModified = DateTime.Now;
            content.Revision = 1;

            return await ContentRepository.Create(content);
        }

        public void Dispose()
        {
            ContentRepository.Dispose();
        }

        #region Private Methods

        private static bool ValidateContent(Content content)
        {
            Func<string, bool> notEmpty = t => !string.IsNullOrWhiteSpace(t);

            return notEmpty(content.Title)
                //&& notEmpty(content.Body)
                && notEmpty(content.Path);
        } 

        #endregion
    }
}
