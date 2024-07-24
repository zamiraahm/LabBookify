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
    public class ContactRepository : Repository<Contact>, IContactReposiory
    {
        private ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact obj)
        {
            _db.Contacts.Update(obj);
        }
    }
}
