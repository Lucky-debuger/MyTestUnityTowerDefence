using System.Runtime.CompilerServices;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanse; // Разобраться с паттерном

    void Awake()
    {
        if (instanse != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }

        instanse = this;
    }
    public GameObject standartTurretPrefab;
    public GameObject missileLauncherPrefab;
    private GameObject turretToBuild;

    void Start()
    {
        turretToBuild = standartTurretPrefab;
    }


    public void GetTurretToBuild(GameObject turret) // Через этот метод я передаю туррель для стоительства BuildManager?
    {
        turretToBuild = turret;
    }
}
