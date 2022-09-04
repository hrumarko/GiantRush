using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score =1;

    public void ScoreUp(){
        score++;
        scoreText.text = "Lv." + score.ToString();
    }

    public void ScoreDown(){
        score--;
        scoreText.text = "Lv." + score.ToString();
    }
}
