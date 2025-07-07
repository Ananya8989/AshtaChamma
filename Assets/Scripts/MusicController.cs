using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
   public AudioMixer mixer;

   public void SetLevel(float sliderVal){
    mixer.SetFloat("MusicVol", Mathf.Log10(sliderVal)*20);
   }

   public void SetLevel2(float sliderVal){
    mixer.SetFloat("SoundVol", Mathf.Log10(sliderVal)*20);
   }

   void Update(){
      if(Input.GetKeyDown(KeyCode.Q)){
         Application.Quit();
      }
   }
}
