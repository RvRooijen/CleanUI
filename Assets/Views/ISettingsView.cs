using Controllers;
using Models;

namespace Views
{
    public interface ISettingsView
    {
        public void AssignViewModel(SettingsViewModel settingsViewModel);
        public void UpdateSettings(Settings settings);
    }
}