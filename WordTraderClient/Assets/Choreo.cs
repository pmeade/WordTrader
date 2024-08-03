using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DefaultNamespace;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class Choreo : MonoBehaviour
{
    private List<MagnetObject> magnets = new List<MagnetObject>();
    private PanelManager PanelManager;
    public GameObject PlaySpaceObject;
    private PlaySpace PlaySpace;
    public GameObject HiddenSpaceObject;
    private HiddenSpace HiddenSpace;
        
    // Start is called before the first frame update
    void Start()
    {
        PanelManager = GetComponent<PanelManager>();
        PlaySpace = PlaySpaceObject.GetComponent<PlaySpace>();
        HiddenSpace = HiddenSpaceObject.GetComponent<HiddenSpace>();
        StartRound();
    }

    private void StartRound()
    {
        PlaySpace.ClearUsedMagnets();
        HiddenSpace.Refresh();
    }

    public void Submit()
    {
        StartRound();
    }
}
