using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewSettingsAnimator : MonoBehaviour
{
    [Header("UI Details")]
    [SerializeField]
    private Button _mainButton;

    [SerializeField]
    private VerticalLayoutGroup verticalLayout;

    private bool toggle = false;

    [Header("Animation Details")]
    [SerializeField]
    private float initialSpacing;

    [SerializeField]
    private float targetSpacing;

    [SerializeField]
    private float animationDuration;

    private void OnEnable()
    {
        _mainButton.onClick.AddListener(Animate);
    }

    public void ResetBehaviour()
    {
        toggle = false;
        verticalLayout.spacing = initialSpacing;
    }

    private void OnDisable()
    {
        _mainButton.onClick.RemoveListener(Animate);
    }

    private void Animate()
    {
        toggle = !toggle;
        var spacing = 0f;
        if (toggle == true)
        {
            spacing = targetSpacing;
        }
        else
        {
            spacing = initialSpacing;
        }
        DOVirtual.Float(verticalLayout.spacing, spacing, animationDuration, (val) => verticalLayout.spacing = val);
    }
}