using System.Collections;
using TMPro;
using UnityEngine;

public class BuySpeed : Variables
{
    public float PerkCost = 2000f;
    public float PerkSprint = 10f;
    public float PerkSpeed = 4f;
    public float InteractionRadius = 1f;
    public bool AlreadyBought;

    public Camera PCamera;
    public TextMeshProUGUI DisplayInfo;

    private Ray _ray;
    private RaycastHit _hit;

    private IEnumerator Info()
    {
        yield return new WaitForSeconds(1);
        DisplayInfo.text = "";
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, InteractionRadius);
    }

    private void Buy()
    {
        if (AlreadyBought) return;
        if (!(PlayerPoints >= PerkCost)) return;

        PlayerSpeed = PerkSpeed;
        PlayerSprint = PerkSprint;
        PlayerPoints -= PerkCost;
        AlreadyBought = true;

        Debug.Log("Bought Speed");
        Debug.Log("Points: " + PlayerPoints);
    }

    private void Update()
    {
        _ray = PCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, InteractionRadius))
        {
            BuySpeed perk = _hit.collider.GetComponent<BuySpeed>();

            if (perk == null) return;

            DisplayInfo.text = "Press E to buy Tequila " + PerkCost;

            if (Input.GetKeyUp(KeyCode.E))
            {
                Buy();
            }

            return;
        }

        StartCoroutine(Info());
    }
}