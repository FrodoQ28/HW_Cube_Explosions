using System;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
    public float SplitChance { get; private set; } = 1f;

    public event Action<Cube> ClickDetected;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
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

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}
