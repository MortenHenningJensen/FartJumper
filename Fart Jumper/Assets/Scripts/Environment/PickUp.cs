using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PICKUPTYPE { AddPower, PowerMaster}

public class PickUpTakeTwo : MonoBehaviour {

    public PICKUPTYPE myType;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<CharacterController>().fartPower < 100)
            {
                switch (myType)
                {
                    case PICKUPTYPE.AddPower:
                        other.GetComponent<CharacterController>().fartPower += 20;
                        break;
                    case PICKUPTYPE.PowerMaster:
                        other.GetComponent<CharacterController>().StartCoroutine("FartMaster");
                        break;
                    default:
                        break;
                }

                
                Destroy(this.gameObject);
            } 
        }
    }
}
