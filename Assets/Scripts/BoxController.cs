using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxController : MonoBehaviour
{
    public GameObject   explosionPrefab;
    //public EventSystemHandler eventSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BombObj"))
        {
            FindObjectOfType<AudioManager>().Play("explosion");
            FindObjectOfType<EventSystemHandler>().onBoxWreck.Invoke();
            //eventSystem.onBoxWreck.Invoke();
            // destory box an bomb object on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // explosion animation on box destroy
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = gameObject.transform.position;
        }

        if (collision.gameObject.CompareTag("PlayerObj"))
        {
            FindObjectOfType<AudioManager>().Play("explosion");

            // stop playing airplane sound
            FindObjectOfType<AudioManager>().Stop("airPlane");

            // load game over scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // destory box an bomb object on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // explosion animation on box destroy
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = gameObject.transform.position;
        }
    }
}
