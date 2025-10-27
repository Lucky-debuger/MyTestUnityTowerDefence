using UnityEngine;

public class LaserBeamer : Tower
{
    [SerializeField] float rotationSpeed;
    [SerializeField] private Projectile _projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Attack()
    {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, Quaternion.identity);
        projectile.Initialize(_currentTarget, _damage);
    }

    protected override void RotateHead()
    {
        if (_currentTarget == null) return;

        GameObject partToRotate = transform.Find("PartToRotate").gameObject;
        Vector3 direction = _currentTarget.transform.position - partToRotate.transform.position;
        partToRotate.transform.rotation = Quaternion.Slerp(partToRotate.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
    }
}
