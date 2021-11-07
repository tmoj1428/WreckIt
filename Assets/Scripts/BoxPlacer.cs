using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacer : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject[] points;
    public float timerMaxTime;

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
            GameObject newLevel;
            newLevel = Instantiate(boxPrefab);
            newLevel.transform.position = new Vector3(points[GetRandomPrefabInitialX()].transform.position.x, -4.2f, 0);

            currentTimeVal = timerMaxTime;
        }
        
    }

    int GetRandomPrefabInitialX()
    {
        return Random.Range(0, 10);
    }
}
