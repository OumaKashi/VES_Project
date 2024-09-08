using System.Collections.Generic;
using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    [SerializeField]
    private List<SelectableRenderer> _listOfRenderes;

    [SerializeField]
    private bool _isMainRenderer;

    [SerializeField]
    private bool _isAutoInitialized;

    private void Awake()
    {
        SetUpChildren();
        SelectionManager.instance.Add(this);
        Initialize();
    }

    private void OnMouseDown()
    {
        SelectionManager.instance.AssignName(this);
        Debug.Log("Mouse On " + gameObject.name);
    }

    public void SetAllMaterials(Material mat)
    {
        foreach (var item in _listOfRenderes)
        {
            item.SetMaterial(mat);
        }
    }

    public void ResetAllMaterials()
    {
        foreach (var item in _listOfRenderes)
        {
            item.ResetMaterial();
        }
    }

    private void Initialize()
    {
        foreach (var item in _listOfRenderes)
        {
            item.Initialize();
        }
    }

    [ContextMenu("Set up children")]
    private void SetUpChildren()
    {
        if (_isAutoInitialized == false) return;
        _listOfRenderes.Clear();
        if (_isMainRenderer)
        {
            var renderer = GetComponent<MeshRenderer>();
            _listOfRenderes.Add(new SelectableRenderer(renderer));
        }
        else
        {
            foreach (Transform child in transform)
            {
                var renderer = child.GetComponent<MeshRenderer>();
                _listOfRenderes.Add(new SelectableRenderer(renderer));
            }
        }
    }
}

[System.Serializable]
public class SelectableRenderer
{
    [SerializeField]
    private MeshRenderer _targetRenderer;

    [SerializeField]
    private Material _initialMaterial;

    public void Initialize()
    {
        _initialMaterial = _targetRenderer.material;
    }

    public void ResetMaterial()
    {
        _targetRenderer.material = _initialMaterial;
    }

    public void SetMaterial(Material currentMat)
    {
        _targetRenderer.material = currentMat;
    }

    public SelectableRenderer(MeshRenderer renderer)
    {
        _targetRenderer = renderer;
        Initialize();
    }
}