using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
     void Update()
    {
    }

    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Play(){
        SceneManager.LoadScene("GameOptions");
    }

    public void History(){
        SceneManager.LoadScene("History");
    }
    public void Rules(){
        SceneManager.LoadScene("Rules");
    }
    public void Info(){
        SceneManager.LoadScene("Info");
    }
    public void Rematch(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void MoveAndroidApplicationToBack()
    {
        AndroidJavaObject game = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        game.Call<bool>("moveTaskToBack", true);
    }
}
