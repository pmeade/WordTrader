using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Represents a word class allotment.
    /// </summary>
    [Serializable]
    public class WordClassAllotment
    {
        public EWordClass wordClass;
        public int allotment;
    }

    /// <summary>
    /// Manages the player's inventory of word magnets.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        private Dictionary<EWordClass, List<GameObject>> magnets = new Dictionary<EWordClass, List<GameObject>>();
        private Dictionary<EWordClass, int> allotments = new Dictionary<EWordClass, int>();
        public List<WordClassAllotment> allotmentList = new List<WordClassAllotment>();
        private PanelManager panelManager;
        private Vocabulary vocabulary;

        /// <summary>
        /// Start is called before the first frame update.
        /// </summary>
        private void Start()
        {
            vocabulary = GetComponent<Vocabulary>();
            panelManager = GetComponent<PanelManager>();
            allotments = GetAllotmentsDictionary();

            foreach (EWordClass wordClass in Enum.GetValues(typeof(EWordClass)))
            {
                magnets[wordClass] = new List<GameObject>();
            }
        }
        
        /// <summary>
        /// Converts the allotment list to a dictionary.
        /// </summary>
        /// <returns>A dictionary of word class allotments.</returns>
        private Dictionary<EWordClass, int> GetAllotmentsDictionary()
        {
            Dictionary<EWordClass, int> dict = new Dictionary<EWordClass, int>();
            foreach (var item in allotmentList)
            {
                dict[item.wordClass] = item.allotment;
            }
            return dict;
        }

        /// <summary>
        /// Refills the magnets to meet the allotment requirements.
        /// </summary>
        public void Refill()
        {
            foreach (KeyValuePair<EWordClass, int> allotment in allotments)
            {
                while (magnets[allotment.Key].Count < allotment.Value)
                {
                    magnets[allotment.Key].Add(panelManager.CreatePanel(vocabulary.Next(allotment.Key), allotment.Key));
                }
            }
        }

        /// <summary>
        /// Clears and refills the magnets.
        /// </summary>
        public void Replace()
        {
            magnets.Clear();
            Refill();
        }

        /// <summary>
        /// Adds a magnet to the inventory.
        /// </summary>
        /// <param name="magnet">The magnet object to add.</param>
        public void Add(MagnetObject magnet)
        {
            magnets[magnet.WordClass].Add(magnet.gameObject);
        }
    }
}
