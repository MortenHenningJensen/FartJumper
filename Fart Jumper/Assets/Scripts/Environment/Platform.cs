using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private int scoreToAdd = 1;
    private bool hitByPlayer;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && !hitByPlayer)
        {
            hitByPlayer = true;
            player.Score += scoreToAdd;
        }
    }
}
