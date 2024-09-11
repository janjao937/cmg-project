using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomUnique 
{
    public static List<int> RandomUniqueList(int min,int max){

        List<int> randomNumberList = new List<int>();
        if(min>=max) min=0;

        for(int i=min;i<=max;i++){
            randomNumberList.Add(i);
        }

        //random
        randomNumberList = randomNumberList.OrderBy(_=>System.Guid.NewGuid()).ToList();
        return randomNumberList;
    }
}
