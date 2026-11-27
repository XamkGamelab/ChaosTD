using System.Xml.Linq;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public float startingScore = 200;
    public float score;

    [SerializeField] private GameStateSystem gameStateSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        score = startingScore;
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
        if (score < 0)
            gameStateSystem.SwitchState(GameStateSystem.GameState.GameOver);

        UpdateScore();
    }

}
