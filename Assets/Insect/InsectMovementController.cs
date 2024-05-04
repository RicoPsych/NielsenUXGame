using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InsectMovementController : MonoBehaviour
{
    //public Vector2 speed = new Vector2(0, 0);
    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
//        CircularMotion();
        WaveMotion();
        transform.Translate(Time.deltaTime*0.2f, 0, 0);
    }   

    private void CircularMotion(){
        timer += Time.deltaTime;
        var x = (float)Math.Sin(timer*Math.PI)*2;
        var y = (float)Math.Cos(timer*Math.PI)*2;
        
        transform.position = new Vector3(x,y,0);  

        if (timer > 4f){
            timer = 0;
        }
    }

    private void WaveMotion(){
              timer += Time.deltaTime;
        var x = (float)Math.Sin(timer*Math.PI)*2;
        //var y = (float)Math.Cos(timer*Math.PI)*2;
        
        transform.position = new Vector3(x,0,0);  

        if (timer > 4f){
            timer = 0;
        }  
    }
}
