using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class PlayerHealth : Variables
{
    public string GameOverScene;

    public TextMeshProUGUI DisplayHealth;

    public void TakeDamage(float damage)
    {
        PlayerHealth -= damage;

        if (PlayerHealth <= 0f)
        {
            Debug.Log("You are dead");
            PlayerPrefs.SetString("PlayerKills", PlayerTotalKills.ToString());
            SceneManager.LoadScene(GameOverScene);
        }

        StartCoroutine(RegenerateHealth());
    }

    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(5);

        if (PlayerExtraHealth)
        {
            while (PlayerHealth != 200f)
            {
                if (PlayerHealth > 190f)
                {
                    PlayerHealth = 200f;
                }
                else
                {
                    PlayerHealth += 20f;
                }
                yield return new WaitForSeconds(5);
            }
        }
        else
        {
            while (PlayerHealth != 100f)
            {
                if (PlayerHealth > 90f)
                {
                    PlayerHealth = 100f;
                }
                else
                {
                    PlayerHealth += 10f;
                }
                yield return new WaitForSeconds(5);
            }
        }
    }

    private void Start()
    {
        DisplayHealth.text = "Health: " + PlayerHealth;
    }

    private void Update()
    {
        DisplayHealth.text = "Health: " + PlayerHealth;
    }
}