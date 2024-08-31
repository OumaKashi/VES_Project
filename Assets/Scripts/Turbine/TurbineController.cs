using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurbineController : MonoBehaviour
{
    private Button _btn;

    [SerializeField]
    private List<Transform> _listOfRotatingParts;

    [SerializeField] private List<Animator> _listOfAnimators;

    [SerializeField] private bool _isMoving = false;
    [SerializeField] private List<float> _listOfRotationSpeeds;
    [SerializeField] private ParticleSystem _grainParticleSystem;
    private int _currentRotationIndex;

    private float CurrentRotation => _listOfRotationSpeeds[_currentRotationIndex];

    private void Awake()
    {
        _btn = GetComponent<Button>();
    }

    private void RotateParts()
    {
        if (_isMoving)
        {
            foreach (var item in _listOfRotatingParts)
            {
                item.eulerAngles += new Vector3(0, -CurrentRotation, 0) * Time.deltaTime;
            }
        }
    }

    private void Update()
    {
        RotateParts();
    }

    private void Simulate()
    {
        ActivateAnimators(_isMoving);

        _isMoving = !_isMoving;
        // Set the two gameObjects of the foam and the water shape to _isMoving
        if (_isMoving == true)
        {
            _grainParticleSystem.Play();
        }
        else
        {
            _grainParticleSystem.Stop();
        }
    }

    private void OnEnable()
    {
        _btn.onClick.AddListener(Simulate);
    }

    private void OnDisable()
    {
        _btn.onClick.RemoveListener(Simulate);
    }

    private void ActivateAnimators(bool isActive)
    {
        foreach (var item in _listOfAnimators)
        {
            item.enabled = isActive;
        }
    }

    private void SetRotationLevel(int index)
    {
        _currentRotationIndex = index;
    }

    [ContextMenu("Set Level 1")]
    public void SetRotationLevel1() => SetRotationLevel(0);

    [ContextMenu("Set Level 2")]
    public void SetRotationLevel2() => SetRotationLevel(1);

    [ContextMenu("Set Level 3")]
    public void SetRotationLevel3() => SetRotationLevel(2);
}