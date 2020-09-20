using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class congo : MonoBehaviour
{
    public void congos(){
        SceneManager.LoadScene(0);
    }
    public void quit(){
        Application.Quit();
    }
}
