using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FartFuelUI : MonoBehaviour {

    [SerializeField]
    private Player player;
    [SerializeField]
    private Text fartPower;

    void Update()
    {
        fartPower.text = string.Format("Fart fuel: {0}", player.fartPower);
    }
}
