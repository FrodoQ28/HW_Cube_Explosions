using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer
{
    public static void GetColor(GameObject newCube)
    {
        newCube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}