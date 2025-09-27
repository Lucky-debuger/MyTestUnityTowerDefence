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
    public GameObject standartTurretPrefab;
    public GameObject missileLauncherPrefab;
    private GameObject turretToBuild;

    void Start()
    {
        turretToBuild = standartTurretPrefab;
    }

    public void SetTurretToBuild(GameObject turret) // Через этот метод я передаю туррель для стоительства BuildManager?
    {
        turretToBuild = turret;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
