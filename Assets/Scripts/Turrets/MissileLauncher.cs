using UnityEngine;

public class MissileLauncher : Tower
{
    [SerializeField] float rotationSpeed;
    [SerializeField] private Projectile _projectilePrefab;
    protected override void RotateHead()
    {
        if (_currentTarget == null) return;
        GameObject partToRotate = transform.Find("PartToRotate").gameObject;
        Vector3 direction = _currentTarget.transform.position - partToRotate.transform.position;
        partToRotate.transform.rotation = Quaternion.Slerp(partToRotate.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        Debug.DrawRay(partToRotate.transform.position, direction, Color.red);
    }

    protected override void Attack()
    {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
        projectile.Initialize(_currentTarget, _damage);
    }
}
