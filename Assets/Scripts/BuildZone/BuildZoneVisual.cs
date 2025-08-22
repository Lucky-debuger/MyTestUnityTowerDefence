using UnityEngine;

public class BuildZoneVisual : MonoBehaviour
{
    public Color validColor = new Color(0, 1, 0, 0.1f);
    public Color invalidColor = new Color(1, 0, 0, 0.1f);
    
    private MeshRenderer zoneRenderer;
    private BoxCollider zoneCollider;

    void Start()
    {
        zoneCollider = GetComponent<BoxCollider>();
        zoneRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        // Используем встроенный меш куба
        meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");

        // Загружаем заранее созданный материал
        Material zoneMaterial = Resources.Load<Material>("BuildZoneMaterial");
        zoneRenderer.material = zoneMaterial;

        // Масштабируем под размер коллайдера
        transform.localScale = zoneCollider.size;

    }
}
