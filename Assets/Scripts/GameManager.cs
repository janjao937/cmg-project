using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField]private int gridCol;
    [SerializeField]private int gridRow;
    [SerializeField] private GridSystem gridSystem;

   private void Awake()
   {
        if(Instance == null)Instance=this;
        else Destroy(this.gameObject);

       
   }

   public void GenerateGrid(){

        int maxNumber = gridCol*gridRow;
        List<int> rndCardOrder= RandomUnique.RandomUniqueList(0,maxNumber);
        foreach(var i in rndCardOrder){
            Debug.Log("this order :"+i);
        }

     
   }
}
