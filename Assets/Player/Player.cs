using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CursorType cursor;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find(cursor.ToString()).GetComponent<CursorChanger>().highlight.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CursorType {
    Cloth,
    Swatter,
    Mouse
}