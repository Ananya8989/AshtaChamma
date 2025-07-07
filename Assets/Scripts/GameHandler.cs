using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public string[] colors;
    public int numPlay;
    public int numComp;
    public static int numPas;

    void Awake(){
        if(SceneManager.GetActiveScene().name == "GameOptions")
        numPas++;
        if(numPas==1){
        DontDestroyOnLoad(this.gameObject);
        gameObject.name = "GameOptions1";
        }
    }
}
