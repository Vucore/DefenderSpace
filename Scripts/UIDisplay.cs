using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider sliderHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        //scoreText.text = "0"; 
        sliderHealth.maxValue = playerHealth.GetHealth();
    }
    
    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        sliderHealth.value = playerHealth.GetHealth();
    }
}
