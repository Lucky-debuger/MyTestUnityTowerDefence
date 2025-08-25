using UnityEngine;

public class BuildZoneVisual : MonoBehaviour
{
    public GameObject turret;
    public Vector3 positionOffset;
    public Color validColor = new Color(0, 1, 0, 0.1f);
    public Color invalidColor = new Color(1, 0, 0, 0.1f);
    private Color startColor;
    public MeshRenderer meshRend;

    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        startColor = meshRend.material.color;
        Debug.Log(startColor);
    }

    // void OnMouseEnter()
    // {
    //     meshRend.material.color = validColor;
    // }

    // void OnMouseDown()
    // {
    //     if (turret != null)
    //     {
    //         Debug.Log("Can't build there! - TODO: Display on screen.");
    //         return;
    //     }
    //     GameObject turretToBuild = BuildManager.instanse.GetTurretToBuild();
    //     turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    //     turret.transform.position = new Vector3(transform.position.x, positionOffset.y, transform.position.z);
    // }

    // void OnMouseExit()
    // {
    //     meshRend.material.color = startColor;
    // }

    public void TurnValid()
    {
        meshRend.material.color = validColor;
    }

    public void TurnInvalid()
    {
        meshRend.material.color = invalidColor;
    }
}
