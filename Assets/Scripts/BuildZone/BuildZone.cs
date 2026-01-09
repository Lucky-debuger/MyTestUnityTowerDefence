using UnityEditor;
using UnityEngine;

public class BuildZone : MonoBehaviour
{
    [Header("Data")]
    public GameObject turret;

    [Header("References")]
    public BuildZoneHighlighter highlighter;

    public bool IsEmpty => turret == null;
    // Полная запись
    // public bool IsEmpty
    // { 
    //     get { return turret == null; }
    // }

    void Start()
    {
        highlighter = GetComponent<BuildZoneHighlighter>();
    }
}
