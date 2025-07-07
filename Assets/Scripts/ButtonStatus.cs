using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus : MonoBehaviour
{
    public bool selected;
    public int numSelected;
    public int numPlay;
    public Button button;
    public Sprite select;
    public Sprite deSelect;
    public GameObject info;
    void Start(){
        selected = false;
    }
    public void Clicked(){
        numSelected = info.GetComponent<GameOption>().numSelect;
        numPlay = info.GetComponent<GameOption>().numPlay;
            selected = !selected;
            if(numSelected < numPlay){
            if(selected){
                button.image.sprite = select;
            }
            }
            if(!selected){
                button.image.sprite = deSelect;
            }
    }


}
