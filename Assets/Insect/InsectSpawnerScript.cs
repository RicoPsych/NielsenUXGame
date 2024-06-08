//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InsectSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float minDelay;
    public float maxDelay;

    private float delay;
    private float timer;


    public float batchDelayRatio;
    private int batchSize;
    public GameObject insect;
    void Start()
    {
        delay = UnityEngine.Random.Range(minDelay, maxDelay);
        batchSize = (int)math.ceil(delay/batchDelayRatio) ;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=  Time.deltaTime;
        if (timer > delay)
        {
            timer = 0;
            for (int i = 0;i<batchSize;i++)
            {
                insect.transform.position = this.transform.position;
                insect.transform.Rotate(0,0, UnityEngine.Random.Range(0,360));
                
                Instantiate(insect);
            }
            delay = UnityEngine.Random.Range(minDelay, maxDelay);
            batchSize = (int)math.ceil(delay/5);
            Debug.Log($"Next bug batch of size {batchSize} in {delay} s");
        }

    }
}
