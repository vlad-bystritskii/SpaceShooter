using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    void Start()
    {
        _scoreText.text = "Score: 0";
    }

    void Update()
    {
        
    }

    public void UpdateScoreText(int score)
    {
        _scoreText.text = "Score: " + score;
    }
}
