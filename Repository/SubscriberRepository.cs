using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using Dotnetcore_Webapi_MongoDB.Model;
using Dotnetcore_Webapi_MongoDB.Entities;
using dotnetcore_webapi_mongodb.IRepository;

namespace dotnetcore_webapi_mongodb.Repository
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ObjectContext _context = null;
        public SubscriberRepository(IOptions<DbSettings> settings)
        {
            _context=new ObjectContext(settings);
        }
       public async Task Add(Subscriber subscriber)
        {
            await _context.Subscribers.InsertOneAsync(subscriber);
        }

        public async Task<IEnumerable<Subscriber>> GetAsync()
        {
            return await _context.Subscribers.Find(x => true).ToListAsync();
        }

        public async Task<Subscriber> Get(string id)
        {
          
            return await _context.Subscribers.Find(x=> x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
         
            return await _context.Subscribers.DeleteOneAsync( x=> x.Id==id );
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Subscribers.DeleteManyAsync(new BsonDocument());
        }

        public async Task<string> Update(string id, Subscriber subscriber)
        {
            await _context.Subscribers.ReplaceOneAsync(xx=> xx.Id==id, subscriber);
            return "";
        }
    }
}