using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject changeScore;
    public static int scorec = 0;
    void Update() {
        changeScore.GetComponent<Text>().text = "X " + scorec;
    }
    public void ResetS() {
        scorec = 0;
        changeScore.GetComponent<Text>().text = "X 0";
    }
}
