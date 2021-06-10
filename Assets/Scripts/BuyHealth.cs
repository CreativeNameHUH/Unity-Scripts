using UnityEngine;

public class BuyHealth : Variables
{
    public float PerkCost = 200f;
    public float PerkHealth = 200f;
    public bool AlreadyBought;

    void OnMouseUp()
    {
        if (AlreadyBought) return;
        if (!(PlayerPoints >= 200)) return;

        PlayerHealth = PerkHealth;
        PlayerPoints -= PerkCost;
        AlreadyBought = true;

        Debug.Log("Bought Health");
        Debug.Log("Points: " + PlayerPoints);
    }
}
