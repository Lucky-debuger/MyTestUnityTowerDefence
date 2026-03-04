using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Vector3 offsetOnBuild;
    [SerializeField] private Vector3 offsetOnDrag;
    [SerializeField] private LayerMask layer;
    [SerializeField] private LayerMask buildZoneLayer;
    [SerializeField] private TurretBlueprint turretBlueprint;

    private Camera _mainCamera;
    private GameObject _dragablePreview;
    
    [SerializeField] private GameObject turretPreview;


    void Start()
    {
        _mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        TurretCatalog.instance.SetTurretToBuild(turretBlueprint);

        if (!Shop.instance.CanBuyTurret)
        {
            Debug.Log("You haven't enough money to buy the turret!");
            return;
        }

        _dragablePreview = Instantiate(turretPreview);
        _dragablePreview.transform.position = GetWorldPosition(eventData) + offsetOnDrag;
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (!Shop.instance.CanBuyTurret) return;

        BuildZone buildZone = DragPreviewAndGetBuildZone(eventData);

        if (buildZone == null)
        {
            if (BuildSystem.Instance.currentZone != null)
            {
                BuildSystem.Instance.ResetBuildZone();
            }
            return;
        }

        if (buildZone != BuildSystem.Instance.currentZone)
        {
            BuildSystem.Instance.ResetBuildZone();
        }

        if (buildZone != null)
        {
            BuildSystem.Instance.OnBuildZoneHover(buildZone);
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (!Shop.instance.CanBuyTurret) return;

        Destroy(_dragablePreview);
        BuildSystem.Instance.ResetBuildZone();
        BuildZone buildZone = DragPreviewAndGetBuildZone(eventData);
        BuildSystem.Instance.TryBuild(buildZone, offsetOnBuild);
    }


    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        
        Ray ray = _mainCamera.ScreenPointToRay(eventData.position);

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 50);
        Debug.Log($"EventData.position: {eventData.position}");
        Debug.Log($"ray.origin {ray.origin}");

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layer))
        {
            return hit.point + offsetOnBuild;
        }
        return Vector3.zero;
    }


    private BuildZone DragPreviewAndGetBuildZone(PointerEventData eventData)
    {
        Vector3 worldPos = GetWorldPosition(eventData);
        _dragablePreview.transform.position = worldPos + offsetOnDrag;
        BuildZone buildZone = BuildSystem.Instance.GetBuildZoneAtPosition(worldPos, buildZoneLayer);
        return buildZone;
    }

}
