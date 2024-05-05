using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainScript : MonoBehaviour
{
    private int hp;
    public int max_hp;

    // Start is called before the first frame update
    void Start()
    {
        max_hp = hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0){
            Destroy(gameObject);
        }
    }

    private void OnMouseDown(){
        Debug.Log("Clicked Stain");
        var newcolor = GetComponent<SpriteRenderer>().color;
        newcolor.a -= 1f/max_hp;
        GetComponent<SpriteRenderer>().color = newcolor;
        hp -= 1;
    }
}
