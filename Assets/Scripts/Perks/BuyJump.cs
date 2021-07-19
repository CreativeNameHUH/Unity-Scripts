using UnityEngine;

public class BuyJump : Variables
{
    public float PerkCost = 300f;
    public float PerkJump = 4f;
    public bool AlreadyBought;

    private void OnMouseUp()
    {
        if (AlreadyBought) return;
        if (!(PlayerPoints >= PerkCost)) return;

        PlayerJump = PerkJump;
        PlayerPoints -= PerkCost;
        AlreadyBought = true;

        Debug.Log("Bought Jump");
        Debug.Log("Points: " + PlayerPoints);
    }
}
