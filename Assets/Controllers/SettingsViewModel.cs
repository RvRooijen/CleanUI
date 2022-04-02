using Models;
using Views;

namespace Controllers
{
    public class SettingsViewModel : ViewModel<Settings, SettingsViewModel>
    {
        public SettingsViewModel(Settings model) : base(model)
        {
        }
        
        public void GridColumnsInputFieldValueChanged(int value)
        {
            Model.GridLayoutColumns = value;
            UpdateViews();
        }

        public void GridRowsInputFieldValueChanged(int value)
        {
            Model.GridLayoutRows = value;
            UpdateViews();
        }

        public void CameraCycleDelaySliderValueChanged(int value)
        {
            Model.CameraCycleDelay = value;
            UpdateViews();
        }
    }
}
