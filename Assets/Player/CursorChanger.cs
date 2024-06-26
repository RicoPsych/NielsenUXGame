using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public CursorType cursorType;
    private GameObject player;
    public SpriteRenderer highlight;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //transform.GetChild(0).
        highlight = gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    void OnMouseDown(){
        GameObject.Find(player.GetComponent<Player>().cursor.ToString()).GetComponent<CursorChanger>().highlight.color = new Color (0,0,0,0);
        highlight.color = Color.green;
        player.GetComponent<Player>().cursor = cursorType;
        Debug.Log($"Changed CursorType {cursorType}");
    }
}
