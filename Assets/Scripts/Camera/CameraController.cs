using UnityEngine;


public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minOrthographicScale = 4f;
    public float maxOrthographicScale = 14;

    public float upperBound = -3;
    public float bottomBound = 22;
    public float leftBound = -20;
    public float rightBound = 5;

    private Vector3 direction;

    void Update()
    {
        if (Input.GetKeyDown("t")) // Old Inpue System
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }

        Vector2 current2DPos = new Vector2(transform.position.x, transform.position.z);

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if (transform.position.z >= upperBound) return;

            direction = transform.forward;
            direction.y = 0;
            direction = direction.normalized;
            transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            if (transform.position.z <= bottomBound) return;
            direction = transform.forward;
            direction.y = 0;
            direction = direction.normalized;
            transform.Translate(direction * -panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (transform.position.x >= rightBound) return;

            transform.Translate(transform.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            if (transform.position.x <= leftBound) return;

            transform.Translate(-transform.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Camera camera = GetComponent<Camera>();
            camera.orthographicSize = Mathf.Clamp
            (
                camera.orthographicSize - scroll * scrollSpeed,
                minOrthographicScale,
                maxOrthographicScale
            );
            // float cameraOrthographicSize = camera.orthographicSize;
            // cameraOrthographicSize -= scroll * scrollSpeed;
            // cameraOrthographicSize = Mathf.Clamp(cameraOrthographicSize, minOrthographicScale, maxOrthographicScale);
            // camera.orthographicSize = cameraOrthographicSize;

        }
    }
}
