using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Easy()
    {
        SceneManager.LoadScene("EasyScene");
    }

    public void Medium()
    {
        SceneManager.LoadScene("MediumScene");
    }

    public void Hard()
    {
        SceneManager.LoadScene("HardScene");
    }

    public void Array()
    {
        SceneManager.LoadScene("ArrayScene");
    }
}
