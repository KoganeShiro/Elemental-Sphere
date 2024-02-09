using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOver;
    public bool isOff = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOverScreen();
    }

    void GameOverScreen()
    {
        if (isOff)
           gameOver.GetComponent<Renderer>().enabled = true;
        else
           gameOver.GetComponent<Renderer>().enabled = false;
    } 
}
