using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreText;
    [HideInInspector] public int score = 0;
    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
