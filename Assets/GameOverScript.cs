using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOver;
    public bool isOff = false;
    public GameObject Timer;
    public Button restart;
    private timer timerScript;
    // Start is called before the first frame update
    void Start()
    {
        restart.gameObject.SetActive(false);
        timerScript = GetComponent<timer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverScreen();
    }

    void GameOverScreen()
    {
        if (isOff)
        {
           gameOver.GetComponent<Renderer>().enabled = true;
           restart.gameObject.SetActive(true);
            Timer.GetComponent<timer>().isGameOver = true;
        }
        else
           gameOver.GetComponent<Renderer>().enabled = false;
    }
}
