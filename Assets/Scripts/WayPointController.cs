using UnityEngine;

public class WayPointController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
