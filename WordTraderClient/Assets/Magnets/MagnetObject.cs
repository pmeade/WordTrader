using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the properties and behavior of magnet objects.
/// </summary>
public class MagnetObject : MonoBehaviour
{
    private Text textComponent;
    public EWordClass WordClass;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        textComponent = GetComponentInParent<Text>();
    }

    /// <summary>
    /// Sets the text and word class for the magnet.
    /// </summary>
    /// <param name="newText">The new text for the magnet.</param>
    /// <param name="wordClass">The word class of the magnet.</param>
    public void SetWord(string newText, EWordClass wordClass)
    {
        textComponent.text = newText;
        WordClass = wordClass;
    }

    /// <summary>
    /// Calculates the preferred width based on text length.
    /// </summary>
    /// <returns>The preferred width of the magnet.</returns>
    public float PreferredWidth()
    {
        return textComponent.text.Length * 1;
    }
}