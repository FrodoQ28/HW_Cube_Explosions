using UnityEngine;

public class CubeController : MonoBehaviour
{
    private void OnEnable()
    {
        Cube.ClickDetected += SplitCube;
    }

    private void OnDisable()
    {
        Cube.ClickDetected -= SplitCube;
    }

    private void SplitCube(GameObject selectedCube)
    {
        Vector3 originalScale = selectedCube.transform.localScale;
        Vector3 newScale = originalScale / 2;
        float originalSplitChance = selectedCube.GetComponent<Cube>().SplitChance;

        if (SplitRandomizer.TrySplit(originalSplitChance, out int numberOfSeparations))
        {
            for (int i = 0; i < numberOfSeparations; i++)
            {
                GameObject newCube = Instantiate(selectedCube, selectedCube.transform.position, Quaternion.identity);
                newCube.transform.localScale = newScale;
                newCube.GetComponent<Rigidbody>().useGravity = true;
                newCube.GetComponent<Cube>().SetSplitChance(originalSplitChance / 2);

                ColorRandomizer.GetColor(newCube);
                Exploder.Explosion(newCube);

                Destroy(selectedCube);
            }
        }
        else
        {
            Destroy(selectedCube);
        }
    }
}
