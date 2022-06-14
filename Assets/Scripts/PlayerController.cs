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
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Rigidbody2D rbody;
    private ContactFilter2D contactFilter;
    private Collider2D[] allOverlappingColliders;
    //////////////////////////////////////////////////


    void Start()
    {
        SnapToCell(transform.position);
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

    void SnapToCell(Vector3 position)
    {
        cellPosition = gridLayout.WorldToCell(position);
        transform.position = gridLayout.CellToWorld(cellPosition);
        startPosition = transform.position;
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     foreach (Transform coll in collision.transform)
    //     {
    //         Debug.Log(coll.name);
    //     }

    // }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.LogFormat("Coll tag: {0}", col.tag);

    }

    void FixedUpdate() 
    {

        targetPosition = gridLayout.CellToWorld(cellPosition);
        rbody.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, speed));
        if (transform.position != targetPosition)
            controls.Disable();
        else 
        {
            controls.Enable();
            startPosition = transform.position;
        }

        if (rbody.OverlapCollider(contactFilter, allOverlappingColliders) > 0) {
            for (int i = 0; i < allOverlappingColliders.Length; i++)
            {
                if (allOverlappingColliders[i] != null && allOverlappingColliders[i].name == "collider")
                {

                    rbody.velocity = Vector2.zero;
                    rbody.angularVelocity = 0;
                    SnapToCell(startPosition);
                    controls.Enable();
                }
            }
        }
    }

  }

