using System.Collections.Generic;
using UnityEngine;

public class GhostGameController : MonoBehaviour
{
    private GhostGameLogic _gameLogic;
    private NetworkService _networkService;

    public void Initialize(int totalPlayers)
    {
        _gameLogic = new GhostGameLogic(totalPlayers);
        _networkService = FindObjectOfType<NetworkService>();
    }

    public string GetCurrentWord()
    {
        return _gameLogic.GetCurrentWord();
    }

    public int GetCurrentPlayerIndex()
    {
        return _gameLogic.GetCurrentPlayerIndex();
    }

    public void AddLetter(char letter, System.Action<bool> callback)
    {
        _gameLogic.AddLetter(letter);
        string jsonData = JsonUtility.ToJson(new { letter });
        _networkService.Post("addLetter", jsonData, callback, Debug.LogError);
    }

    public void GetPlayerInventory(int playerIndex, System.Action<List<string>> callback)
    {
        _networkService.Get($"getInventory/{playerIndex}", 
            jsonResponse => 
            {
                List<string> inventory = JsonUtility.FromJson<List<string>>(jsonResponse);
                callback(inventory);
            }, 
            Debug.LogError);
    }

    public void ChallengeWord(int challengerIndex, int challengedIndex, System.Action<bool> callback)
    {
        bool result = _gameLogic.ChallengeWord(challengerIndex, challengedIndex);
        string jsonData = JsonUtility.ToJson(new { challengerIndex, challengedIndex });
        _networkService.Post("challengeWord", jsonData, callback, Debug.LogError);
    }

    public List<string> GetPlayerInventory(int playerIndex)
    {
        return _gameLogic.GetPlayerInventory(playerIndex);
    }

    public void AddLetter(char letter)
    {
        _gameLogic.AddLetter(letter);
    }

    public void NextPlayer()
    {
        _gameLogic.NextPlayer();
    }

    public bool ChallengeWord(int challengerIndex, int challengedIndex)
    {
        return _gameLogic.ChallengeWord(challengerIndex, challengedIndex);
    }
}
