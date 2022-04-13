using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private readonly Dictionary<string, List<IGenObserver>> observers = new Dictionary<string, List<IGenObserver>>();
        private readonly Dictionary<string, IExpressionStore> memberCache = new Dictionary<string, IExpressionStore>();

        protected ViewModel(M model)
        {
            Model = model;
        }
        
        public void AddView(IView<M, VM> view)
        {
            views.Add(view);
        }
        
        public void UpdateValueFromView<T>(string name, T value)
        {
            if (!memberCache.TryGetValue(name, out IExpressionStore setter))
            {
                var parameterExpression = Expression.Parameter(typeof(M), name);
                var memberExpression = Expression.PropertyOrField(parameterExpression, name);
                ParameterExpression valueExp = Expression.Parameter(memberExpression.Type, "value");
                BinaryExpression assignExp = Expression.Assign(memberExpression, valueExp);
                var lambda = Expression.Lambda<Action<M, T>>(assignExp, parameterExpression, valueExp);
                memberCache.Add(name, setter = new ExpressionStore<M, T>(lambda.Compile()));
            }
                
            setter.Invoke(Model, value);

            if (observers.TryGetValue(name, out var list))
            {
                for (var index = 0; index < list.Count; index++)
                {
                    IGenObserver observer = list[index];
                    observer.Invoke(value);
                }
            }

            foreach (var view in views)
            {
                view.OnUpdateModel(Model);
            }
        }
        
        /// <summary>
        /// TODO: This function should invoke observers, and the UpdateValueFromView shouldn't invoke observers
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void UpdateValueFromModel<T>(string name, T value) => UpdateValueFromView(name, value);

        public void AddObserver<T>(string observeName, Action<T> func)
        {
            if (observers.TryGetValue(observeName, out var list))
            {
                list.Add(new GenObserver<T>(func));
            }
            else
            {
                observers.Add(observeName, list = new List<IGenObserver>());
                list.Add(new GenObserver<T>(func));
            }
        }

        public void RemoveObserver<T>(string observeName, Action<T> func)
        {
            if (observers.TryGetValue(observeName, out var list))
            {
                list.Remove(new GenObserver<T>(func));
            }
        }

        public bool ClearObservers(string observeName)
        {
            if (observers.TryGetValue(observeName, out var list) && list.Count > 0)
            {
                list.Clear();
                return true;
            }
            return false;
        }

    }
}