using UnityEngine;
using UnityEngine.Events;

public class OnDeactivateEmitter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnDeactive;

    private void OnDisable()
    {
        OnDeactive.Invoke();
    }
}