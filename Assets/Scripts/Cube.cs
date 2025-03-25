using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;

    public float SplitChance => _splitChance;

    public static event Action<GameObject> ClickDetected;

    public void SetSplitChance(float splitChance)
    {
        _splitChance = splitChance;
    }

    private void OnMouseDown()
    {
        ClickDetected?.Invoke(transform.gameObject);
    }
}
