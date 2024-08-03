using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetObject : MonoBehaviour
{
    // Reference to the Text component
    private Text textComponent;
    public EWordClass WordClass;

    void Start()
    {
        textComponent = GetComponentInParent<Text>();
    }

    public void SetWord(string newText, EWordClass wordClass)
    {
        textComponent.text = newText;
        WordClass = wordClass;
    }

    public float PreferredWidth()
    {
        return textComponent.text.Length * 1;
    }
}
