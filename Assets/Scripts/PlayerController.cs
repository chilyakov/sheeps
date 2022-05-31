using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridLayout gridLayout;
    private Vector3Int cellPosition;
    public float speed = 0.04f;
    private Rigidbody2D rbody;
    private bool stop = false;
    void Start()
    {
        SnapToCell();
    }

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void SnapToCell()
    {
        cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
    }

    void Update()
    {
        ReadKeys();
    }

    void ReadKeys()
    {

        if (stop) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            cellPosition.x += 1;
            stopMovement();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            cellPosition.x -= 1;
            stopMovement();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            cellPosition.y += 1;
            stopMovement();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            cellPosition.y -= 1;
            stopMovement();
        }
        

     }

    private void stopMovement()
    {
        
        stop = true;
        float t = 0;
        float s = speed;
        while (t < s)
        {
            s -= Time.fixedDeltaTime;
        }
        stop = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.LogFormat("Coll name: {0}", col.name);

    }

    void FixedUpdate() 
    {
        
        Vector3 target = gridLayout.CellToWorld(cellPosition);
        rbody.MovePosition(Vector2.MoveTowards(transform.position, target, speed));
        //rbody.position = gridLayout.CellToWorld(cellPosition);
        
    }

  }

