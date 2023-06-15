using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class Score : MonoBehaviour
{
    private static Score instance;
    private int score = 0;
    public Text scoreText;

    public static Score Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Score>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Score>();
                    singletonObject.name = "Score (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    public int CurrentScore
    {
        get { return score; }
    }
    
    private void WriteScoreToCSV(int score)
    {
        string filePath = "scores.csv";
        
        Debug.Log("Intra in csv PALYERUYY");
        
        string fileName = "scores.csv";
        //filePath = Path.Combine(Application.persistentDataPath, fileName);
        //filePath = "D:\\PoliInvaders-main\\scores.csv";
        string m_Path = Application.dataPath + "/HighscoreTable/score.csv";
        filePath = m_Path;
        Debug.Log("CSV File Path: " + m_Path);

        // Check if the CSV file exists
        bool fileExists = File.Exists(filePath);

        // Create or append to the CSV file
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            // If the file doesn't exist, write the header row
            if (!fileExists)
            {
                sw.WriteLine("Score");
            }

            // Write the score to a new row
            sw.WriteLine(score.ToString());
        }
    }
    
    /*public void AddScoreToLeaderboard()
    {
        
        // Call the AddHighscoreEntry method from the HighscoreTable script
        HighscoreTable highscoreTable = FindObjectOfType<HighscoreTable>();
        if (highscoreTable != null)
        {
            highscoreTable.AddHighscoreEntry(score);
        }
    }*/
    



    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score:\n" + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score:\n" + score.ToString();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = "Score:\n" + score.ToString();
    }
}
