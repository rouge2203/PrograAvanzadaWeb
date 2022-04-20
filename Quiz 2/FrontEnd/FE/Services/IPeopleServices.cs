﻿using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IPeopleServices
    {
        void Insert(Person t);
        void Update(Person t);
        void Delete(Person t);
        IEnumerable<Person> GetAll();
        Person GetOneById(int id);
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetOneByIdAsync(int id);
    }
}
