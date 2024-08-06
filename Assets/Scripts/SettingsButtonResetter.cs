using System;
using UnityEngine;

public class SettingsButtonResetter : MonoBehaviour
{
    public NewSettingsAnimator settingsAnimator;

    private void OnEnable()
    {
        settingsAnimator.ResetBehaviour();
    }
}