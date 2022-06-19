using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    private int score;
    void Start()
    {
        score = SaberScript.GetScore();
        this.GetComponent<Text>().text = "Score achieved : " + score;
    }
}
