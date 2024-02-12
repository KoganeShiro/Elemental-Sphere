using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;
    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;
    public bool isGameOver = false; // Add a variable to track game over status
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void Update()
    {
        if (!isGameOver) // Check if the game is not over
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
            {
                currentTime = timerLimit;
                SetTimerText();
                timerText.color = Color.red;
                // Trigger game over when the timer reaches the limit
            }
            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.00");
    }

    // Call this method to inform the timer that the game is over
}
