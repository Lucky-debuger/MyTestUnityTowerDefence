using System.Runtime.CompilerServices;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; // Разобраться с паттерном

    void Awake()
    {
        if (instance!= null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }
    public TurretBlueprint standartTurretPrefab;
    public TurretBlueprint missileLauncherPrefab;
    private TurretBlueprint turretToBuild;

    void Start()
    {
        turretToBuild = standartTurretPrefab;
    }

    public void SetTurretToBuild(TurretBlueprint turretBlueprint) // Через этот метод я передаю туррель для стоительства BuildManager?
    {
        turretToBuild = turretBlueprint;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
