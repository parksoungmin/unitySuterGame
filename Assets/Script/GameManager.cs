using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public void UpScore()
    {
        score = score + 10;
        scoreText.text = $"Score : {score}";
    }
}
