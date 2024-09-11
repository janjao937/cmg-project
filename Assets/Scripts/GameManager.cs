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
    [SerializeField] private GameObject player;
    [SerializeField] private SaveData saveData;
    [SerializeField] private UiManager uiManager;

    private PlayerSelected playerSelected;
    private PlayerData playerData;

    [SerializeField]private int maxScore =default;


   private void Awake()
   {
        // if(Instance == null)Instance=this;
        // else Destroy(this.gameObject);

        playerSelected = player.GetComponent<PlayerSelected>();
        playerData = player.GetComponent<PlayerData>();
        maxScore = ((gridRow*gridCol)/2);
        playerSelected.OnMatch += OnMatch;

        ChangeRowAndCol(2,2);

        saveData.Load(uiManager);
   }
    private void OnDisable()
    {
        playerSelected.OnMatch -= OnMatch;
    }
  
   private void GenerateGrid(){

        gridSystem.SetUp(playerSelected,gridRow,gridCol);
        gridSystem.GenerateGrid();
  
        List<int> rndCardOrder= RandomUnique.RandomUniqueList(0,(gridRow*gridCol)-1);//get card index
        int countSpriteIndex = 0;
        int checkHaveMatch =0;
        for(int i = 0;i<rndCardOrder.Count;i++){
            gridSystem.GetAllCard[rndCardOrder[i]].SetFaceSprite(allSpriteList[countSpriteIndex]);
            gridSystem.GetAllCard[rndCardOrder[i]].SpriteIndex=countSpriteIndex;
            checkHaveMatch++;
            if(checkHaveMatch>=2){
                countSpriteIndex++;
                checkHaveMatch=0;
            }
        }
   }

   private void OnMatch(bool isMatch){
        if(isMatch){
            //  Debug.Log("Match"+isMatch);
            //score++
             playerData.AddScore();
             uiManager.SetCurrentScoreText(playerData.Score);
             if(playerData.Score>=maxScore){
                GameEnd();
             }
        }
        else{
            //  Debug.Log("Not Match"+isMatch);
            //turn++
            playerData.AddTurn();
            uiManager.SetCurrentTurnText(playerData.Turn);
        }
   }
    public void Play(){
        //GenerateGrid
        GenerateGrid();
        playerData.ResetScore();
        uiManager.ResetCurrent();
    }
   public void GameEnd(){
   
    saveData.Save(this.playerData);//save
    
   }
   public void Restart(){
    //new game
    Play();
    saveData.Load(uiManager);
   }

   private void ChangeRowAndCol(int row,int col){
        this.gridRow = row;
        this.gridCol = col;
        uiManager.SetGridSize(this.gridRow, this.gridCol);
        maxScore = ((gridRow*gridCol)/2);
   }
  
   public void Home(){
    //go to home
   }
//BTN function
   public void ChangeGridToSSize(){
    ChangeRowAndCol(2,2);
   }

   public void ChangeGridToMSize(){
    ChangeRowAndCol(2,3);
   }

   public void ChangeGridToLSize(){
    ChangeRowAndCol(5,6);
   }
   
}
