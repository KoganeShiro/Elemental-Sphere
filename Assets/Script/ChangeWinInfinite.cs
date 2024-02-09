using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeWinInfinite : MonoBehaviour
{
   public void play_infinite()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
