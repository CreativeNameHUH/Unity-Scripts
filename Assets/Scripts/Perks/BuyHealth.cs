using UnityEngine;

public class BuyHealth : Variables
{
    public float PerkCost = 200f;
    public float PerkHealth = 200f;

    private void OnMouseUp()
    {
        if (PlayerExtraHealth) return;
        if (!(PlayerPoints >= 200)) return;

        PlayerHealth = PerkHealth;
        PlayerPoints -= PerkCost;
        PlayerExtraHealth = true;

        Debug.Log("Bought Health");
        Debug.Log("Points: " + PlayerPoints);
    }
}
