using System.Collections.Generic;
using Controllers;
using Models;
using UnityEngine;
using Views;

[CreateAssetMenu]
public class UIManager : ScriptableObject
{
    private SettingsViewModel settingsViewModel;
    private SettingsView settingsView;
    
    [SerializeField]
    private GameObject settingsViewPrefab;

    private Canvas canvas;
    public void Initialize(Canvas canvas)
    {
        this.canvas = canvas;
    }
    
    public void CreateSettingsView(Settings settings)
    {
        settingsView = Instantiate(settingsViewPrefab, canvas.transform).GetComponent<SettingsView>();
        settingsViewModel = new SettingsViewModel(settings);
        settingsViewModel.AddView(settingsView);
        settingsView.AssignViewModel(settingsViewModel);
    }
}
