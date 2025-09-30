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
        BuildManager.instance.SetTurretToBuild(standartTurret);
        Debug.Log(2);
    }

    public void SelectMissileLauncher()
    {
        BuildManager.instance.SetTurretToBuild(missileLauncher);
        Debug.Log(1);
    }
}
