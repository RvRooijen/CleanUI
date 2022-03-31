using Controllers;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Views
{
    public class SettingsView : MonoBehaviour, ISettingsView
    {
        private SettingsViewModel settingsViewModel;
    
        [SerializeField]
        private TMP_InputField cameraCycleInputField;
        [SerializeField]
        private TMP_InputField gridColumnsInputField;
        [SerializeField]
        private TMP_InputField gridRowsInputField;
        
        public void AssignViewModel(SettingsViewModel settingsViewModel)
        {
            this.settingsViewModel = settingsViewModel;
            
            cameraCycleInputField.onValueChanged.AddListener(newValue => this.settingsViewModel.CameraCycleDelaySliderValueChanged(int.Parse(newValue)));
            gridColumnsInputField.onValueChanged.AddListener(newValue => this.settingsViewModel.GridColumnsInputFieldValueChanged(int.Parse(newValue)));
            gridRowsInputField.onValueChanged.AddListener(newValue => this.settingsViewModel.GridRowsInputFieldValueChanged(int.Parse(newValue)));
        }

        public void UpdateSettings(Settings settings)
        {
            
        }
    }
}
