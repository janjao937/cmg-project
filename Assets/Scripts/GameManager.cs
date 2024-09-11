using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public static GameManager Instance { get; private set;}

    [SerializeField]private int gridCol;
    [SerializeField]private int gridRow;
    [SerializeField] private List<Sprite> allSpriteList = new List<Sprite>();
    [SerializeField] private GridSystem gridSystem;
    [SerializeField] private PlayerSelected playerSelected;


   private void Awake()
   {
        // if(Instance == null)Instance=this;
        // else Destroy(this.gameObject);
        playerSelected.OnMatch += OnMatch;
       
   }
    void OnDisable()
    {
    playerSelected.OnMatch -= OnMatch;
    }
    void OnEnable()
    {
     playerSelected.OnMatch += OnMatch;
    }
   public void GenerateGrid(){

        gridSystem.SetUp(playerSelected,gridRow,gridCol);
        gridSystem.GenerateGrid();
  
        List<int> rndCardOrder= RandomUnique.RandomUniqueList(0,(gridRow*gridCol)-1);//get card index
        int countSpriteIndex = 0;
        int checkHaveMatch =0;
        for(int i = 0;i<rndCardOrder.Count;i++){
            gridSystem.GetAllCard[rndCardOrder[i]].SetFaceSprite(allSpriteList[countSpriteIndex]);
            checkHaveMatch++;
            if(checkHaveMatch>=2){
                countSpriteIndex++;
                checkHaveMatch=0;
            }
        }


   }

   private void OnMatch(bool isMatch){
        Debug.Log("Match"+isMatch);
   }
}
