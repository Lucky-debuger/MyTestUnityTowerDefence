using UnityEngine;

public class LaserBeamer : Tower
{
    [SerializeField] float rotationSpeed;

    [Header("Use bullet (default)")]
    [SerializeField] private Projectile _projectilePrefab;

    [Header("Use laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    [SerializeField] ParticleSystem impactEffect;
    protected override void Attack()
    {
        lineRenderer.SetPosition(0, _projectileSpawnPoint.position);
        lineRenderer.SetPosition(1, _currentTarget.position);
    }

    protected override void RotateHead()
    {
        if (_currentTarget == null)
        {
            lineRenderer.enabled = false;
            impactEffect.Stop();
            return;
        }
        else
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }

        GameObject partToRotate = transform.Find("PartToRotate").gameObject;
        Vector3 direction = _currentTarget.transform.position - partToRotate.transform.position;
        partToRotate.transform.rotation = Quaternion.Slerp(partToRotate.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        impactEffect.transform.position = _currentTarget.transform.position;
        Debug.Log(impactEffect.transform.position);
    }
}
