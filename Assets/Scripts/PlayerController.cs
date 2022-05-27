using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 input;
    public Grid grid;
    public GridLayout gridLayout;
    private Vector3Int gridMovement;
    private Vector3Int cellPosition;
    private Vector2 targetPosition;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        SnapToCell();
        gridMovement = new Vector3Int();
    }

    // Update is called once per frame
    void SnapToCell()
    {
        cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
    }

    void Update()
    {
        Moving();

    }

    void Moving()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridMovement.x += 1;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridMovement.x -= 1;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridMovement.y += 1;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridMovement.y -= 1;
        }
        
        if(gridMovement != Vector3Int.zero) {
            targetPosition = grid.CellToWorld(gridMovement);
            MoveToward(targetPosition);
        }

    }

    void MoveToward(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

}

