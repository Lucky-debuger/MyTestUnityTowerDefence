using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 offset;
    public LayerMask layer;
    public TurretBlueprint turretBlueprint;
    private Camera mainCamera;
    private GameObject dragObject;

    void Start()
    {
        mainCamera = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // BuildManger.SetTurretToBuild()
        // BuildManager.instance.SetTurretToBuild(turretBlueprint);
        Debug.Log(turretBlueprint.prefab.name);
        dragObject = Instantiate(BuildManager.instance.GetTurretToBuild().prefab);
        dragObject.transform.position = GetWorldPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragObject.transform.position = GetWorldPosition(eventData);
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
            return hit.point + offset;
        }
        return Vector3.zero;
    }
}
