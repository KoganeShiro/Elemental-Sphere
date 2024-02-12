using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeWin : MonoBehaviour
{
    public void play_game()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
