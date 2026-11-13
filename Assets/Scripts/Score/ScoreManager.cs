using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
       scoreText.text = "Score: " + score;
    }
        
    public void AddScore(float amount)
    {
        score += amount;
        UpdateScore();
    }
    public void RemoveScore(float amount)
    {
        score -= amount; 
        UpdateScore();
    }

}
