using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private Cube[] _allCubes;
    private Exploder _exploder;

    private void Awake()
    {
        _exploder = new Exploder();
    }

    private void OnEnable()
    {
        _allCubes = FindObjectsOfType<Cube>();

        foreach (var cube in _allCubes)
            cube.ClickDetected += SplitCube;
    }

    private void OnDisable()
    {
        _allCubes = FindObjectsOfType<Cube>();

        foreach (var cube in _allCubes)
            cube.ClickDetected -= SplitCube;
    }

    private void SplitCube(Cube selectedCube)
    {
        Vector3 originalScale = selectedCube.transform.localScale;
        Vector3 newScale = originalScale / 2;
        float originalSplitChance = selectedCube.SplitChance;

        if (TrySplit(originalSplitChance, out int numberOfSeparations))
        {
            for (int i = 0; i < numberOfSeparations; i++)
            {
                Cube newCube = Instantiate(selectedCube, selectedCube.transform.position, Quaternion.identity);

                newCube.transform.localScale = newScale;
                newCube.Rigidbody.useGravity = true;

                newCube.SetSplitChance(originalSplitChance / 2);
                newCube.SetColor(new Color(Random.value, Random.value, Random.value));

                newCube.ClickDetected += SplitCube;

                _exploder.Explosion(newCube);

                Destroy(selectedCube.gameObject);
            }
        }
        else
        {
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
}
