using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private ColorChanger _colorChanger;
    private List<Cube> _allCubes;
    private Exploder _exploder;

    private void Awake()
    {
        _exploder = new Exploder();
        _colorChanger = new ColorChanger();
        _allCubes = new List<Cube>();

        SpawnFirstCubes();
    }

    private void OnDisable()
    {
        foreach (var cube in _allCubes)
            cube.ClickDetected -= SplitCube;
    }

    private void SplitCube(Cube selectedCube)
    {
        float reductionMultiplier = 0.5f;
        Vector3 originalScale = selectedCube.transform.localScale;
        Vector3 newScale = originalScale * reductionMultiplier;
        float originalSplitChance = selectedCube.SplitChance;

        if (TrySplit(originalSplitChance, out int numberOfSeparations))
        {
            for (int i = 0; i < numberOfSeparations; i++)
            {
                Cube newCube = Instantiate(selectedCube, selectedCube.transform.position, Quaternion.identity);

                newCube.transform.localScale = newScale;
                newCube.Rigidbody.useGravity = true;

                newCube.SetSplitChance(originalSplitChance * reductionMultiplier);

                newCube.ClickDetected += SplitCube;

                _colorChanger.SetColor(newCube);
                _exploder.Explosion(newCube);

                _allCubes.Add(newCube);
            }

            _allCubes.Remove(selectedCube);

            Destroy(selectedCube.gameObject);
        }
        else
        {
            _allCubes.Remove(selectedCube);

            Destroy(selectedCube.gameObject);
        }
    }

    public bool TrySplit(float splitChance, out int numberOfSeparations)
    {
        int s_minCubeCount = 2;
        int s_maxCubeCount = 7;

        if (Random.value <= splitChance)
        {
            numberOfSeparations = Random.Range(s_minCubeCount, s_maxCubeCount);

            return true;
        }
        else
        {
            numberOfSeparations = 0;

            return false;
        }
    }

    public void SpawnFirstCubes()
    {
        int cubeCount = 3;

        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, _cubePrefab.transform.position, Quaternion.identity);

            newCube.ClickDetected += SplitCube;

            _allCubes.Add(newCube);
        }
    }
}
