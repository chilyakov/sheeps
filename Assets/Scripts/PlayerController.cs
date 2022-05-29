using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridLayout gridLayout;
    private Vector3Int cellPosition;

    // Start is called before the first frame update
    void Start()
    {
        SnapToCell();
    }

    // Update is called once per frame
    void SnapToCell()
    {
        cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
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
            cellPosition.x += 2;
            MoveToward();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cellPosition.x -= 2;
            MoveToward();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cellPosition.y += 2;
            MoveToward();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cellPosition.y -= 2;
            MoveToward();
        }
  
    }

    void MoveToward()
    {
        //Debug.Log(cellPosition);
        transform.position = gridLayout.CellToWorld(cellPosition);
    }

}

