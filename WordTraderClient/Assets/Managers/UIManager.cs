using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject inventoryPanel;
    public GameObject settingsPanel;
    public GameObject hudPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        settingsPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        settingsPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        settingsPanel.SetActive(true);
        hudPanel.SetActive(false);
    }

    public void ShowHUD()
    {
        mainMenuPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        settingsPanel.SetActive(false);
        hudPanel.SetActive(true);
    }

    public void UpdateHUD()
    {
        // Update HUD elements
    }
}