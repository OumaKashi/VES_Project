using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    public GameObject canvasToOpen;
    public GameObject canvasToClose;

    public void OpenClose()
    {
        canvasToClose.SetActive(false);
        canvasToOpen.SetActive(true);
    }
}