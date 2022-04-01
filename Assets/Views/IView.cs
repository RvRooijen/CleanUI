using Controllers;
using Models;

namespace Views
{
    public interface IView<T> where T : IModel
    {
        public void AssignViewModel(ViewModel<IView<T>, T> viewModel);
        public void OnUpdateModel(T model);
    }
}