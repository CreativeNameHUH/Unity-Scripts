using TMPro;

public class DisplayPoints : Variables
{
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ScoreText.text = "Points: " + PlayerPoints;
    }
}
