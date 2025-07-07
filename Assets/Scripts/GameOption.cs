using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOption : MonoBehaviour
{
    public int numPlay;
    public int numComp;
    public TextMeshProUGUI playText;
    public TextMeshProUGUI compText;
    public int numSelect;
    public GameObject [] colorButtons;
    GameObject gameOptions;

    // Start is called before the first frame update

    void Start(){
        gameOptions = GameObject.Find("GameOptions1");
        numPlay = 1;
        numComp = 1;
        playText.text = "" + numPlay;
        compText.text = "" + numComp;
    }

    void Update(){
        int r = 0;
        for(int i = 0; i < colorButtons.Length; i++){
            if(colorButtons[i].GetComponent<ButtonStatus>().selected){
                r++;
            }
        }
        numSelect = r;
    }

    public void IncreasePlay(){
        if(numPlay < 4)
        playText.text = "" +  ++numPlay;
    }

    public void DecreasePlay(){
        if(numPlay>1)
        playText.text = "" + --numPlay;
    }

    public void IncreaseComp(){
        if(numComp+numPlay <5){
            compText.text = "" + ++numComp;
        }
    }

    public void DecreaseComp(){
        if(numComp>0 && numPlay > 1){
            compText.text = "" + --numComp;
        }
    }

    public void Next(){
        if(numSelect == numPlay && numComp + numPlay > 1){
            gameOptions.GetComponent<GameHandler>().colors = new string[numPlay];
            gameOptions.GetComponent<GameHandler>().numPlay = numPlay;
            gameOptions.GetComponent<GameHandler>().numComp = numComp;
            int j = 0;
            for(int i = 0; i < 4; i++){
                if(colorButtons[i].GetComponent<ButtonStatus>().selected){
                    gameOptions.GetComponent<GameHandler>().colors[j] = colorButtons[i].name;
                    j++;
                }
            }
        }
        for(int i = 0; i < gameOptions.GetComponent<GameHandler>().colors.Length;i++){
            Debug.Log(gameOptions.GetComponent<GameHandler>().colors[i]);
        }
        SceneManager.LoadScene("SampleScene");
    }
}
