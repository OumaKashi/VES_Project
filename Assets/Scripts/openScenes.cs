using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openScenes : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void openMainScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void openARappScene()
    {
        SceneManager.LoadScene("TryVES", LoadSceneMode.Single);
    }

    public void openARbookScene()
    {
        SceneManager.LoadScene("ARBookScene2", LoadSceneMode.Single);
    }

    public void openVideoScene()
    {
        SceneManager.LoadScene("3DVideoHomePage", LoadSceneMode.Single);
    }
}