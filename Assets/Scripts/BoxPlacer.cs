using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacer : MonoBehaviour
{
    public GameObject   boxPrefab;
    public GameObject[] points;
    public float        timerMaxTime;
    public int          numberOfBlocks;

    private float currentTimeVal;

    private void Awake()
    {
        initialDistribution();
    }

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
            // add a row of boxes
            for (int i = 0; i < (int)(points.Length / 2); i++)
            {
                GameObject newLevel;
                newLevel = Instantiate(boxPrefab);
                newLevel.transform.position = new Vector3(points[GetRandomPrefabInitialX()].transform.position.x, -4.2f, 0);
            }

            currentTimeVal = timerMaxTime;
        }
        
    }

    private void initialDistribution()
    {
        for (int i = 0; i < numberOfBlocks; i++)
        {
            GameObject newLevel;
            newLevel = Instantiate(boxPrefab);
            newLevel.transform.position = new Vector3(points[GetRandomPrefabInitialX()].transform.position.x, -4.2f, 0);
        }
    }

    int GetRandomPrefabInitialX()
    {
        return Random.Range(0, points.Length - 1);
    }
}
