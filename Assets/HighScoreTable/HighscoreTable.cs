using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    //private List<HighscoreEntry> highscoreEntryList;
    
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        //Debug.Log("Container: " + entryContainer);
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        highscoreEntryTransformList = new List<Transform>();


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            Debug.Log("Initializing table with default values...");
            
            //Add default values
            AddHighscoreEntry(1);
            AddHighscoreEntry(2);
            AddHighscoreEntry(3);
            AddHighscoreEntry(4);
            
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        //Sort entry list by Score
        for(int i=0;i<highscores.highscoreEntryList.Count;i++)
        {
            for(int j=i+1;j<highscores.highscoreEntryList.Count;j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        
        highscoreEntryTransformList = new List<Transform>();
        
        //highscoreEntryList.Sort((entry1, entry2) => entry2.score.CompareTo(entry1.score));

        
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        /*Highscores highscores = new Highscores{highscoreEntryList = highscoreEntryList};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));*/
        
        

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
            
        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
                
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
                
        }
            
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            
        int score =highscoreEntry.score;
        entryTransform.Find("scoreRank").GetComponent<Text>().text = score.ToString();

        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
        
        
        
        
        transformList.Add(entryTransform);
        
        //optional add alea pare impare
        
    }
    
    private void AddHighscoreEntry(int score)
    {
        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score};
        
        //Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }
        
        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);
        
        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    //Clasa pentru a stoca un singur highscore
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        
    }
}
