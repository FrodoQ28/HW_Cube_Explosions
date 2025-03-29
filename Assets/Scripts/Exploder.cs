public class Exploder
{
    public void Explosion(Cube newCube)
    {
        float explosionForce = 500f;
        float explosionRadius = 10f;

        newCube.Rigidbody.AddExplosionForce(explosionForce, newCube.gameObject.transform.position, explosionRadius);
    }
}
