using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //Screen.SetResolution(Screen.width, Screen.height);
        //Screen.SetResolution(1080, 1920,true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ExitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void StartGame(){
        Debug.Log("StartGame");
       // SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Game");
    }

    public void MainMenu(){
        Debug.Log("MainMenu");
        //SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings(){
        Debug.Log("Settings");
        //SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadScene("Settings");

    }


}
