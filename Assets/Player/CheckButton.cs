using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;

public class CheckButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject browser;
    void Start()
    {
        browser = GameObject.Find("ScreenBrowser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WylosowaneLiczbyZJavaScript()
    {
        browser.GetComponent<Browser>().CallFunction("PrzekazWylosowaneLiczbyDoUnity").Then(ret => Debug.Log("Wylosowane liczby: " + ret)).Done();
    }

}
