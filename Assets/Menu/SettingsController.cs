using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("DifficultySlider") is not null)
            GameObject.Find("DifficultySlider").GetComponent<Slider>().value = PlayerPrefs.GetInt("Difficulty", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetDifficulty(int difficulty){
        PlayerPrefs.SetInt("Difficulty", difficulty%4);
        Debug.Log("Set Difficulty: " + difficulty);
    }
    public void SetDifficulty(Slider difficulty){
        SetDifficulty((int)difficulty.value); 
    }

}
