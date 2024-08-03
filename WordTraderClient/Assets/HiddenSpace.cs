using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class HiddenSpace : MonoBehaviour, IDropHandler, IPointerExitHandler
    {
        public GameObject ServiceLayer;

        private PanelManager PanelManager;
        private Inventory Inventory;
        
        public void Start()
        {
            PanelManager = ServiceLayer.GetComponent<PanelManager>();
            Inventory = ServiceLayer.GetComponent<Inventory>();
        }

        public void Refresh()
        {
            Inventory.Refill();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.lastPress)
            {
                MagnetObject magnet = eventData.lastPress.GetComponent<MagnetObject>();
                Inventory.Add(magnet);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}