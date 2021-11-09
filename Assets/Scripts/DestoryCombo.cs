using UnityEngine;

public class DestoryCombo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerObj"))
        {
            FindObjectOfType<BoxPlacer>().destroyBoxes();
            Destroy(gameObject);
        }
    }
}
