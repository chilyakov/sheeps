using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.04f;
    [SerializeField]
    private Vector3 target;
    [SerializeField]
    private Vector3 start;


    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target) {
            transform.position = start;
        }
    }
}
