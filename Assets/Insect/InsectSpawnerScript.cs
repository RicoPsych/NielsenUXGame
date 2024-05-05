using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay;
    private float timer;

    public int batchSize;
    public GameObject insect;
    void Start()
    {
        
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
                insect.transform.Rotate(0,0, Random.Range(0,360));
                Instantiate(insect);
            }
        }

    }
}
