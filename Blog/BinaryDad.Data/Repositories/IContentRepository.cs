using BinaryDad.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDad.Data.Repositories
{
    public interface IContentRepository : IDisposable
    {
        IQueryable<T> Get<T>() where T : Content;
        Task<T> Create<T>(T content) where T : Content;
        Task<T> Save<T>(T content) where T : Content;
        Task<bool> Delete(string path);
        
    }
}
