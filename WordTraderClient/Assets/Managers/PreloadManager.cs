using UnityEngine;

public class PreloadManager : MonoBehaviour
{
    public GameObject managersPrefab; // Prefab containing all managers

    private void Awake()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            Instantiate(managersPrefab);
        }
        
        // Load persistent UI
        GameManager.Instance.LoadPersistentUI();
        
        // Load main menu scene
        GameManager.Instance.LoadGameScene("MainMenuScene");
    }
}