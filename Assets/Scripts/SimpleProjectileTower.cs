using UnityEngine;

public class SimpleProjectileTower : Tower
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Projectile _projectilePrefab;
    protected override void Attack()
    {
        // Create projectile
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
        projectile.Initialize(_currentTarget, _damage);

    }

    protected override void RotateHead()
    {
        if (_currentTarget == null) return;
        GameObject towerHead = transform.Find("Sphere").gameObject;
        Vector3 direction = _currentTarget.transform.position - towerHead.transform.position;
        towerHead.transform.rotation = Quaternion.Slerp(towerHead.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        Debug.DrawRay(towerHead.transform.position, direction, Color.red);
    }
}
