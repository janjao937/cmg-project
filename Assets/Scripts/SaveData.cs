using System.Reflection.Emit;
using System.Net;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void Save(PlayerData playerData){
        // Debug.Log("GameEnd");
        // Debug.Log("Score: "+playerData.Score);
        // Debug.Log("Turn: "+playerData.Turn);

        //Save Json
        Data data = new Data(playerData.Score,playerData.Turn);
        string json  = JsonUtility.ToJson(data);
        using(StreamWriter writer = new StreamWriter(Application.dataPath+Path.AltDirectorySeparatorChar+"saveData.json"))
        {
            writer.Write(json);
        }
    }
    public void Load(UiManager uiManager){
        if(File.Exists(Application.dataPath+Path.AltDirectorySeparatorChar+"saveData.Json")){
            string json = string.Empty;
            using(StreamReader reader = new StreamReader(Application.dataPath+Path.AltDirectorySeparatorChar+"saveData.Json")){
                json = reader.ReadToEnd();
            }

            Data data = JsonUtility.FromJson<Data>(json);
            uiManager.SetLatestText(data.Score,data.Turn);
            // player?.SetPlayerData(data.Name,data.Score);
        }else{
            Debug.Log("file does not exits");
             uiManager.SetLatestText(0,0);
        }
        
    }
}
