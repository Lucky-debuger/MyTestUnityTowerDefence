using UnityEngine;

public class LaserBeamer : Tower
{
    [SerializeField] float rotationSpeed;

    [Header("Use bullet (default)")]
    [SerializeField] private Projectile _projectilePrefab;

    [Header("Use laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    protected override void Attack()
    {
        lineRenderer.SetPosition(0, _projectileSpawnPoint.position);
        lineRenderer.SetPosition(1, _currentTarget.position);
        Debug.Log(Time.time.ToString() + " attack!");
    }

    protected override void RotateHead()
    {
        if (_currentTarget == null) return;

        GameObject partToRotate = transform.Find("PartToRotate").gameObject;
        Vector3 direction = _currentTarget.transform.position - partToRotate.transform.position;
        partToRotate.transform.rotation = Quaternion.Slerp(partToRotate.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
    }
}
