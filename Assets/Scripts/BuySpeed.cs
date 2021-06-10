using UnityEngine;

public class BuySpeed : Variables
{
    public float PerkCost = 100f;
    public float PerkSprint = 10f;
    public float PerkSpeed = 4f;
    public bool AlreadyBought;
    void OnMouseUp()
    {
        if (AlreadyBought) return;
        if (!(PlayerPoints >= 100f)) return;
        
        PlayerSpeed = PerkSpeed;
        PlayerSprint = PerkSprint;
        PlayerPoints -= PerkCost;
        AlreadyBought = true;

        Debug.Log("Bought Speed");
        Debug.Log("Points: " + PlayerPoints);
    }
}
