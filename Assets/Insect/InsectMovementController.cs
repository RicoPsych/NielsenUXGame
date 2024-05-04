using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class InsectMovementController : MonoBehaviour
{
    //public Vector2 speed = new Vector2(0, 0);
    private float timer; 
    private GameObject screen;
    private BoxCollider2D screenBoxCollider;

    // Start is called before the first frame update
    void Start()
    {

        screen = GameObject.Find("Screen");
        screenBoxCollider = screen.GetComponent<BoxCollider2D>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
//        CircularMotion();
        WaveMotion();

        // screenBoxCollider
        // screenBoxCollider.ClosestPoint()

        transform.Translate(Time.deltaTime*0.2f, 0, 0);
    }  

    private void RotateToDirection(Vector3 newPosition){
        var rotationVector = newPosition -  transform.position; 
        transform.rotation = Quaternion.FromToRotation(Vector3.up,rotationVector.normalized);
    }


    private void CircularMotion(){
        timer += Time.deltaTime * 0.5f;
        var x = (float)Math.Sin(timer*Math.PI)*2;
        var y = (float)Math.Cos(timer*Math.PI)*2;

        var newPosition =  new Vector3(x,y,0);

        RotateToDirection(newPosition);
        transform.position =  newPosition;

        if (timer > 4f){
            timer = 0;
        }
    }

    private void WaveMotion(){
        timer += Time.deltaTime;
        var x = (float)Math.Sin(timer*Math.PI)*2;
        //var y = (float)Math.Cos(timer*Math.PI)*2;
        
        var newPosition =  new Vector3(x,transform.position.y,0);
        
        RotateToDirection(newPosition);
        transform.position = newPosition;  

        if (timer > 4f){
            timer = 0;
        }  
    }
}
