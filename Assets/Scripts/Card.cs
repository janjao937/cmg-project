using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour,IPointerDownHandler
{
   [SerializeField] private Sprite backSprite;
   private Sprite faceSprite;
   [SerializeField] private GameObject cardObj;
   [SerializeField] private PlayerSelected playerSelected;
   [SerializeField]private bool isFace = false;

   private Image cardImg;
   private int spriteIndex = 0;

   public PlayerSelected SetPlayerSelected{set=>playerSelected = value;}
   public int SpriteIndex {get=>spriteIndex;set=>spriteIndex = value;}
   public Sprite GetFaceSprite {get =>faceSprite;}//for check sprite on GameManager

   private void Awake()
   {
      cardImg = GetComponentInChildren<Image>();
      cardImg.sprite = backSprite;
      isFace = false;      
   }

    public void OnPointerDown(PointerEventData eventData){
      OnClickCard();
    }

   //set face sprite
   public void SetFaceSprite(Sprite faceSprite){
      this.faceSprite=faceSprite;//just change back to face
   }

   private void OnClickCard(){
        Debug.Log($"Click this card {this.gameObject.name}");
        if(playerSelected.canSelect){
         if(playerSelected.SelectedCards.Count==0){
            playerSelected.SelectedCards.Add(this);
            StartCoroutine(FlipCard());
         }
         else if(playerSelected.SelectedCards.Count==1){
            playerSelected.SelectedCards.Add(this);
            StartCoroutine(FlipCard());
            playerSelected.CheckResult();
         }
         else{
            return;
         }
        }
   }
  
   public IEnumerator FlipCard(){
    
      playerSelected.canSelect = false;
      if(!isFace){
            isFace = !isFace;
         for(float i = 0f;i<=180f;i+=10f){
             if(cardObj!=null){
            cardObj.transform.rotation = Quaternion.Euler(0f,i,0f);

             }
            if(i==90f){
              if(cardImg!=null) cardImg.sprite = faceSprite;
            }
            yield return new WaitForSeconds(0.02f);
         }
      }
      else if(isFace){
            isFace = !isFace;
         for(float i = 180f;i>=0;i-=10f){
            if(cardObj!=null){
            cardObj.transform.rotation = Quaternion.Euler(0f,i,0f);

            }
            if(i==90f){
               if(cardImg!=null)cardImg.sprite = backSprite;
            }
            yield return new WaitForSeconds(0.02f);
         }
      }
      playerSelected.canSelect  =  true;
   
      
   }
void OnDestroy()
{
   cardObj=null;
   StopAllCoroutines();
}
//refactor function
// public IEnumerator RefactorFlipCard(){
//       canFlip = false;
//       float rotateY = 0;
//       float maxRotateY = 0;
//       Sprite nextSprite;
//       if(!isFace){
//           maxRotateY= 180f;
//           rotateY = 10f;
//           nextSprite = faceSprite;
//       }
//       else{
//          maxRotateY = -180f;
//          rotateY = -10f;
//          nextSprite = backSprite;
//       }
//          for(float i = 0f;i<=maxRotateY;i+=rotateY){
//             cardObj.transform.rotation = Quaternion.Euler(0f,i,0f);
//             if(i==90){
//                cardImg.sprite = nextSprite;
//             }
//             yield return new WaitForSeconds(0.05f);
//          }
//       canFlip = true;
//       isFace = !isFace;
      
//    }

}
