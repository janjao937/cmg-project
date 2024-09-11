using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,IPointerDownHandler
{

   public void OnClickCard(){
        Debug.Log($"Click this card {this.gameObject.name}");
   }
    public void OnPointerDown(PointerEventData eventData){
      OnClickCard();
    }
}
