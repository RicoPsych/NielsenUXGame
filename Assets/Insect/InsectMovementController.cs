using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class InsectMovementController : MonoBehaviour
{
    //public Vector2 speed = new Vector2(0, 0);
    private float timer; 
    private GameObject screen;
    private Rect frameBounds;

    private Vector3 newPosition;
    public float speed;

    public GameObject[] stains;

    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        
        screen = GameObject.Find("Screen");
        var screenRenderer = screen.GetComponent<SpriteRenderer>();
        var boundSize = screenRenderer.bounds.size;
        var boundPosition = screenRenderer.transform.position;
        frameBounds = new Rect(boundPosition.x - boundSize.x/2,boundPosition.y -  boundSize.y/2, boundSize.x, boundSize.y);

        Debug.Log($"Size {boundSize}");
        Debug.Log($"Position {boundPosition}");
        timer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Movement();

        if (timer > delay){
            timer = 0f;
            SpawnStain();
        }
    }  

    private void SpawnStain(){

        int randomNum = UnityEngine.Random.Range(0, stains.Length);
        var stainPosition = transform.position;
        stainPosition.z = 0.25f;
        stains[randomNum].transform.position = stainPosition;
        stains[randomNum].transform.Rotate(0,0, UnityEngine.Random.Range(0,360));
        Instantiate(stains[randomNum]);

    }

    private void Movement(){
        var translationVector = transform.up * speed * Time.deltaTime;
        newPosition = transform.position + translationVector;
        RotateToDirection();
        FrameCollision();
        transform.position = newPosition;
    }

    private void FrameCollision(){
        if (!frameBounds.Contains(transform.position))
        {
            if (newPosition.y > frameBounds.yMax){
                newPosition.y = frameBounds.yMax;
            } 
            else if (newPosition.y < frameBounds.yMin){
                newPosition.y = frameBounds.yMin;

            }

            if (newPosition.x > frameBounds.xMax){
                newPosition.x = frameBounds.xMax;
            } 
            else if (newPosition.x < frameBounds.xMin){
                newPosition.x = frameBounds.xMin;
            }

            RotateToDirection();
            transform.Rotate(new Vector3(0,0, UnityEngine.Random.Range(-30,30)));    
        }
    }

    private void RotateToDirection(){
        var rotationVector = newPosition -  transform.position; 
        transform.rotation = Quaternion.FromToRotation(Vector3.up,rotationVector.normalized);
    }


    private void CircularMotion(){
        var x = (float)Math.Sin(timer*Math.PI)*2;
        var y = (float)Math.Cos(timer*Math.PI)*2;

        newPosition =  new Vector3(x,y,0);

        RotateToDirection();
        transform.position =  newPosition;

        if (timer > 4f){
            timer = 0;
        }
    }

    private void WaveMotion(){
        timer += Time.deltaTime;
        var x = (float)Math.Sin(timer*Math.PI)*2;
        //var y = (float)Math.Cos(timer*Math.PI)*2;
        
        newPosition =  new Vector3(x,transform.position.y,0);
        
        RotateToDirection();
        transform.position = newPosition;  

        if (timer > 4f){
            timer = 0;
        }  
    }

    void OnMouseDown(){
        //Debug.Log("Clicked");
        
        if(GameObject.Find("Player").GetComponent<Player>().cursor == CursorType.Swatter){
            SpawnStain();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        transform.Rotate(new Vector3(0,0, 180));
        //Instantiate(this);   
        Debug.Log("Collision Occured");
    }
}
