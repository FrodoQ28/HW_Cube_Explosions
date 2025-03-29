using System;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody), typeof(Cube))]

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public Renderer Renderer => GetComponent<Renderer>();
    public Rigidbody Rigidbody => _rigidbody;
    public float SplitChance { get; private set; } = 1f;

    public event Action<Cube> ClickDetected;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        ClickDetected?.Invoke(this);
    }

    public void SetSplitChance(float splitChance)
    {
        SplitChance = splitChance;
    }
}
