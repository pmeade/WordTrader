using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    /// <summary>
    /// Manages interactions with the hidden space area.
    /// </summary>
    public class HiddenSpace : MonoBehaviour, IDropHandler
    {
        public GameObject ServiceLayer;

        private PanelManager panelManager;
        private Inventory inventory;
        
        /// <summary>
        /// Start is called before the first frame update.
        /// </summary>
        public void Start()
        {
            panelManager = ServiceLayer.GetComponent<PanelManager>();
            inventory = ServiceLayer.GetComponent<Inventory>();
        }

        /// <summary>
        /// Refreshes the hidden space.
        /// </summary>
        public void Refresh()
        {
            inventory.Refill();
        }

        /// <summary>
        /// Handles drop events, adding the dropped MagnetObject to the Inventory.
        /// </summary>
        /// <param name="eventData">Current event data.</param>
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.lastPress)
            {
                MagnetObject magnet = eventData.lastPress.GetComponent<MagnetObject>();
                inventory.Add(magnet);
            }
        }
    }
}