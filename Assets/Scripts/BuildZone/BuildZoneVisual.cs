using UnityEngine;

public class BuildZoneVisual : MonoBehaviour
{
    public Color validColor = new Color(0, 1, 0, 0.1f);
    public Color invalidColor = new Color(1, 0, 0, 0.1f);
    
    private MeshRenderer zoneRenderer;
    private BoxCollider zoneCollider;
    private MeshFilter zoneMeshFilter;


    void Start()
    {
        zoneCollider = GetComponent<BoxCollider>();
        zoneMeshFilter = GetComponent<MeshFilter>();
        zoneRenderer = GetComponent<MeshRenderer>();
    }


}
