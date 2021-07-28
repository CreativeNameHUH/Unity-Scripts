using TMPro;
using UnityEngine;

public class DisplayStats : Variables
{
    public TextMeshProUGUI DisplayKills;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        DisplayKills.text = PlayerPrefs.GetString("PlayerKills");
    }
}