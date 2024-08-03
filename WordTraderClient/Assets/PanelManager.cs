using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    // Reference to the Panel prefab
    public GameObject panelPrefab;

    // Reference to the UI container (e.g., a Canvas or a Panel)
    public Transform uiContainer;

    // Method to create a new Panel with Text
    public GameObject CreatePanel(string newText, EWordClass wordClass)
    {
        // Instantiate the Panel prefab
        GameObject newPanel = Instantiate(panelPrefab, uiContainer);

        MagnetObject magnet = newPanel.GetComponent<MagnetObject>();
        magnet.SetWord(newText, wordClass);

        // Adjust the width of the panel based on the text length
        AdjustPanelWidth(newPanel, magnet, newText);

        return newPanel;
    }

    // Method to adjust the width of the Panel based on the Text length
    private void AdjustPanelWidth(GameObject panel, MagnetObject magnet, string newText)
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        if (panelRectTransform != null)
        {
            // Set the width of the panel based on the preferred width of the text
            panelRectTransform.sizeDelta = new Vector2(magnet.PreferredWidth(), panelRectTransform.sizeDelta.y);
            // Adjust 20 as padding or any other value that suits your design
        }
        else
        {
            Debug.LogError("RectTransform component not found on the Panel!");
        }
    }

    public void ClearPanels()
    {
    }
}