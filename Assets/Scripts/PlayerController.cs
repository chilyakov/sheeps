using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private Controls controls;  
    ///////////////////////////////////////////////////
    [SerializeField]
    private GridLayout gridLayout;
    [SerializeField]
    private float speed = 0.04f;
    private Vector3Int cellPosition;
    private Rigidbody2D rbody;
    private ContactFilter2D contactFilter;
    private Collider2D[] allOverlappingColliders;
    private bool stop = false;
    //////////////////////////////////////////////////


    void Start()
    {
        SnapToCell();
        contactFilter = new ContactFilter2D();
        allOverlappingColliders = new Collider2D[10];

        controls.Main.Left.performed += _ => LeftKeyPress();
        controls.Main.Right.performed += _ => RightKeyPress();
        controls.Main.Up.performed += _ => UpKeyPress();
        controls.Main.Down.performed += _ => DownKeyPress();

    }

    private void LeftKeyPress()
    {
        cellPosition.x -= 1;
    }
    private void RightKeyPress()
    {
        cellPosition.x += 1;
    }
    private void UpKeyPress()
    {
       cellPosition.y += 1;
    }
    private void DownKeyPress()
    {
        cellPosition.y -= 1;
    }


    private void Awake()
    {
        controls = new Controls();
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void SnapToCell()
    {
        cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
    }

    //void Update()
    //{
        //ReadKeys();
    //}

    void ReadKeys()
    {
        

        if (stop) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            cellPosition.x += 1;
            StopMovement();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cellPosition.x -= 1;
            StopMovement();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            cellPosition.y += 1;
            StopMovement();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            cellPosition.y -= 1;
            StopMovement();
        }
        

     }

    private void StopMovement()
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (Transform coll in collision.transform)
        {
            Debug.Log(coll.name);
        }

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

        if (rbody.OverlapCollider(contactFilter, allOverlappingColliders) > 0) {
            //Debug.Log(allOverlappingColliders[0]);
            for (int i = 0; i < allOverlappingColliders.Length; i++)
            {
                if (allOverlappingColliders[i] != null && allOverlappingColliders[i].name == "collider")
                    rbody.velocity = Vector2.zero;
                   
            }
        }
    }

  }

