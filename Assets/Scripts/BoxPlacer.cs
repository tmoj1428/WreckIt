using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacer : MonoBehaviour
{
    public int              numberOfBlocks;
    public float            timerMaxTime;
    public GameObject       boxPrefab;
    public GameObject[]     points;

    private float           currentTimeVal;
    private GameObject[][]  boxes = new GameObject[15][];

    private void Awake()
    {
        for (int i = 0; i < points.Length; i++)
        {
            boxes[i] = new GameObject[9];
        }
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
                int col = GetRandomPrefabInitialX();
                newLevel.transform.position = new Vector3(points[col].transform.position.x, -4.2f, 0);
                addToArray(col, newLevel);
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
            int col = GetRandomPrefabInitialX();
            newLevel.transform.position = new Vector3(points[col].transform.position.x, -4.2f, 0);
            addToArray(col, newLevel);
        }
    }

    int GetRandomPrefabInitialX()
    {
        return Random.Range(0, points.Length - 1);
    }

    void destroyBoxes()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (boxes[i].Length > 0)
                Destroy(boxes[i][0]);
        }
    }

    private void addToArray(int col, GameObject newLevel)
    {
        if (boxes[col].Length > 0)
        {
            boxes[col][0] = newLevel;
        }
        else
        {
            boxes[col][boxes[col].Length] = newLevel;
        }
    }
}
