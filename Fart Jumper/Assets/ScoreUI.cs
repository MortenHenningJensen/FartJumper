using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{

    [SerializeField]
    private CharacterController player;
    [SerializeField]
    private Text score;

    void Update()
    {
        score.text = string.Format("Score: {0}", player.Score);
    }
}
