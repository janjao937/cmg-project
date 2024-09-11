using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    private int col;
    private int row;
    [SerializeField] private GameObject card;
   
    [SerializeField] private RectTransform panelCol;
    [SerializeField] private Transform board;
    [SerializeField] private List<Card> allCard;
    private bool isSetUp = false;
    private PlayerSelected playerSelected;


    public List<Card> GetAllCard {get=>allCard;}
    private void Awake()
    {
        isSetUp = false;
    }
    
    public void SetUp(PlayerSelected playerSelected,int row,int col){
        this.playerSelected = playerSelected;
        this.row = row;
        this.col = col;
        isSetUp =true;
    }
    public void ClearGrid(){
        playerSelected.Reset();
        // foreach(Card card in allCard){
        //     card.StopAllCoroutines();
        // }
        allCard.Clear();
        for (int i = 0;i<board.childCount;i++){
            // board.GetChild(i).gameObject.GetComponentInChildren<Card>().StopAllCoroutines();//Testtttttttttttttttt
            board.GetChild(i).gameObject.SetActive(false);
            Destroy(board.GetChild(i).gameObject);
        }
    }
    public void GenerateGrid(){
        if(!isSetUp){
            Debug.Log("Plz setup gridSystem");
            return;
        }
        ClearGrid();
        RectTransform colParent;
        for(int colIndex = 0;colIndex<col;colIndex++){
            colParent = Instantiate(panelCol,board);

            for(int rowIndex= 0;rowIndex<row;rowIndex++){
               Card current = Instantiate(card,colParent).GetComponent<Card>();
               current.SetPlayerSelected = playerSelected;
               allCard.Add(current);
            }
        }
    }
}
