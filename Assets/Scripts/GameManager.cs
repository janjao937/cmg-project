using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public static GameManager Instance { get; private set;}
    [SerializeField] private UiManager uiManager;
    [SerializeField]private int gridCol;
    [SerializeField]private int gridRow;
    [SerializeField] private List<Sprite> allSpriteList = new List<Sprite>();
    [SerializeField] private GridSystem gridSystem;
    [SerializeField] private GameObject player;
    [SerializeField] private SaveData saveData;
   

    private PlayerSelected playerSelected;
    private PlayerData playerData;
    private float gameEndDelay = 0.5f;

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

   private void Start()
   {
        SoundManager.Instance.PlayBGM(Sound.BGM);
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
            //score++
             playerData.AddScore();
             uiManager.SetCurrentScoreText(playerData.Score);
             if(playerData.Score>=maxScore){
                GameEnd();
             }
        }
        else{
            //turn++
            playerData.AddTurn();
            uiManager.SetCurrentTurnText(playerData.Turn);
        }
   }
    public void Play(){
        uiManager.SetHomePanel(false);
        //GenerateGrid
        GenerateGrid();
        playerData.ResetScore();
        uiManager.ResetCurrent();
    }
   public void GameEnd()
   {
   
    StartCoroutine(DelayEndGame());
    saveData.Save(this.playerData);//save
    
   }
   private IEnumerator DelayEndGame(){
        yield return new WaitForSeconds(gameEndDelay);
        SoundManager.Instance?.PlaySFX(Sound.GAME_END);
        uiManager.SetRestartPanel(true,playerData.Score,playerData.Turn);
   }
   public void Restart(){
    //new game
    uiManager.SetRestartPanel(false,0,0);
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
      uiManager.SetHomePanel(true);
      uiManager.SetRestartPanel(false,0,0);
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
   
   public void BtnClick(){
     SoundManager.Instance.PlaySFX(Sound.BUTTON_CLICK);
   }
 
}
