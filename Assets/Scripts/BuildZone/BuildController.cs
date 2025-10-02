using UnityEditor;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static BuildController Instance;

    [Header("Settings")]
    public LayerMask buildZoneLayer;

    private BuildZone currentZone;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Есть больше одного экземпляря BuildController");
            return;
        }
        Instance = this;
    }

    public void OnBuildZoneHover(BuildZone buildZone)
    {
        if (buildZone != currentZone)
        {
            ResetHighlighter();
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

    public void ResetHighlighter()
    {
        if (currentZone == null) return;

        currentZone.GetComponent<BuildZoneHighlighter>().SetNormalColor();
        currentZone = null;
    }

    public bool CanBuild(BuildZone buildZone)
    {
        if (buildZone == null || !buildZone.IsEmpty) return false;

        Debug.Log("Ты можешь тут строить!");
        return true;

    }
}
