using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab3DModel;
    public LayerMask groundLayer;
    private Vector3 distanceAboveGround = new Vector3(0f, 0.55f, 0f);
    private GameObject currentModel;
    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("Он на меня кликнул!");
        currentModel = Instantiate(prefab3DModel);
        currentModel.GetComponent<SimpleProjectileTower>().isAcitive = false;
        UpdateModelPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateModelPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        currentModel.GetComponent<SimpleProjectileTower>().isAcitive = true;
        currentModel = null;
    }

    private void UpdateModelPosition(PointerEventData eventData)
    {
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        // Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);


        if (Physics.Raycast(ray, out hit, 100, groundLayer))
        {
            currentModel.transform.position = hit.point + distanceAboveGround;
            // Debug.Log("Попал в объект: " + hit.collider.name);
        }
    }
}
