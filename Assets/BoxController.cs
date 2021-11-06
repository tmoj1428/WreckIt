using UnityEngine;

public class BoxController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BombObj"))
        {
            Debug.Log("Destroooooy!!!!!!!!!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
