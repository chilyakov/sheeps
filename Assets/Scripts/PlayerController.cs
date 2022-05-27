using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 input;
    public Grid grid;
    const float MOVE_DIAG = 0.5f;
    const float MOVE_LINE = 0.8f;

    private Vector3Int targetCell;
    private Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetCell = grid.WorldToCell(transform.position);
        transform.position = grid.CellToWorld(targetCell);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();

    }

    void Moving()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var dist = new Vector2(transform.position.x + MOVE_LINE, transform.position.y + MOVE_DIAG);

            Debug.Log(transform.position);
            transform.position = Vector2.MoveTowards(transform.position, dist, 10f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var dist = new Vector2(transform.position.x - MOVE_LINE, transform.position.y - MOVE_DIAG);
            transform.position = Vector2.MoveTowards(transform.position, dist, 10f);
        }
    }

}

