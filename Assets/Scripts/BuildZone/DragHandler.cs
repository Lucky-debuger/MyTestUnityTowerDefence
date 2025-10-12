using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 offsetOnBuild;
    public Vector3 offsetOnDrag;
    public LayerMask layer;
    public LayerMask buildZoneLayer;
    public TurretBlueprint turretBlueprint;
    private Camera mainCamera;
    private GameObject dragObject;

    void Start()
    {
        mainCamera = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        TurretCatalog.instance.SetTurretToBuild(turretBlueprint);
        dragObject = Instantiate(turretBlueprint.prefab);
        dragObject.transform.position = GetWorldPosition(eventData) + offsetOnDrag;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos = GetWorldPosition(eventData);
        dragObject.transform.position = worldPos + offsetOnDrag;

        BuildZone buildZone = GetBuildZoneAtPosition(worldPos);
        BuildController.Instance.OnBuildZoneHover(buildZone);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(dragObject);
    }

    private Vector3 GetWorldPosition(PointerEventData eventData) // Разобраться, как работает
    {
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layer))
        {
            return hit.point + offsetOnBuild;
        }
        return Vector3.zero;
    }

    private BuildZone GetBuildZoneAtPosition(Vector3 position)
    {
        RaycastHit hit;
        Debug.DrawRay(position, Vector3.down, Color.red, 2f);
        if (Physics.Raycast(position, Vector3.down, out hit, 10f, buildZoneLayer))
        {
            Debug.Log("Я навёлся на BuildZone");
            return hit.collider.GetComponent<BuildZone>();
        }
        Debug.Log("Я не навёлся на BuildZone");
        return null;
    }
}
