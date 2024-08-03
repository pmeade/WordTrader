using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

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

    public void ShowInventory()
    {
        // Show inventory UI logic
    }

    public void ShowSettings()
    {
        // Show settings UI logic
    }

    public void UpdateHUD()
    {
        // Update HUD elements
    }
}