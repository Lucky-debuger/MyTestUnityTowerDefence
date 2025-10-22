using UnityEditor;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public static BuildSystem Instance;
    public BuildZone currentZone;
    private TurretBlueprint selectBlueprint;
    

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
        if (!CanBuild(buildZone))
        {
            CancelBuild();
            return;
        }

        BuildTurret(buildZone, selectBlueprint);

    }

    public void OnBuildZoneHover(BuildZone buildZone)
    {
        if (buildZone != currentZone)
        {
            ResetBuildZone();
            buildZone.highlighter.SetNormalColor();
            currentZone = buildZone;
            if (currentZone != null)
            {
                if (CanBuild(currentZone))
                {
                    currentZone.GetComponent<BuildZoneHighlighter>().HighlightValid();
                }
                else
                {
                    currentZone.GetComponent<BuildZoneHighlighter>().HighlightInvalid();
                }
            }
        }
    }

    public void ResetBuildZone()
    {
        if (currentZone == null) return;

        currentZone.highlighter.SetNormalColor();
        currentZone = null;
    }

    private bool CanBuild(BuildZone buildZone)
    {
        if (buildZone == null || !buildZone.IsEmpty) return false; // Что за IsEmpy?
        return true;
    }

    public void CancelBuild()
    {

    }

    public BuildZone GetBuildZoneAtPosition(Vector3 position, LayerMask buildZoneLayer)
    {
        RaycastHit hit;
        Debug.DrawRay(position, Vector3.down, Color.red, 2f);
        if (Physics.Raycast(position, Vector3.down, out hit, 10f, buildZoneLayer))
        {
            return hit.collider.GetComponent<BuildZone>();
        }
        return null;
    }
    
    private void BuildTurret(BuildZone buildZone, TurretBlueprint turretBlueprint)
    {
        buildZone.turret = Instantiate(turretBlueprint.prefab, buildZone.transform.position, Quaternion.identity);
    }
}
