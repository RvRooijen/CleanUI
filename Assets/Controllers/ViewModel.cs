using System.Collections.Generic;
using Models;
using Views;

namespace Controllers
{
    public class ViewModel<V,M> 
        where V : IView<M> 
        where M : IModel
    {
        protected readonly M Model;
        private readonly List<V> views = new List<V>();

        protected ViewModel(M model)
        {
            Model = model;
        }
        
        public void AddView(V view)
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