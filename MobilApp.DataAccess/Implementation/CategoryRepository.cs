﻿using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilApp.DataAccess.Implementation
{
    public class CategoryRepository:GenericRepository<Categories>,ICategoryRepository
    {
        public CategoryRepository(MobilAppDbContext carcontext) : base(carcontext)
        {

        }
    }
}
