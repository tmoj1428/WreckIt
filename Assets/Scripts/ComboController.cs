using UnityEngine;

public class ComboController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerObj"))
        {
            int randomNumber = RandomNum();
            if (randomNumber % 2 == 0 || randomNumber % 3 == 0 || randomNumber % 5 == 0)
            {
                FindObjectOfType<BoxPlacer>().addBoxes();
                Destroy(gameObject);
            }
            else
            {
                FindObjectOfType<BoxPlacer>().destroyBoxes();
                Destroy(gameObject);
            }
        }
    }

    private int RandomNum()
    {
        return Random.Range(1, 10);
    }
}
