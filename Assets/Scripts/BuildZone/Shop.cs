using System;
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

    public bool CanBuyTurret => PlayerStats.Money >= BuildSystem.Instance.GetSelectedBlueprint.cost;

    public void BuySelectedTurret()
    {
        int turretCost = BuildSystem.Instance.GetSelectedBlueprint.cost;
        PlayerStats.Money -= turretCost;
        Debug.Log($"You buy a turret for a {turretCost} and now you have {PlayerStats.Money} money.");
    }
}
