using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

    string levelToEnterName;

    public void LevelSelected(string enterWorld)
    {
        Application.LoadLevel(enterWorld);
    }
}
