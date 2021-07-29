using System.Collections;
using TMPro;
using UnityEngine;

public class BuyJump : Variables
{
    public float PerkCost = 3000f;
    public float PerkJump = 4f;
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

        PlayerJump = PerkJump;
        PlayerPoints -= PerkCost;
        AlreadyBought = true;

        Debug.Log("Bought Jump");
        Debug.Log("Points: " + PlayerPoints);
    }

    private void Update()
    {
        _ray = PCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, InteractionRadius))
        {
            BuyJump perk = _hit.collider.GetComponent<BuyJump>();

            if (perk == null) return;

            DisplayInfo.text = "Press E to buy Absinthe " + PerkCost;

            if (Input.GetKeyUp(KeyCode.E))
            {
                Buy();
            }

            return;
        }

        StartCoroutine(Info());
    }
}