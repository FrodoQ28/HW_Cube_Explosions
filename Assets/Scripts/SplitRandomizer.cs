using UnityEngine;

public class SplitRandomizer
{
    private static int s_minCubeCount = 2;
    private static int s_maxCubeCount = 7;

    public static bool TrySplit(float splitChance, out int numberOfSeparations)
    {
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
