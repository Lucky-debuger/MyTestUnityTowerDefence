using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
    }
}
