using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Shop in scene!");
            return;
        }
        instance = this;
    }
    public void SelectStandardTurret()
    {
        TurretCatalog.instance.SetTurretToBuild(standartTurret);
    }

    public void SelectMissileLauncher()
    {
        TurretCatalog.instance.SetTurretToBuild(missileLauncher);
    }
}
