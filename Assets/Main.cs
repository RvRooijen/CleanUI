using Models;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Canvas mainCanvas;
    
    private void Awake()
    {
        Settings settings = new Settings();
        
        uiManager.Initialize(mainCanvas);
        uiManager.CreateSettingsView(settings);
    }
}
