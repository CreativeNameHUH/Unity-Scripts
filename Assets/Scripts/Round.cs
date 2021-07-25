using TMPro;
using UnityEngine;

public class Round : Variables
{
    public TextMeshProUGUI Text;

    private int _round = 1;

    private void NextRound()
    {
        _round++;
        EnemyAmount = 5 * _round;
        EnemyHealth += 10;
        PlayerTotalKills = PlayerKillsInRound;
        PlayerKillsInRound = 0;

        Text.text = _round.ToString();
        GameNewObjectPool = true;
        GameNewSpawnTimer = true;
        Debug.Log("New Round: " + _round);
    }

    void Start()
    {
        Text.text = _round.ToString();
    }

    void Update()
    {
        if (PlayerKillsInRound == EnemyAmount)
        {
            NextRound();
        }
    }
}
