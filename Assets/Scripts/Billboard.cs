using UnityEngine;

public class Billboard : MonoBehaviour
{

    public Transform cam;
    // Update is called once per frame
    void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main.transform;
        }
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
