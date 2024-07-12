using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CursorType cursor;

    public int lives;
    public int difficulty;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 8;
        difficulty = PlayerPrefs.GetInt("Difficulty",2);
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
    Mouse,
    Docs
}