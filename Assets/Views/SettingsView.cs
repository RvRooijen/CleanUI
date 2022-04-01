using Controllers;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Views
{
    /// <summary>
    /// Unity view, register yourself to the ViewModel
    /// </summary>
    public class SettingsView : MonoBehaviour, IView<Settings>
    {
        private SettingsViewModel settingsViewModel;
        
        [SerializeField]
        private TMP_InputField cameraCycleInputField;
        [SerializeField]
        private TMP_InputField gridColumnsInputField;
        [SerializeField]
        private TMP_InputField gridRowsInputField;

        public void AssignViewModel(ViewModel<IView<Settings>, Settings> viewModel)
        {
            settingsViewModel = viewModel as SettingsViewModel;
            
            cameraCycleInputField.onValueChanged.AddListener(newValue => settingsViewModel.CameraCycleDelaySliderValueChanged(int.Parse(newValue)));
            gridColumnsInputField.onValueChanged.AddListener(newValue => settingsViewModel.GridColumnsInputFieldValueChanged(int.Parse(newValue)));
            gridRowsInputField.onValueChanged.AddListener(newValue => settingsViewModel.GridRowsInputFieldValueChanged(int.Parse(newValue)));
        }

        public void OnUpdateModel(Settings model)
        {
            
        }
    }
}
