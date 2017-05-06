using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

    public float timer;
    public Text _txtTimer;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        _txtTimer.text = niceTime;
    }

}
