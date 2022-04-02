using System.Collections.Generic;
using Models;
using Views;

namespace Controllers
{
    public class ViewModel<M,VM>
        where M : IModel
        where VM : ViewModel<M, VM>
    {
        protected readonly M Model;
        private readonly List<IView<M, VM>> views = new List<IView<M, VM>>();

        protected ViewModel(M model)
        {
            Model = model;
        }
        
        public void AddView(IView<M, VM> view)
        {
            views.Add(view);
        }
        
        protected void UpdateViews()
        {
            foreach (var view in views)
            {
                view.OnUpdateModel(Model);
            }
        }
    }
}