﻿using System;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      

        public void Update(Category obj)
        {
           _db.Categories.Update(obj);
        }
    }
}
