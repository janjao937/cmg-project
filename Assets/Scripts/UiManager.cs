using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI latestScoreText;
    [SerializeField] private TextMeshProUGUI latestTurnText;
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI turnText;
   [SerializeField] private TextMeshProUGUI gridSizeText;

   [SerializeField] private GameObject restartPanel;
   [SerializeField] private GameObject homePanel;
   [SerializeField] private TextMeshProUGUI scoreSummary;

   public void SetLatestText(int score,int turn){
    latestScoreText.text = $"Latest Score:{score}";
    latestTurnText.text = $"Latest Turn:{turn}";
   }

   public void ResetCurrent(){
    scoreText.text = $"Score:0";
    turnText.text = $"Turn:0";
   }
   public void SetCurrentScoreText(int score)=>scoreText.text =$"Score:{score}";
    public void SetCurrentTurnText(int turn)=>turnText.text =$"Turn:{turn}";

    public void SetGridSize(int row,int col){
        gridSizeText.text = $"{row}x{col}";
    }

    public void SetHomePanel(bool isActive)=>homePanel.SetActive(isActive);
    public void SetRestartPanel(bool isActive,int score,int turn){
        scoreSummary.text =$"Score:{score}|Turn:{turn}";
        restartPanel.SetActive(isActive);
    }
}
