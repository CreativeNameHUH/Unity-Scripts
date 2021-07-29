using TMPro;
using UnityEngine;

public class Round : Variables
{
    public TextMeshProUGUI Text;

    private int _round = 1;

    private void NextRound()
    {
        PlayerKillsInRound = 0;
        _round++;
        EnemyAmount = 2 * _round;
        EnemyHealth += 10;

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
        if (_round == 1 && PlayerKillsInRound == 3)
        {
            NextRound();
        }
        if (_round != 1 && PlayerKillsInRound == EnemyAmount)
        {
            NextRound();
        }
    }
}
