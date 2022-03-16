using AutoMapper;

using Domain.Entities.Base;
using Domain.Interfaces.Repository.Base;
using Domain.Interfaces.Services.Base;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public void Delete(int id) => _baseRepository.DeleteAsync(id);

        public async Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class
        {
            //IList<TEntity> entities = await _baseRepository.Select();
            //IEnumerable<TOutputModel> outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));

            //return outputModels;
            throw new NotImplementedException();

        }

        public async Task<TOutputModel> GetByIdAsync<TOutputModel>(int id) where TOutputModel : class
        {
            //var entity = await _baseRepository.Select(id);
            //var outputModel = _mapper.Map<TOutputModel>(entity);

            //return outputModel;
            throw new NotImplementedException();

        }

        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            //_baseRepository.Insert(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            //_baseRepository.Update(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }

        Task<TOutputModel> IBaseService<TEntity>.Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        Task IBaseService<TEntity>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<TOutputModel> IBaseService<TEntity>.Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
