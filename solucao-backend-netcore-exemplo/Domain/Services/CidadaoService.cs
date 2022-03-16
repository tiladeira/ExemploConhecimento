using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using Domain.Interfaces.Services;

using FluentValidation;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CidadaoService : ICidadaoService
    {
        private readonly IBaseRepository<CidadaoEntity> _repository;

        public CidadaoService(IBaseRepository<CidadaoEntity> repository)
        {
            _repository = repository;
        }

        public Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<CidadaoEntity>
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class
        {
            throw new System.NotImplementedException();
        }

        public Task<TOutputModel> GetByIdAsync<TOutputModel>(int id) where TOutputModel : class
        {
            throw new System.NotImplementedException();
        }

        public Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<CidadaoEntity>
        {
            throw new System.NotImplementedException();
        }
    }
}
