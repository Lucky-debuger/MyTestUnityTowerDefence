using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret selected");
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
    }
}
