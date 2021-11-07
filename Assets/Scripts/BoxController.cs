using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BombObj"))
        {
            // destory box an bomb object on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // explosion animation on box destroy
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = gameObject.transform.position;
        }

        if (collision.gameObject.CompareTag("PlayerObj"))
        {
            // destory box an bomb object on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // explosion animation on box destroy
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = gameObject.transform.position;
        }
    }
}
