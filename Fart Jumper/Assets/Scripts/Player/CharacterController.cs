using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private int score;
    public int Score { get { return score; } set { score = value; } }
    public Rigidbody myBody;
    private Vector3 myForward;

    public float fartPower;
    public float fartPowerMAX;
    public float fartRegulator;

    public bool turnRight;
    public bool turnLeft;

    public bool steadyJump;

    [SerializeField]
    private float turnRate;
    private float lefTurnDuration = 45f;
    private float rightTurnDuration = 45f;

    public bool GodFarts;

    // Use this for initialization
    void Start()
    {
        score = 0;
        fartPower = 100;
        fartPowerMAX = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (fartPower > fartPowerMAX)
        {
            fartPower = fartPowerMAX;
        }

        fartRegulator = fartPower / fartPowerMAX;
        GameObject.Find("FartFuelUI").GetComponent<Image>().fillAmount = fartRegulator;

        //Maybe make this double tap on the screen, and then fly straight up for a cost
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            myForward = gameObject.transform.forward;

            if (fartPower >= 10 || GodFarts)
            {
                if (!GodFarts)
                {
                    fartPower -= 10f;
                }
                myBody.AddForce((myForward * 5) + new Vector3(0, 5, 0), ForceMode.Impulse);

            }
        }

        //This might be fine, dont know if you can just hold a finger on the screen to propel it, needs some testing
        if (Input.GetKey(KeyCode.Space) || steadyJump)
        {
            myForward = gameObject.transform.forward;

            if (fartPower >= 1 || GodFarts)
            {
                if (!GodFarts)
                {
                    fartPower -= 1f;
                }

                myBody.AddForce((myForward * 1f) + new Vector3(0, 0.5f, 0), ForceMode.Impulse);

            }

        }

        if (Input.GetKey(KeyCode.A) || turnLeft)
        {
            gameObject.transform.Rotate(new Vector3(0, -100, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || turnRight)
        {
            gameObject.transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.E) && turnLeft == false)
        {
            turnRight = true;
        }
        if (Input.GetKeyDown(KeyCode.Q) && turnRight == false)
        {
            turnLeft = true;
        }
        if (turnRight)
        {
            TurnRight();
        }
        if (turnLeft)
        {
            TurnLeft();
        }

    }

    private void TurnLeft()
    {
        if (lefTurnDuration <= 45f)
        {
            transform.Rotate(new Vector3(0, -1, 0) * turnRate);
            lefTurnDuration -= 1 * turnRate;
            if (lefTurnDuration <= 0f)
            {
                turnLeft = false;
                lefTurnDuration = 45f;
            }
        }
    }
    private void TurnRight()
    {
        if (rightTurnDuration <= 45f)
        {
            transform.Rotate(new Vector3(0, 1, 0) * turnRate);
            rightTurnDuration -= 1 * turnRate;
            if (rightTurnDuration <= 0f)
            {
                turnRight = false;
                rightTurnDuration = 45f;
            }
        }
    }


    IEnumerator FartMaster()
    {
        GodFarts = true;
        yield return new WaitForSeconds(5);
        GodFarts = false;
    }

    #region InputControls

    public void SteadyJumpEnter()
    {
        steadyJump = true;
    }

    public void SteadyJumpExit()
    {
        steadyJump = false;
    }

    public void TurnRightEnter()
    {
        turnRight = true;
    }

    public void TurnLeftEnter()
    {
        turnLeft = true;
    }

    public void TurnRightExit()
    {
        turnRight = false;
    }

    public void TurnLeftExit()
    {
        turnLeft = false;
    }
    #endregion
}
