using UnityEngine;
using System.Collections.Generic;
using System.IO;
public class Character : MonoBehaviour
{
    public string characterID;
    public string name;
    private int anxiety=0;
    public Color characterAura;

    public List<Emotion> emotionsList = new List<Emotion>();

    public Dictionary<string,Emotion> emotions = new Dictionary<string, Emotion>();

    [System.Serializable]
    public class Emotion{
        public string name;
        public float intensity; //-100 - 100
        public float angle;

        public Emotion(string name, float intensity, float angle){
            this.name = name;
            this. intensity = intensity;
            this. angle = angle;
        }
    }

    [System.Serializable]
    public class CharacterSave{
            public Dictionary<string,Emotion> emotions = new Dictionary<string, Emotion>();
    }

    void Start(){
        string path = Application.dataPath +"/CharacterStorage/" + characterID + ".json";
        if(File.Exists(path)){
            UploadJSONFile(characterID);

        }else{
            emotionsList.Add(new Emotion("Joy",0f,0f));
            emotionsList.Add(new Emotion("Wrath",0f,90f));
            emotionsList.Add(new Emotion("Sadness",0f,180f));
            emotionsList.Add(new Emotion("Fear",0f,270f));

            emotions["Joy"] = new Emotion("Joy",0f,0f);
            emotions["Wrath"] = new Emotion("Wrath",0f,90f);
            emotions["Sadness"] = new Emotion("Sadness",0f,180f);
            emotions["Fear"] = new Emotion("Fear",0f,270f);
        }

    }

    void CalculateEmotionColor(){

    }

    void ModifyEmotion(Emotion emotion){

    }

    void SyncronizeDictionary(){
        emotions.Clear();
        foreach (var e in emotionsList)
        {
            emotions[e.name]= e;
        }
    }

    void UploadJSONFile(string characterID){
        string path = Application.dataPath +"/CharacterStorage/" + characterID + ".json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json,this);

            SyncronizeDictionary();
        }

    }

    public void SaveJSONFile(){
        string folder = Application.dataPath +"/CharacterStorage";
        if(!Directory.Exists(folder)){
            Directory.CreateDirectory(folder);
        }
        string path = folder + "/" + characterID + ".json";
        string json= JsonUtility.ToJson(this,true);
        File.WriteAllText(path , json);
    }
}
