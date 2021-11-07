using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlacer : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject player;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bomb = Instantiate(bombPrefab);
                bomb.transform.position = player.transform.position;
                
                currentTimeVal = timerMaxTime;
            }
        }
    }
}
