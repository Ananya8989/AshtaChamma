using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;


public class PlayerController : MonoBehaviour, IPointerDownHandler
{
    public bool comp = false;
    public AudioClip moveSound;
    AudioSource soundEffec;
    int dir;
    int numMoves = 0;
    int div = 6;
    int sub = 3;
    int spots = 0;
    public bool stop = true;
    public Vector3 startPos;
    Vector3[] dirArr = {new Vector3(1.3f,0,0),new Vector3(0,1.3f,0),new Vector3(-1.3f,0,0),new Vector3(0,-1.3f,0)};
    public GameObject manager;
    void Start(){
        startPos = gameObject.transform.position;
        numMoves = 0;
        AddPhysics2DRaycaster();
        if(gameObject.tag == "Red"){
            dir = 0;
        }
        if(gameObject.tag == "Blue"){
            dir = 1;
        }
        if(gameObject.tag == "Green"){
            dir = 2;
        }
        if(gameObject.tag == "Yellow"){
            dir = 3;
        }
        soundEffec = GameObject.Find("SoundSource").GetComponent<AudioSource>();
    }

    void Update(){
        if(spots == 0){
            CancelInvoke();
        }
    }

    public void startTurn(){
        spots = manager.GetComponent<GameManager>().getMove();
        if(gameObject.tag == manager.GetComponent<GameManager>().turn){
            InvokeRepeating("Move", 1.0f, 0.5f);
        }
        manager.GetComponent<GameManager>().buttonText.text = "Roll";
    }

    void Move(){
        if(numMoves != 51 && (numMoves +spots) <= 51&&gameObject.transform.position.x != 3){
            if(numMoves==23){
                dir+=1;
                if(dir==4)
                dir=0;
                div = 4;
            }
        else if(numMoves==24||numMoves == 42){
            dir-=1;
            if(dir==-1)
            dir = 3;
        }
        else if(numMoves == 42){
            div = 2;
            sub = 1;
        }
        else if(numMoves == 50 ||numMoves == 41 || numMoves == 3 || numMoves == 45||numMoves == 49||(numMoves-sub)%div == 0){
            dir+=1;
            if(dir == 4){
                dir = 0;
            }
        }
        Debug.Log("moves"+numMoves);
        transform.position += dirArr[dir];
        soundEffec.PlayOneShot(moveSound);
        numMoves++;
        spots--;
        }
        if(numMoves == 51){
             switch(gameObject.tag){
            case "Red":
            manager.GetComponent<GameManager>().Red+=1;
            break;
            case "Yellow":
            manager.GetComponent<GameManager>().Yellow+=1;
            break;
            case "Green":
            manager.GetComponent<GameManager>().Green+=1;
            break;
            case "Blue":
            manager.GetComponent<GameManager>().Blue+=1;
            break;
        }
        }
        if(spots == 0){
            stop = true;
            for(int i = 1; i < 5; i++){
                GameObject.Find(gameObject.tag.ToLower()+i).GetComponent<PlayerController>().stop = true;
            }
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        spots = manager.GetComponent<GameManager>().getMove();
        if(gameObject.tag == manager.GetComponent<GameManager>().turn && gameObject.transform.position.x == 3 && (spots == 4 || spots == 8)){
            gameObject.transform.position = startPos;
            numMoves = 0;
            stop = true;
        }
        else if (!stop){
            startTurn();
        }
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(gameObject.tag != collider.gameObject.tag && gameObject.tag == manager.GetComponent<GameManager>().turn&&spots==0){
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            if(!((x<-2.7&&x>-3.3)&&(y>-4.3&&y<-3.6))&&!((x<-2.7&&x>-3.3)&&(y<4.3&&y>3.6))&&!((x<-6.6&&x>-7.3)&&(y>-0.3&&y<0.4))&&!((x<1.3&&x>0.6)&&(y>-0.3&&y<0.4))){
                if(!((x<-5.3&&x>-6)&&(y>-3&&y<-2.3))&&!((x<0&&x>0.7)&&(y>-3&&y<-2.3))&&!((x<0&&x>0.7)&&(y>2.3&&y<3))&&!((x<-5.3&&x>-6)&&(y>2.3&&y<3))&&!((x<-2.6&&x>-3.4)&&(y>-0.3&&y<0.4))){
                    collider.gameObject.transform.position = new Vector3(3,collider.gameObject.transform.position.y,0);
                }
            }
        }
    }
}
