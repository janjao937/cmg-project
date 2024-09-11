using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelected : MonoBehaviour
{
    //  [SerializeField]private Card firstCardSelected;
    // [SerializeField]private Card secoundCardSelected;
    
    public List<Card> SelectedCards = new List<Card>();

    public bool canSelect = true;
    public event Action<bool> OnMatch;

    private void Awake()
    {
        canSelect = true;
    }
    public void CheckResult(){
        if(SelectedCards[0].SpriteIndex == SelectedCards[1].SpriteIndex){
            Debug.Log("Match");
            OnMatch?.Invoke(true);
            SelectedCards.Clear();
        }
        else{
            OnMatch(false);
           StartCoroutine(ClearSelected());
          
        }
    }
    private IEnumerator ClearSelected(){
        canSelect = false;
        yield return new WaitForSeconds(0.5f);
        foreach(Card card in SelectedCards){
            // card.StopAllCoroutines();
            StartCoroutine(card.FlipCard());
           
        }
        yield return new WaitForSeconds(0.02f);
        SelectedCards.Clear();

        canSelect = true;
    }



   




}
