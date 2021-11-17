using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacer : MonoBehaviour
{
    public int              numberOfBlocks;
    [HideInInspector]
    public float            timerMaxTime;
    public GameObject       boxPrefab;
    public GameObject[]     points;
    public EventSystemHandler eventSystem;

    private float           currentTimeVal;
    private List<List<GameObject>> boxList = new List<List<GameObject>>();

    private void Awake()
    {
        timerMaxTime = 9;
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
            addBoxes();
            if (MovePlayer.playerScore > 150)
            {
                if (timerMaxTime > 6)
                {
                    timerMaxTime -= 0.2f;
                }
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
                eventSystem.onBoxWreck.Invoke();
                Destroy(boxList[i][0]);
                boxList[i].RemoveAt(0);
            }
        }
    }

    public void addBoxes()
    {
        for (int i = 0; i < (int)(points.Length / 2); i++)
        {
            GameObject newLevel;
            newLevel = Instantiate(boxPrefab);
            int col = GetRandomPrefabInitialX();
            newLevel.transform.position = new Vector3(points[col].transform.position.x, -4.2f, 0);
            boxList[col].Add(newLevel);
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
