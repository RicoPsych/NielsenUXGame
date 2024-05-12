using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class CheckButton : MonoBehaviour
{
    [System.Serializable]
    public class HeuristicsData
    {
        public int[] badHeuristics;
    }
    private GameObject browser;
    private List<GameObject> toggles = new List<GameObject>();
    void Start()
    {
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

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void WylosowaneLiczbyZJavaScript()
    {
        browser.GetComponent<Browser>().CallFunction("PrzekazWylosowaneLiczbyDoUnity").Then(OnDataReceived).Done();
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
        GameObject.Find("Score").GetComponent<TMP_Text>().text = "Score: "+actualMark+"/10!";


    }

}
