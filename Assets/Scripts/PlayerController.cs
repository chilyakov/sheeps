using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridLayout gridLayout;
    private Vector3Int cellPosition;
    private Vector3 startPosition;
    public float speed = 30f;

    void Start()
    {
        SnapToCell();
    }

    void SnapToCell()
    {
        cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
        startPosition = transform.position;
        //Debug.Log(cellPosition);
    }

    void Update()
    {
        Moving();

    }

    void Moving()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cellPosition.x += 1;
            MoveToward();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cellPosition.x -= 1;
            MoveToward();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cellPosition.y += 1;
            MoveToward();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cellPosition.y -= 1;
            MoveToward();
        }
  
    }

    void MoveToward()
    {
        //Debug.Log(cellPosition);
        startPosition = transform.position;
        transform.position = gridLayout.CellToWorld(cellPosition);
        var target = gridLayout.CellToWorld(cellPosition);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        transform.position = startPosition;
    }


  }

