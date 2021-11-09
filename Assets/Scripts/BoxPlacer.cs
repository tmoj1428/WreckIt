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
    private List<List<GameObject>> boxList = new List<List<GameObject>>();

    private void Awake()
    {
        for (int i = 0; i < points.Length; i++)
        {
            boxList.Add(new List<GameObject>());
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
                boxList[col].Add(newLevel);
            }

            currentTimeVal = timerMaxTime;
        }
        
    }

    public void destroyBoxes()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (boxList[i].Count > 0)
            {
                Destroy(boxList[i][0]);
                boxList[i].RemoveAt(0);
            }
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
            boxList[col].Add(newLevel);
        }
    }

    private int GetRandomPrefabInitialX()
    {
        return Random.Range(0, points.Length - 1);
    }
}
