using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridLayout gridLayout;
    private Vector3Int cellPosition;
    public float speed = 5f;
    private Rigidbody2D rbody;

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
        rbody.position = gridLayout.CellToWorld(cellPosition);
        //Debug.Log(cellPosition);
    }


    private void MouseMovement()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            rbody.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
            
            //rbody.MovePosition(mousePos);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            //this hit.point should give you the same Vector2 results as worldPoint variable
            //Debug.Log(hit.point);
            //buildPoint = hit.point;
            
            //now you can check if the ray hit a collider on a certain layer 
            //if (hit.collider.gameObject.layer == buildSite)
            //{
            //        PlaceTower(buildPoint);
            //}
        }
    }

    void Update()
    {

    }

    void KeysMovement()
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
        //startPosition = transform.position;
        //transform.position = gridLayout.CellToWorld(cellPosition);
        //Vector3 target = gridLayout.CellToWorld(cellPosition);
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //transform.position = gridLayout.CellToWorld(cellPosition);
        //rbody.MovePosition(target);

        rbody.position = gridLayout.CellToWorld(cellPosition);
        Vector3 target = gridLayout.CellToWorld(cellPosition);
        //Vector2 currentPos = rbody.position;
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        // inputVector = Vector2.ClampMagnitude(inputVector, 1);
        // Vector2 movement = inputVector * speed;
        // Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(target);

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.LogFormat("Coll name: {0}", col.name);

    }

    void FixedUpdate() 
    {
        //MouseMovement();
        KeysMovement();
        // Vector2 currentPos = rbody.position;
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        // inputVector = Vector2.ClampMagnitude(inputVector, 1);
        // Vector2 movement = inputVector * speed;
        // Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        // rbody.MovePosition(newPos);

    }

  }

