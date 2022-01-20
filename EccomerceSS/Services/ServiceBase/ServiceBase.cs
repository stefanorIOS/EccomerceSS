using EccomerceSS.Models;
using EccomerceSS.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EccomerceSS.Services.ServiceBase
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseClass
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> DeleteEntity(T entity)
        {
            try
            {
                await _repository.DeleteEntity(entity);
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> getAllAsync()
        {
            try
            {
                return await _repository.getAllAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> getById(int id)
        {
            try
            {
                return await _repository.getById(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task SaveEntity(T entity)
        {
            try
            {
                await _repository.SaveEntity(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
