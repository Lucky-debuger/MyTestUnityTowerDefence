using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 offsetOnBuild;
    public Vector3 offsetOnDrag;
    public LayerMask layer;
    public LayerMask buildZoneLayer;
    public TurretBlueprint turretBlueprint;
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

    private Vector3 GetWorldPosition(PointerEventData eventData) // [ ] Разобраться, как работает
    {
        Ray ray = _mainCamera.ScreenPointToRay(eventData.position);
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
