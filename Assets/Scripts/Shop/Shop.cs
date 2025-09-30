using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public void SelectStandardTurret()
    {
        BuildManager.instance.SetTurretToBuild(standartTurret);
        Debug.Log(2);
    }

    public void SelectMissileLauncher()
    {
        BuildManager.instance.SetTurretToBuild(missileLauncher);
        Debug.Log(1);
    }
}
