public class UpgradeGameArea : Variables
{
    public float UpgradeCost = 4000f;
    private void OnMouseUp()
    {
        if (PlayerPoints >= UpgradeCost && GameAreaSize < 6)
        {
            UpgradeCost += 2000f;
            GameAreaSize += 1;
            GameAreaUpdate = true;
        }

    }
}
