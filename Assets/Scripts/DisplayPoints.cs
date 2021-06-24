using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoints : Variables
{
    TextMeshPro scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        scoreText.text = "Points: " + PlayerPoints;
    }
}
