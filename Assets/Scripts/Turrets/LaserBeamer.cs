using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBeamer : Tower
{
    [SerializeField] float rotationSpeed;

    [Header("Use bullet (default)")]
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private ParticleSystem impactEffect;

    private bool _isAttacking = false;


    public LineRenderer lineRenderer;

    protected override void Attack()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, _projectileSpawnPoint.position);
        lineRenderer.SetPosition(1, _currentTarget.position);

        if (!_isAttacking) 
        {
            StartImpactEffect();
            _isAttacking = true;
        }
        
        MoveImpactEffect();

    }

    protected override void RotateHead()
    {
        if (_currentTarget == null) return;

        GameObject partToRotate = transform.Find("PartToRotate").gameObject;
        Vector3 direction = _currentTarget.transform.position - partToRotate.transform.position;
        partToRotate.transform.rotation = Quaternion.Slerp(partToRotate.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
    }

    protected override void DisableLaser()
    {
        lineRenderer.enabled = false;
        if (_isAttacking)
        {
            StopImpactEffect();
            _isAttacking = false;
        }

    }

    private void StartImpactEffect() // Разобраться, как работает
    {
        impactEffect.Play();
    }

    private void StopImpactEffect()
    {
        impactEffect.Stop();
    }

    private void MoveImpactEffect()
    {
        Vector3 dir = _projectileSpawnPoint.position - _currentTarget.position;
        impactEffect.transform.position = _currentTarget.position + dir.normalized * 1f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
}
