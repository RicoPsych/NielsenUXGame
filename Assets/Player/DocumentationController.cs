using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentationController : MonoBehaviour
{
    public GameObject docs;
    private int currentPage;
    public GameObject[] pages;
    // Start is called before the first frame update
    void Start()
    {
        pages = new GameObject[2];
        docs = GameObject.Find("Activatable");
        pages[0] = GameObject.Find("Strona1");
        pages[1] = GameObject.Find("Strona2");
        currentPage = 0;
        
        for (int i = 0; i< pages.Length;i++){
            pages[i].SetActive(false);
            if (i == currentPage){
                pages[i].SetActive(true);
            }
        }
        
        docs.SetActive(false);
    }

    public void ChangePage(){   
        currentPage = (currentPage + 1) % 2;
        for (int i = 0; i< pages.Length;i++){
            pages[i].SetActive(false);
            if (i == currentPage){
                pages[i].SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
