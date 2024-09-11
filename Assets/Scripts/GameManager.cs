using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private void Awake()
   {
        List<int> rndCardOrder= RandomUnique.RandomUniqueList(0,10);
        foreach(var i in rndCardOrder){
            Debug.Log(i);
        }
   }
}
