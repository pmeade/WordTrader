using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    
    [Serializable]
    public class WordClassAllotment
    {
        public EWordClass wordClass;
        public int allotment;
    }
    
    public class Inventory : MonoBehaviour
    {
        private Dictionary<EWordClass, List<GameObject>> Magnets = new Dictionary<EWordClass, List<GameObject>>();
        private Dictionary<EWordClass, int> Allotments = new Dictionary<EWordClass, int>();
        public List<WordClassAllotment> AllotmentList = new List<WordClassAllotment>();
        private PanelManager PanelManager;
        private Vocabulary Vocabulary;

        private void Start()
        {
            Vocabulary = GetComponent<Vocabulary>();
            PanelManager = GetComponent<PanelManager>();
            Allotments = GetAllotmentsDictionary();

            Magnets[EWordClass.Common] = new List<GameObject>();
            Magnets[EWordClass.Short] = new List<GameObject>();
            Magnets[EWordClass.Full] = new List<GameObject>();
            Magnets[EWordClass.Uncommon] = new List<GameObject>();
        }
        
        private Dictionary<EWordClass, int> GetAllotmentsDictionary()
        {
            Dictionary<EWordClass, int> dict = new Dictionary<EWordClass, int>();
            foreach (var item in AllotmentList)
            {
                dict[item.wordClass] = item.allotment;
            }
            return dict;
        }

        public void Refill()
        {
            foreach (KeyValuePair<EWordClass,int> allotment in Allotments)
            {
                while (Magnets[allotment.Key].Count < allotment.Value)
                {
                    Magnets[allotment.Key].Add(PanelManager.CreatePanel(Vocabulary.Next(allotment.Key), allotment.Key));
                }
            }
        }

        public void Replace()
        {
            Magnets.Clear();
            Refill();
        }

        public void Add(MagnetObject magnet)
        {
            Magnets[magnet.WordClass].Add(magnet.gameObject);
        }
    }

}