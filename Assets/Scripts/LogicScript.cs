using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour, IDataPersistance
{
    public TextMeshProUGUI scoreText;
    public int score;
    public int lvlThreshold;

    public void Start()
    {
        //scoreText = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameState state)
    {
        score = state.totalScore;
        print("starting score is " + score);
        scoreText.text = score.ToString();
    }

    public void SaveData(ref GameState state) 
    {
        state.totalScore = score;
    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >= lvlThreshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
