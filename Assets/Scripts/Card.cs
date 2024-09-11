using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour,IPointerDownHandler
{
   [SerializeField] private Sprite faceSprite;
   [SerializeField] private Sprite backSprite;
   [SerializeField] private GameObject cardObj;

   private Image cardImg;
   private bool isFace = false;
   public bool canFlip = true;

   private void Awake()
   {
      cardImg = GetComponentInChildren<Image>();
      cardImg.sprite = backSprite;
      
   }

    public void OnPointerDown(PointerEventData eventData){
      OnClickCard();
    }

   public void OnClickCard(){
        Debug.Log($"Click this card {this.gameObject.name}");
        if(canFlip){
         StartCoroutine(FlipCard());
        }
   }
   public IEnumerator FlipCard(){
      canFlip = false;
      if(!isFace){
         for(float i = 0f;i<=180f;i+=10f){
            cardObj.transform.rotation = Quaternion.Euler(0f,i,0f);
            if(i==90){
               cardImg.sprite = faceSprite;
            }
            yield return new WaitForSeconds(0.05f);
         }
      }
      else{
         for(float i = 0f;i<=180f;i-=10f){
            cardObj.transform.rotation = Quaternion.Euler(0f,i,0f);
            if(i==90){
               cardImg.sprite = backSprite;
            }
            yield return new WaitForSeconds(0.05f);
         }
      }
      canFlip = true;
      isFace = !isFace;
      
   }

//refactor function
public IEnumerator RefactorFlipCard(){
      canFlip = false;
      float rotateY = 0;
      float maxRotateY = 0;
      Sprite nextSprite;
      if(!isFace){
          maxRotateY= 180f;
          rotateY = 10f;
          nextSprite = faceSprite;
      }
      else{
         maxRotateY = -180f;
         rotateY = -10f;
         nextSprite = backSprite;
      }
         for(float i = 0f;i<=maxRotateY;i+=rotateY){
            cardObj.transform.rotation = Quaternion.Euler(0f,i,0f);
            if(i==90){
               cardImg.sprite = nextSprite;
            }
            yield return new WaitForSeconds(0.05f);
         }
      canFlip = true;
      isFace = !isFace;
      
   }

}
