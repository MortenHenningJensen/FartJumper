using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PICKUPTYPE { AddPower, PowerMaster }

public class PickUp : MonoBehaviour
{
    [Header("Values to float between")]
    [SerializeField]
    private float maximumYValue;
    [SerializeField]
    private float minimumYValue;
    [SerializeField]
    private float fartPowerToAdd;
    private bool moveUp;
    private bool moveDown;

    public PICKUPTYPE myType;
    private Transform transform;

    private void Start()
    {
        if (minimumYValue == 0 && maximumYValue == 0)
        {
            maximumYValue = 1f;
        }
        transform = GetComponent<Transform>();
        moveUp = true;
    }


    private void Update()
    {
        MoveUpAndDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Player>().fartPower < 100)
            {
                switch (myType)
                {
                    case PICKUPTYPE.AddPower:
                        other.GetComponent<Player>().fartPower += fartPowerToAdd;
                        break;
                    case PICKUPTYPE.PowerMaster:
                        other.GetComponent<Player>().StartCoroutine("FartMaster");
                        break;
                    default:
                        break;
                }


                Destroy(this.gameObject);
            }
        }
    }

    private void MoveUpAndDown()
    {
        if (transform.position.y >= maximumYValue)
        {
            moveDown = true;
            moveUp = false;
        }
        if (transform.position.y <= minimumYValue)
        {
            moveUp = true;
            moveDown = false;
        }
        if (moveUp)
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (moveDown)
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
    }
}
