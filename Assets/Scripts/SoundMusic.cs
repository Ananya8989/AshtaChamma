using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusic : MonoBehaviour
{
   public static int numV = 0;
   void Awake(){
      numV++;
      if(numV<3)
     DontDestroyOnLoad(this.gameObject);
   }
}
