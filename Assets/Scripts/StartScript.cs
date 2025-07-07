using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
     public float changeTime;
    
    void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0 && SceneManager.GetActiveScene().name!="BegEnter"){
            SceneManager.LoadScene("Home Level Selection");
        }
         if(changeTime <= 0 && SceneManager.GetActiveScene().name=="BegEnter"){
            SceneManager.LoadScene("CutSceneBeg1");
        }
    }
}
