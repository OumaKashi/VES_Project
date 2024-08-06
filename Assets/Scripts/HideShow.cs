using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShow : MonoBehaviour
{
    public GameObject Hausing;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void hide()
    {
        Hausing.SetActive(false);
    }

    public void show()
    {
        Hausing.SetActive(true);
    }
}