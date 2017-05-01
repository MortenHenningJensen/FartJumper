using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public Rigidbody myBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myBody.AddForce(5, 5, 0, ForceMode.Impulse);
        }
	}
}
