using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GhostGameUI : MonoBehaviour
{
    public GameObject playerWidgetPrefab;
    public Transform playerWidgetsContainer;
    public Text currentWordText;
    public InputField inputField;
    public Dropdown wordDropdown;
    public Button addLetterButton;
    public Button challengeButton;

    private GhostGameController _gameController;
    private List<GameObject> _playerWidgets;

    private void Start()
    {
        _gameController = FindObjectOfType<GhostGameController>();
        _gameController.Initialize(4); // Example with 4 players
        _playerWidgets = new List<GameObject>();
        InitializePlayerWidgets(4);
        UpdateUI();
    }

    private void InitializePlayerWidgets(int totalPlayers)
    {
        for (int i = 0; i < totalPlayers; i++)
        {
            GameObject playerWidget = Instantiate(playerWidgetPrefab, playerWidgetsContainer);
            playerWidget.GetComponentInChildren<Text>().text = $"Player {i + 1}";
            _playerWidgets.Add(playerWidget);
        }
    }

    private void UpdateUI()
    {
        currentWordText.text = _gameController.GetCurrentWord();
        int currentPlayerIndex = _gameController.GetCurrentPlayerIndex();
        for (int i = 0; i < _playerWidgets.Count; i++)
        {
            _playerWidgets[i].GetComponent<Image>().color = i == currentPlayerIndex ? Color.green : Color.white;
        }
        UpdateWordDropdown(currentPlayerIndex);
    }

    private void UpdateWordDropdown(int playerIndex)
    {
        _gameController.GetPlayerInventory(playerIndex, inventory => 
        {
            wordDropdown.ClearOptions();
            wordDropdown.AddOptions(inventory);
        });
    }

    public void OnAddLetterButtonClicked()
    {
        string selectedWord = wordDropdown.options[wordDropdown.value].text;
        char nextLetter = selectedWord[_gameController.GetCurrentWord().Length];
        _gameController.AddLetter(nextLetter, success => 
        {
            if (success)
            {
                _gameController.NextPlayer();
                UpdateUI();
            }
            else
            {
                Debug.LogError("Failed to add letter.");
            }
        });
    }

    public void OnChallengeButtonClicked()
    {
        int currentPlayerIndex = _gameController.GetCurrentPlayerIndex();
        int challengedPlayerIndex = (currentPlayerIndex - 1 + _playerWidgets.Count) % _playerWidgets.Count;
        _gameController.ChallengeWord(currentPlayerIndex, challengedPlayerIndex, result =>
        {
            Debug.Log(result ? "Challenge successful!" : "Challenge failed!");
            UpdateUI();
        });
    }
}
