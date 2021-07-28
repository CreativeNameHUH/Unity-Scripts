using System.Collections;
using TMPro;
using UnityEngine;

public class UpgradeGun : Variables
{
    public float UpgradeCost = 3000f;
    public float DamageMultiplier = 1.5f;
    public int MagazineUpgrade = 5;
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

    private void Update()
    {
        _ray = PCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, InteractionRadius))
        {
            UpgradeGun upgrade = _hit.collider.GetComponent<UpgradeGun>();

            if (upgrade == null) return;

            DisplayInfo.text = "Press E to upgrade your gun for " + UpgradeCost;

            if (Input.GetKeyUp(KeyCode.E))
            {
                Buy();
            }

            return;
        }

        StartCoroutine(Info());
    }

    private void Buy()
    {
        if (!(PlayerPoints >= UpgradeCost)) return;

        PlayerGunDamage *= DamageMultiplier;
        PlayerGunMagSize += MagazineUpgrade;
        PlayerGunUpgrade = true;

        PlayerPoints -= UpgradeCost;

        Debug.Log("Bought an upgrade: " + PlayerGunDamage + " dmg");
        Debug.Log("Points: " + PlayerPoints);
    }
}