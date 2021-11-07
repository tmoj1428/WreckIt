using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FloorObj"))
        {
            Destroy(gameObject);
        }
    }
}
