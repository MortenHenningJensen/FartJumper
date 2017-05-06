using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;
    [SerializeField]
    private int scoreToAdd = 1;
    private bool hitByPlayer;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() && !hitByPlayer)
        {
            hitByPlayer = true;
            player.Score += scoreToAdd;
        }
    }
}
