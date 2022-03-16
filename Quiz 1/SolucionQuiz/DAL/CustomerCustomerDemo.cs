﻿using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.EF;
using DAL.Repository;
using DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace DAL
{


    public class CustomerCustomerDemo : ICRUD<data.CustomerCustomerDemo>
    {
        private RepositoryCustomerCustomerDemo repo;
        public CustomerCustomerDemo(NDbContext dbContext)
        {
            repo = new RepositoryCustomerCustomerDemo(dbContext);
        }
        public void Delete(data.CustomerCustomerDemo t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.CustomerCustomerDemo> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.CustomerCustomerDemo>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.CustomerCustomerDemo GetOneById(string id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.CustomerCustomerDemo> GetOneByIdAsync(string id)
        {
            return null;
        }
        public Task<data.CustomerCustomerDemo> GetOneByIdAsync(string CustomerId, string CustomerTypeId)
        {
            return repo.GetOneByIdAsync(CustomerId,CustomerTypeId);
        }

        public void Insert(data.CustomerCustomerDemo t)
        {
            try
            {
                repo.Insert(t);
                repo.Commit();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Update(data.CustomerCustomerDemo t)
        {
            try
            {
                repo.Update(t);
                repo.Commit();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
