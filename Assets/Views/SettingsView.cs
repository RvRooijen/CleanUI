using Controllers;
using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class SettingsView : MonoBehaviour, IView<Settings, SettingsViewModel>
    {
        private SettingsViewModel settingsViewModel;
        
        [SerializeField]
        private TMP_InputField cameraCycleInputField;
        [SerializeField]
        private TMP_InputField gridColumnsInputField;
        [SerializeField]
        private TMP_InputField gridRowsInputField;

        public void AssignViewModel(SettingsViewModel viewModel)
        {
            settingsViewModel = viewModel;
            
            cameraCycleInputField.onValueChanged.AddListener(newValue => settingsViewModel.UpdateValueFromView(nameof(Settings.CameraCycleDelay), float.Parse(newValue)));
            gridColumnsInputField.onValueChanged.AddListener(newValue => settingsViewModel.UpdateValueFromView(nameof(Settings.GridLayoutColumns), int.Parse(newValue)));
            gridRowsInputField.onValueChanged.AddListener(newValue => settingsViewModel.UpdateValueFromView(nameof(Settings.GridLayoutRows), int.Parse(newValue)));
            
            //cameraCycleInputField.onValueChanged.AddListener(newValue => settingsViewModel.CameraCycleDelaySliderValueChanged(int.Parse(newValue)));
            //gridColumnsInputField.onValueChanged.AddListener(newValue => settingsViewModel.GridColumnsInputFieldValueChanged(int.Parse(newValue)));
            //gridRowsInputField.onValueChanged.AddListener(newValue => settingsViewModel.GridRowsInputFieldValueChanged(int.Parse(newValue)));

            void OnCameraCycleDelayChanged(float f)
            {
                cameraCycleInputField.text = $"{f:F0}";
                Debug.Log($"[settingsViewModel.AddObserver<float>] Observed value: {f}");
            }

            settingsViewModel.AddObserver<float>(nameof(Settings.CameraCycleDelay), OnCameraCycleDelayChanged);
            
            //// to remove the observer
            //settingsViewModel.RemoveObserver<float>(nameof(Settings.CameraCycleDelay), OnCameraCycleDelayChanged);
            //// clear all observers
            //settingsViewModel.ClearObservers(nameof(Settings.CameraCycleDelay));
            
            settingsViewModel.AddObserver<int>(nameof(Settings.GridLayoutColumns), i => gridColumnsInputField.text = $"{i}");
            settingsViewModel.AddObserver<int>(nameof(Settings.GridLayoutRows), i => gridRowsInputField.text = $"{i}");
        }

        public void OnUpdateModel(Settings model)
        {
            Debug.Log("A change happened in the model");
        }
    }
}
