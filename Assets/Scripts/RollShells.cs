using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollShells : MonoBehaviour
{
    public GameObject[] shells = new GameObject[4];
    public Sprite[] spShells = new Sprite[2];
    public GameManager manager;
    public GameObject [] player;
    int moveNum = 0;
    void Start()
    {
        //Roll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Roll(){
        moveNum = 0;
        for(int i = 0; i < 4; i++){
            int s = (int)Random.Range(0,2);
            shells[i].GetComponent<SpriteRenderer>().sprite = spShells[s];
            if(s==0){
                moveNum +=1;
            }
            shells[i].transform.position = new Vector3(Random.Range(2.3f,8f),Random.Range(-4f,4f),0);
        }
        if(moveNum == 0){
            moveNum = 8;
        }
        manager.GetComponent<GameManager>().updateMove(moveNum);
        for(int i = 0; i < 16; i++){
            if(player[i].tag == manager.GetComponent<GameManager>().turn)
            player[i].GetComponent<PlayerController>().stop = false;
        }
    }
}
