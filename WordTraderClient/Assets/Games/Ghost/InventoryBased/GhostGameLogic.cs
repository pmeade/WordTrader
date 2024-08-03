using System.Collections.Generic;

public class WordTile
{
    public string Word { get; private set; }

    public WordTile(string word)
    {
        Word = word;
    }
}

public class GhostGameLogic
{
    private List<WordTile> _wordTiles;
    private string _currentWord;
    private int _currentPlayerIndex;
    private List<string> _playerInventories; // Assuming inventories are strings for simplicity
    private int _totalPlayers;

    public GhostGameLogic(int totalPlayers)
    {
        _totalPlayers = totalPlayers;
        _wordTiles = new List<WordTile>();
        _playerInventories = new List<string>();
        for (int i = 0; i < totalPlayers; i++)
        {
            _playerInventories.Add(""); // Initialize empty inventories
        }
        _currentWord = "";
        _currentPlayerIndex = 0;
    }

    public string GetCurrentWord()
    {
        return _currentWord;
    }

    public int GetCurrentPlayerIndex()
    {
        return _currentPlayerIndex;
    }

    public bool AddLetter(char letter)
    {
        _currentWord += letter;
        return true;
    }

    public bool AddWordTile(int playerIndex, string word)
    {
        // Validate and add the word tile to the player's inventory
        _playerInventories[playerIndex] += word + " ";
        return true;
    }

    public bool ChallengeWord(int challengerIndex, int challengedIndex)
    {
        string inventory = _playerInventories[challengedIndex];
        if (inventory.Contains(_currentWord))
        {
            // Challenged player wins
            AddWordTile(challengerIndex, _currentWord);
            return true;
        }
        else
        {
            // Challenger wins
            AddWordTile(challengedIndex, _currentWord);
            return false;
        }
    }

    public void NextPlayer()
    {
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _totalPlayers;
    }

    public List<string> GetPlayerInventory(int playerIndex)
    {
        return new List<string>(_playerInventories[playerIndex].Split(' '));
    }
}
