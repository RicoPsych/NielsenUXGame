using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class CheckButton : MonoBehaviour
{
    private float score;
    private int correct;
    private int wrong;

    [System.Serializable]
    public class HeuristicsData
    {
        public int[] badHeuristics;
    }
    private GameObject browser;
    
    private Player player;
    private GameObject checkButton;
    private GameObject nextButton;
    private GameObject endScreen;
    private float UITime;
    private float playTime;
    
    private int streak;

    private bool pause;

    private List<GameObject> toggles = new List<GameObject>();
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        checkButton = GameObject.Find("CheckingButton");
        nextButton = GameObject.Find("NextButton");
        endScreen = GameObject.Find("EndMenu");

        correct= 0;
        wrong = 0;

        browser = GameObject.Find("ScreenBrowser");
        toggles.Add(GameObject.Find("1"));
        toggles.Add(GameObject.Find("2"));
        toggles.Add(GameObject.Find("3"));
        toggles.Add(GameObject.Find("4"));
        toggles.Add(GameObject.Find("5"));
        toggles.Add(GameObject.Find("6"));
        toggles.Add(GameObject.Find("7"));
        toggles.Add(GameObject.Find("8"));
        toggles.Add(GameObject.Find("9"));
        toggles.Add(GameObject.Find("10"));

        nextButton.SetActive(false);
        checkButton.SetActive(true);
        endScreen.SetActive(false);

        UITime = 0f;
        playTime = 0f;
        pause= false;

        streak = 0;
    }
    // Update is called once per frame
    void Update()
    {
        UITime += Time.deltaTime;
        if(!pause){
            playTime += Time.deltaTime;
        }
    }
    public void WylosowaneLiczbyZJavaScript()
    {
        browser.GetComponent<Browser>().CallFunction("PrzekazWylosowaneLiczbyDoUnity").Then(OnDataReceived).Done();
    }

    public void EndScreen(){
        nextButton.SetActive(false);
        checkButton.SetActive(false);
        endScreen.SetActive(true);
        GameObject.Find("EndGameSite").GetComponent<TMP_Text>().text = $" Wynik:\n{score}\nPoprawnie oceniono:\n{correct}\nLiczba Prób:\n{correct+wrong}\nCzas:\n{playTime} s";//\nWynik Gracza:{correct}/{correct+wrong}

    }

    public void NextUI()
    {
        browser.GetComponent<Browser>().Reload();
        nextButton.SetActive(false);
        checkButton.SetActive(true);
        //Enable CheckButton/DisableNextButton
        UITime = 0;
        pause = false;
    }

    public float TimeScoreMultiplier(){
        if(UITime < 15){
            return 3f;
        }
        else if (UITime < 30){
            return 2f;
        }
        else if (UITime < 60){
            return 1f;
        }
        else if (UITime < 90){
            return 0.5f;
        }
        else {
            return 0;
        }
    } 

    private void OnDataReceived(JSONNode result)
    {
        HeuristicsData heuristicsData = JsonUtility.FromJson<HeuristicsData>("{\"badHeuristics\":" + result.AsJSON.Substring(1,result.AsJSON.Length-2) + "}");
        int[] badHeuristics = heuristicsData.badHeuristics;
        int actualMark=0;
        for(int i=0; i<10; i++){
            Toggle toggle = toggles[i].GetComponent<Toggle>();
            if(toggle.isOn){
                if(badHeuristics.Contains(i+1)){
                    actualMark+=1;
                }
            }
            else{
                if(!badHeuristics.Contains(i+1)){
                    actualMark+=1;
                }
            }
        }

        if(actualMark==10){
            correct +=1;
            foreach (var toggle in toggles){
                toggle.GetComponent<Toggle>().isOn = false;
            }
            
            score += 100 * (player.difficulty+1) * TimeScoreMultiplier();
            streak++;
            checkButton.SetActive(false);
            nextButton.SetActive(true);
            pause = true;
            //DisableCheckButton/EnableNExtbutton
       //     browser.GetComponent<Browser>().Reload();
        }
        else{
            score -= 30;
            streak = 0;
            player.lives-=1;
            wrong+=1;
        }
        if(player.lives <= 0){
            EndScreen();
        }        
        if(streak > 0 && streak % 3 == 0){
            player.lives++;
        }
    //    GameObject.Find("Score").GetComponent<TMP_Text>().text = $"UI Score: {actualMark}/10!\nCorrect:{correct} Wrong:{wrong}";
        GameObject.Find("Score").GetComponent<TMP_Text>().text = $"Zaznaczono Poprawnie: {actualMark}/10!\n Pozostałe próby: {player.lives}\nWynik:{score}";//\nWynik Gracza:{correct}/{correct+wrong}
    
    }

}
