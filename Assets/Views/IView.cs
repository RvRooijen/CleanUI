using Controllers;
using Models;

namespace Views
{
    public interface IView<T, VM> where T : IModel where VM : ViewModel<T, VM>
    {
        public void AssignViewModel(VM viewModel);
        public void OnUpdateModel(T model);
    }
}