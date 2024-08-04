using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the creation and adjustment of UI panels.
/// </summary>
public class PanelManager : MonoBehaviour
{
    public GameObject panelPrefab;
    public Transform uiContainer;

    /// <summary>
    /// Creates a new panel with specified text and word class.
    /// </summary>
    /// <param name="newText">The text for the new panel.</param>
    /// <param name="wordClass">The word class of the panel.</param>
    /// <returns>The created panel GameObject.</returns>
    public GameObject CreatePanel(string newText, EWordClass wordClass)
    {
        GameObject newPanel = Instantiate(panelPrefab, uiContainer);

        MagnetObject magnet = newPanel.GetComponent<MagnetObject>();
        magnet.SetWord(newText, wordClass);

        AdjustPanelWidth(newPanel, magnet);

        return newPanel;
    }

    /// <summary>
    /// Adjusts the width of the panel based on text length.
    /// </summary>
    /// <param name="panel">The panel GameObject.</param>
    /// <param name="magnet">The MagnetObject component.</param>
    private void AdjustPanelWidth(GameObject panel, MagnetObject magnet)
    {
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        if (panelRectTransform != null)
        {
            panelRectTransform.sizeDelta = new Vector2(magnet.PreferredWidth(), panelRectTransform.sizeDelta.y);
        }
        else
        {
            Debug.LogError("RectTransform component not found on the Panel!");
        }
    }

    /// <summary>
    /// Clears all panels (placeholder).
    /// </summary>
    public void ClearPanels()
    {
        // Implement panel clearing logic if needed
    }
}