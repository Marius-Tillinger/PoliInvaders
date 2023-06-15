using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public Text highScoreText;
    int score = 0;
    int highScore = 0;

    private void Awake() 
    {
        instance = this;
    }
    
    public int getScore()
    {
        return score;
    }
    
    private void Start() 
    {
        WriteScoreToCSV(score);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.gameObject.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetHighScore()
    {
        if (score > highScore) 
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void ShowHighScore() 
    {
        //WriteScoreToCSV(highScore);
        highScoreText.gameObject.SetActive(true);
        highScoreText.text = "High Score: " + highScore.ToString();
        scoreText.gameObject.SetActive(false);
        
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
    



}
