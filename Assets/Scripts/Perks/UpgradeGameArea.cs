using System.Collections;
using TMPro;
using UnityEngine;

public class UpgradeGameArea : Variables
{
    public float UpgradeCost = 4000f;
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
            UpgradeGameArea upgrade = _hit.collider.GetComponent<UpgradeGameArea>();

            if (upgrade == null) return;

            DisplayInfo.text = "Press E to upgrade this arena for " + UpgradeCost;

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
        if (PlayerPoints >= UpgradeCost && GameAreaSize < 6)
        {
            PlayerPoints -= UpgradeCost;
            UpgradeCost += 2000f;
            GameAreaSize += 1;
            GameAreaUpdate = true;
        }
    }
}