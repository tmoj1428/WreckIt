using UnityEngine;

public class DestoryComboController : MonoBehaviour
{
    public float timerMaxTime;
    public GameObject bombDestroyCombo;

    private float currentTimeVal;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeVal = timerMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeVal > 0)
        {
            currentTimeVal -= Time.deltaTime;
        }
        else
        {
            GameObject newCombo = Instantiate(bombDestroyCombo);
            newCombo.transform.position = new Vector3(RandomX(), RandomY(), 0);
            currentTimeVal = timerMaxTime;
        }
    }

    private float RandomX()
    {
        return Random.Range(-7.5f, 7.5f);
    }

    private float RandomY()
    {
        return Random.Range(3.5f, 4.5f);
    }
}
