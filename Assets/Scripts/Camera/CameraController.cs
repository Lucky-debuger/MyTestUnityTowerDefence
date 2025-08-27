using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 100f;

    private Vector3 direction;

    void Update()
    {
        Debug.Log(Input.mousePosition.y);
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            direction = transform.forward;
            direction.y = 0;
            direction = direction.normalized;
            Debug.Log(direction);
            transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            direction = transform.forward;
            direction.y = 0;
            direction = direction.normalized;
            Debug.Log(direction);
            transform.Translate(direction * -panSpeed * Time.deltaTime, Space.World);
        }
    }
}
