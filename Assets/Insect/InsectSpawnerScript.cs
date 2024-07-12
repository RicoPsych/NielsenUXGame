//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InsectSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int difficulty;
    public float minDelay;
    public float maxDelay;

    private float delay;
    private float timer;


    public float batchDelayRatio;
    private int batchSize;
    public GameObject insect;
    
    void Start()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty",2);
        switch (difficulty){
            case 0:
                minDelay = 100;
                maxDelay = 100;
                batchDelayRatio = 1;
                break;
            case 1:
                minDelay = 16;
                maxDelay = 60;
                batchDelayRatio = 23;
                break;
            case 2:
                minDelay = 10;
                maxDelay = 40;
                batchDelayRatio = 10;
                break;
            case 3:
                minDelay = 8;
                maxDelay = 30;
                batchDelayRatio = 7;
                break;
            default:
                minDelay = 1;
                maxDelay = 1;
                batchDelayRatio = 1;
                break;
        }
        Debug.Log($"Difficulty:{difficulty}: min/maxDelay = {minDelay}/{maxDelay}, batchDelayRatio = {batchDelayRatio}");
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
                if(difficulty != 0)
                    Instantiate(insect);
            }
            delay = UnityEngine.Random.Range(minDelay, maxDelay);
            batchSize = (int)math.ceil(delay/5);
            Debug.Log($"Next bug batch of size {batchSize} in {delay} s");
        }

    }
}
