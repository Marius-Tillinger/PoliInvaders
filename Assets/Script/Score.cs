using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public Text highScoreText;
    int score = 0;
    public int highScore = 0;

    private void Awake() 
    {
        instance = this;
    }
    
    private void Start() 
    {
        scoreText.text = score.ToString();
        highScoreText.gameObject.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
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
        highScoreText.gameObject.SetActive(true);
        highScoreText.text = "High Score: " + highScore.ToString();
        scoreText.gameObject.SetActive(false);
        highScoreText.transform.position = new Vector3(0, 0, 0);
    }

}
