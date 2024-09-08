using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject turbineParent;
    public GameObject constructionButton;
    public GameObject interactionButton;
    public GameObject Container;
    public GameObject Back;

    public void OnInteractionButtonClicked()
    {
        constructionButton.SetActive(true);
        interactionButton.SetActive(true);
    }

    public void OnConstructionButtonClicked()
    {
        turbineParent.SetActive(false);
        constructionButton.SetActive(false);
        interactionButton.SetActive(false);

        Container.SetActive(true);
        Back.SetActive(true);

        // Hide the buttons if needed
        //constructionButton.SetActive(false);
        //interactionButton.SetActive(false);
    }
}