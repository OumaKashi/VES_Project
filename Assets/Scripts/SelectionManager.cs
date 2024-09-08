using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;

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

    public void AssignName(SelectableItem selectableItem)
    {
        if (IsCanvasActive == false)
        {
            return;
        }
        foreach (var item in listOfSelectableItems)
        {
            var isThisSelected = selectableItem == item;
            if (isThisSelected == true)
            {
                item.SetAllMaterials(selectionMaterial);
            }
            else
            {
                item.ResetAllMaterials();
            }
        }

        _nameTMP.text = selectableItem.name;
    }

    public void Add(SelectableItem selectableItem)
    {
        listOfSelectableItems.Add(selectableItem);
    }

    public void AssignNullSelectable()
    {
        foreach (var item in listOfSelectableItems)
        {
            item.ResetAllMaterials();
        }
    }
}