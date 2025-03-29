using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger
{
    public void SetColor(Cube newCube)
    {
        newCube.Renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
