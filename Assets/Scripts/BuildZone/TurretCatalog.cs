using UnityEngine;

public class TurretCatalog : MonoBehaviour
{
    public static TurretCatalog instance; // Разобраться с паттерном

    void Awake()
    {
        if (instance!= null)
        {
            Debug.Log("More than one TurretCatalog in scene!");
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

    public void SetTurretToBuild(TurretBlueprint turretBlueprint) // Через этот метод я передаю туррель для стоительства TurretCatalog?
    {
        turretToBuild = turretBlueprint;
        BuildSystem.Instance.SetSelectedBlueprint(turretToBuild);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
