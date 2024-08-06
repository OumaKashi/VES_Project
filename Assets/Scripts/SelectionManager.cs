using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;
    public Action<SelectableItem> OnSelect;

    public Material selectionMaterial;

    [SerializeField]
    private GameObject _descriptionCanvas;

    [SerializeField]
    private TextMeshProUGUI _nameTMP;

    [SerializeField]
    private List<SelectableItem> listOfSelectableItems;

    public bool IsCanvasActive => _descriptionCanvas.activeInHierarchy;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        OnSelect += AssignName;
    }

    private void OnDisable()
    {
        OnSelect -= AssignName;
    }

    private void AssignName(SelectableItem selectableItem)
    {
        if (IsCanvasActive == false)
        {
            return;
        }
        foreach (var item in listOfSelectableItems)
        {
            var isThisSelected = selectableItem == item;
            var currentMaterial = item.initialMaterial;
            if (isThisSelected == true)
            {
                currentMaterial = selectionMaterial;
            }
            item.meshRenderer.material = currentMaterial;
        }

        _nameTMP.text = selectableItem.name;
    }

    public void Add(SelectableItem selectableItem)
    {
        listOfSelectableItems.Add(selectableItem);
    }

    public void DeselectItems()
    {
        foreach (var item in listOfSelectableItems)
        {
            item.meshRenderer.material = item.initialMaterial;
        }
        _nameTMP.text = string.Empty;
    }
}