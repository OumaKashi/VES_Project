using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public Material initialMaterial;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        initialMaterial = meshRenderer.material;
        SelectionManager.instance.Add(this);
    }

    private void OnMouseDown()
    {
        SelectionManager.instance.OnSelect.Invoke(this);
    }
}