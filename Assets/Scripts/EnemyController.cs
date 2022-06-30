using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.04f;
    [SerializeField]
    private Vector3 target = new Vector3(.5f, 0, 0);
    [SerializeField]
    private Vector3 start;
    [SerializeField]
    private float rotationSpeed = 100f;

    bool moveLeft = false;
    float angle, radius = 10;
    float angleSpeed = 2;
    float radialSpeed = 0.5f;

    void GoLeft()
    {

    }

    void GoRight()
    {

    }

    void Stand()
    {

    }





    void Update()
    {

        transform.RotateAround(transform.position, Vector3.back, 3f * Time.deltaTime);

        // angle = Time.deltaTime * angleSpeed;
        //radius -= Time.deltaTime * radialSpeed;
 
        // Vector3 pos = new Vector3();
        // pos.y = Mathf.Cos(Mathf.Deg2Rad*angle);
        //float y = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
        //float z = transform.position.z;
        //float x = transform.position.x;

        // transform.RotateAround(target, Vector3.back, Mathf.Deg2Rad*angle);
        
        // transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        //if (transform.position.y < target.y) {
        //     transform.position = start;
        // }
    }

    // float amplitudeX = -25.0f;
    // float amplitudeY = 5.0f;
    // float omegaX = 0.5f;
    // float omegaY = 4.0f;
    // float index;

    // void Update () {
    //     index += Time.deltaTime;
    //     float x = amplitudeX*Mathf.Cos (omegaX*index);      
    //     float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
    //     if(transform.position.x > 24){
    //             transform.eulerAngles = new Vector3(270, -90, 0);
    //     }
    //     if(transform.position.x < -24){
    //             transform.eulerAngles = new Vector3(270, 90, 0);
    //     }   
    //     transform.localPosition= new Vector3(x,y,20);
    // }



}
