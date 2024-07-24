using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using W23G72.Data.Repository.IRepository;
using W23G72.DataAccess.Repository;
using W23G72.Models;

namespace W23G72.Data.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Event obj)
        {
            var objFromDb = _db.Events.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}