using System.Collections;
using TMPro;
using UnityEngine;

public class BuyHealth : Variables
{
    public float PerkCost = 2500f;
    public float PerkHealth = 200f;
    public float InteractionRadius = 1f;

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
        if (PlayerExtraHealth) return;
        if (!(PlayerPoints >= PerkCost)) return;

        PlayerHealth = PerkHealth;
        PlayerPoints -= PerkCost;
        PlayerExtraHealth = true;

        Debug.Log("Bought Health");
        Debug.Log("Points: " + PlayerPoints);
    }

    private void Update()
    {
        _ray = PCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, InteractionRadius))
        {
            BuyHealth perk = _hit.collider.GetComponent<BuyHealth>();

            if (perk == null) return;

            DisplayInfo.text = "Press E to buy Tia Maria " + PerkCost;

            if (Input.GetKeyUp(KeyCode.E))
            {
                Buy();
            }

            return;
        }

        StartCoroutine(Info());
    }
}