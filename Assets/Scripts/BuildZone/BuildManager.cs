using System.Runtime.CompilerServices;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanse;

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

    void Start()
    {
        turretToBuild = standartTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
