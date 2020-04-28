using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Dotnetcore_Webapi_MongoDB.Model;

namespace dotnetcore_webapi_mongodb.IRepository
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetAsync();
        Task<Subscriber> Get(string id);
        Task Add(Subscriber subscriber);
        Task<string> Update(string id, Subscriber subscriber);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}