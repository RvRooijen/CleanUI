using System.Collections.Generic;
using Models;
using Views;

namespace Controllers
{
    public class SettingsViewModel
    {
        private Settings settings;
        private List<ISettingsView> views;

        public SettingsViewModel(Settings settings)
        {
            this.settings = settings;
        }

        public void AddView(ISettingsView view)
        {
            views.Add(view);
        }
        
        public void GridColumnsInputFieldValueChanged(int value)
        {
            settings.GridLayoutColumns = value;
            UpdateViews();
        }

        public void GridRowsInputFieldValueChanged(int value)
        {
            settings.GridLayoutRows = value;
            UpdateViews();
        }

        public void CameraCycleDelaySliderValueChanged(int value)
        {
            settings.CameraCycleDelay = value;
            UpdateViews();
        }

        private void UpdateViews()
        {
            foreach (ISettingsView view in views)
            {
                view.UpdateSettings(settings);
            }
        }
    }
}
