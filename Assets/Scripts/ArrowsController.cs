using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public GridLayout gridLayout;
    //public UnityEngine.Tilemaps.Tilemap gridColliders;
    private Vector3Int cellPosition;
    private Vector3 startPosition;
    public float speed = 5f;

    void Start()
    {
        SnapToCell();
        startPosition = transform.position;
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
            // Vector3 target = gridLayout.CellToWorld(cellPosition);

            // RaycastHit2D hit = Physics2D.Raycast(transform.position, target, 1.0f);
            // Debug.LogFormat("{0}, {1}", transform.position, target);
            
            //if (gridColliders.GetTile(cellPosition))
            //{
            //     Debug.Log("YEs");
            //}
            
            // if (hit.collider != null)
            //     Debug.LogFormat("Distance: {0}, colliser: {1}", hit.distance, hit.collider);
            
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
        Vector3 target = gridLayout.CellToWorld(cellPosition);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.LogFormat("Coll name: {0}", col.name);
        //transform.position = startPosition;
    }

  }

