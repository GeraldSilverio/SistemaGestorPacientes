using System.Linq.Expressions;

namespace GestorDePacientes.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where Model : class
        where ViewModel : class
    {
        Task Update(SaveViewModel viewModel, int id);
        Task<SaveViewModel> Add(SaveViewModel viewModel);
        Task Delete(int id);
        Task<SaveViewModel> GetById(int id);
        Task<List<ViewModel>> GetAll();
        bool Any(Expression<Func<Model, bool>> predicate);
    }
}
