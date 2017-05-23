using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private int scoreToAdd = 1;
    [SerializeField]
    private float maximumYValue;
    [SerializeField]
    private float minimumYValue;


    private bool hitByPlayer;
    private bool moveUp;
    private bool moveDown;

    public void Start()
    {
        moveUp = true;
    }

    public void Update()
    {
        MoveUpAndDown();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && !hitByPlayer)
        {
            hitByPlayer = true;
            player.Score += scoreToAdd;
        }
    }

    private void MoveUpAndDown()
    {
        if (gameObject.transform.position.y >= maximumYValue)
        {
            moveDown = true;
            moveUp = false;
        }
        if (gameObject.transform.position.y <= minimumYValue)
        {
            moveUp = true;
            moveDown = false;
        }
        if (moveUp)
        {
            gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (moveDown)
        {
            gameObject.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
    }
}
