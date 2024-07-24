﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W23G72.DataAccess.Repository.IRepository;
using W23G72.Models;

namespace W23G72.Data.Repository.IRepository
{
    public interface IContactReposiory : IRepository<Contact>
    {
        object Get(int id);
        void Update(Contact obj);

    }
}