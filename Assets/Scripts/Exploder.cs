using UnityEngine;

public class Exploder
{
    public static void Explosion(GameObject newCube)
    {
        float explosionForce = 500f;
        float explosionRadius = 10f;

        newCube.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, newCube.transform.position, explosionRadius);
    }
}
