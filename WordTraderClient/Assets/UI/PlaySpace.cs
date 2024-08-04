using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class PlaySpace : MonoBehaviour, IDropHandler, IPointerExitHandler
    {
        private HashSet<MagnetObject> played = new HashSet<MagnetObject>();
        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.lastPress)
            {
                MagnetObject magnet = eventData.lastPress.GetComponent<MagnetObject>();
                if (!played.Contains(magnet))
                {
                    played.Add(magnet);
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.lastPress)
            {
                MagnetObject magnet = eventData.lastPress.GetComponent<MagnetObject>();
                if (played.Contains(magnet))
                {
                    played.Remove(magnet);
                }
            }
        }

        public void ClearUsedMagnets()
        {
            foreach (var magnet in played)
            {
               Destroy(magnet); 
            }
            
            played.Clear();
        }
    }
}