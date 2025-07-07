using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int numMove;
    public string turn = "";
    int i = 0;
    public int Blue = 0;
    public int Green = 0;
    public int Red = 0;
    public int Yellow = 0;
    List<string> player = new List<string>();
    public TextMeshProUGUI turnText;
    public TextMeshProUGUI buttonText;
    public GameObject[] players;
    public int p;
    public int c;
    public GameObject blueSc;
    public GameObject redSc;
    public GameObject yellowSc;
    public GameObject greenSc;
    GameObject GameOptions;

    void Start()
    {
        GameOptions = GameObject.Find("GameOptions1");
        
        p = GameOptions.GetComponent<GameHandler>().numPlay;
        c = GameOptions.GetComponent<GameHandler>().numComp;
        int P = p;
        int C = c;
        int s = 0;
        for(int i = 0; i <4; i++){
            for(int j = 0; j < P; j++){
                if(!player.Contains(players[i].name)&&GameOptions.GetComponent<GameHandler>().colors[j] == players[i].name){
                    players[i].SetActive(true);
                    player.Add(players[i].name);
                    Debug.Log(players[i].name);
                    s++;
                }
            }
        }
        while(C>0){
        for(int i = 0; i < 4; i++){
            if(!player.Contains(players[i].name)){
                players[i].SetActive(true);
                Debug.Log(players[i]);
                player.Add(players[i].name);
                for(int j = 1; j < 5; j++){
                    GameObject.Find(player[player.Count-1].Substring(0,player[player.Count-1].Length-1).ToLower()+j).GetComponent<PlayerController>().comp = true;
                }
                C--;
                break;
            }
        }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Blue == 4){
            blueSc.SetActive(true);
        }
        if(Red == 4){
            redSc.SetActive(true);
        }
        if(Yellow == 4){
            yellowSc.SetActive(true);
        }
        if(Green == 4){
            greenSc.SetActive(true);
        }
    }

    public void updateMove(int newMove){
        Debug.Log(newMove);
        numMove = newMove;
        buttonText.text = newMove + "";
        if(i==(p+c)){
            i = 0;
        }
        turn = player[i].Substring(0,player[i].Length-1);
        if(GameObject.Find(turn.ToLower()+"1").GetComponent<PlayerController>().comp){
            Debug.Log(turn);
            if(newMove == 4 || newMove==8){
                int r = (int)Random.Range(1,2);
                if(r==1){
                    bool e = false;
                    for(int f = 1; f < 4; f++){
                         float s = GameObject.Find(turn.ToLower()+f).transform.position.x;
                         if(s == 0){
                            GameObject.Find(turn.ToLower()+f).transform.position = GameObject.Find(turn.ToLower()+f).GetComponent<PlayerController>().startPos;
                            e = true;
                            break;
                         }
                    }
                    if(!e){
                        GameObject.Find(turn.ToLower()+(int)Random.Range(1,4)).GetComponent<PlayerController>().startTurn();
                    }
                }

                else{
                    GameObject.Find(turn.ToLower()+(int)Random.Range(1,4)).GetComponent<PlayerController>().startTurn();
                }
            }
            else{
            GameObject.Find(turn.ToLower()+(int)Random.Range(1,4)).GetComponent<PlayerController>().startTurn();
            }
        }
        turnText.text = turn;
        switch(turn){
            case "Red":
            turnText.color = Color.red;
            break;
            case "Yellow":
            turnText.color = Color.yellow;
            break;
            case "Green":
            turnText.color = Color.green;
            break;
            case "Blue":
            turnText.color = Color.cyan;
            break;
        }
        if(newMove != 8 && newMove != 4){
            i++;
            Debug.Log(i);
        }
    }

    public int getMove(){
       // Debug.Log(numMove);
        return numMove;
    }
}
