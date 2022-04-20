﻿using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IEnrollmentsServices
    {
        void Insert(Enrollment t);
        void Update(Enrollment t);
        void Delete(Enrollment t);
        IEnumerable<Enrollment> GetAll();
        Enrollment GetOneById(int id);
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment> GetOneByIdAsync(int id);
    }
}
