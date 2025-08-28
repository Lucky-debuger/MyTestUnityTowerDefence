using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms.Impl;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 100f;
    public float scrollSpeed = 5f;
    public float minOrthographicScale = 4f;
    public float maxOrthographicScale = 14;

    private Vector3 direction;

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            direction = transform.forward;
            direction.y = 0;
            direction = direction.normalized;
            transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            direction = transform.forward;
            direction.y = 0;
            direction = direction.normalized;
            transform.Translate(direction * -panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(transform.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
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
