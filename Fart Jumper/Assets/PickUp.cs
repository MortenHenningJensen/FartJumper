using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField]
    private float fartPowerToAdd;

    [SerializeField]
    private CharacterController player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            player.fartPower += fartPowerToAdd;
            Destroy(gameObject);
        }
    }
}
