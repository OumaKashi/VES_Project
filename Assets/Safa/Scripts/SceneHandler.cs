using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ArScene()
    {
        SceneManager.LoadScene("ARBookScene2");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}