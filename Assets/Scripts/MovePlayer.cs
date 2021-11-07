﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Range(0f, 1f)] public float movementAmount;
    [Range(0f, 1f)] public float speedAmount;
    public GameObject leftBound;
    public GameObject rightBound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, movementAmount, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, movementAmount, 0);
        }

        transform.position += new Vector3(speedAmount, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RightBound"))
        {
            transform.position = new Vector3(leftBound.transform.position.x, transform.position.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoxTag"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
