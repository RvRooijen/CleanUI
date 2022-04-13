using System;
using Models;
using Views;

namespace Controllers
{
    public class SettingsViewModel : ViewModel<Settings, SettingsViewModel>
    {
        public SettingsViewModel(Settings model) : base(model)
        {
        }
    }
}
