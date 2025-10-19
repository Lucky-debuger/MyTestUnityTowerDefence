using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public static BuildSystem Instance;
    private TurretBlueprint selectBlueprint;
    private BuildZone currentZone;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Есть больше одного экземплятра BuildSystem!");
            return;
        }
        Instance = this;
    }

    public void SetSelectedBlueprint(TurretBlueprint blueprint)
    {
        selectBlueprint = blueprint;
    }

    public void TryBuild(BuildZone buildZone)
    {

    }

    public void OnZoneHover(BuildZone buildZone)
    {

    }

    public void CancelBuild()
    {

    }
    
    private void BuildTurret(BuildZone buildZone, TurretBlueprint turretBlueprint)
    {
        
    }
}
