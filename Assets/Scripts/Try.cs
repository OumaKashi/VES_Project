using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour
{
    private void OnMouseDown()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
    }
}