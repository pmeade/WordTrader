using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
    
    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadGameScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void LoadPersistentUI()
    {
        SceneManager.LoadScene("PersistentUIScene", LoadSceneMode.Additive);
    }
    
    public void StartGame()
    {
        // Initialize game start logic
    }

    public void PauseGame()
    {
        // Pause game logic
    }

    public void EndGame()
    {
        // End game logic
    }

    public void UpdateGameState()
    {
        // Update game state logic
    }
}