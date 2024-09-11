using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Score = default;
    public int Turn = default;


    public void AddScore(){
        Score++;
    }
    public void AddTurn(){
        Turn++;
    }
    public void ResetScore(){
        Score = 0;
        Turn = 0;
    }

}
