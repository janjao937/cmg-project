using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int col;
    [SerializeField] private int row;
    [SerializeField] private GameObject card;
   
    [SerializeField] private RectTransform panelCol;
    [SerializeField] private Transform board;

    [SerializeField] private List<GameObject> allCard;
    public void ClearGrid(){
        allCard.Clear();
        for (int i = 0;i<board.childCount;i++){
            Destroy(board.GetChild(i).gameObject);
        }
    }
    public void GenerateGrid(){
        ClearGrid();
        RectTransform colParent;
        for(int colIndex = 0;colIndex<col;colIndex++){
            colParent = Instantiate(panelCol,board);

            for(int rowIndex= 0;rowIndex<row;rowIndex++){
               GameObject current = Instantiate(card,colParent);
               allCard.Add(current);
               current.SetActive(false);
            }
        }
    }
}
