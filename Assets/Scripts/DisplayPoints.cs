using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoints : Variables
{
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        scoreText.text = "Points: " + PlayerPoints;
    }
}
