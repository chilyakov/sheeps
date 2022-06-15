using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.04f;
    [SerializeField]
    private Vector3 target = new Vector3(.5f, 0, 0);
    [SerializeField]
    private Vector3 start;
    [SerializeField]
    private float rotationSpeed = 100f;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    float angle, radius = 10;
    float angleSpeed = 2;
    float radialSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        angle = Time.deltaTime * angleSpeed;
        //radius -= Time.deltaTime * radialSpeed;
 
        Vector3 pos = new Vector3();
        pos.y = Mathf.Cos(Mathf.Deg2Rad*angle);
        //float y = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
        //float z = transform.position.z;
        //float x = transform.position.x;

        transform.RotateAround(target, Vector3.back, Mathf.Deg2Rad*angle);
        
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        //if (transform.position.y < target.y) {
        //     transform.position = start;
        // }
    }

}
