using Domain.Entities.Base;

using FluentValidation;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        Task Delete(int id);

        Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class;

        Task<TOutputModel> GetByIdAsync<TOutputModel>(int id) where TOutputModel : class;

        Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
