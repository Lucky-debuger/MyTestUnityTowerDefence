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
<<<<<<< HEAD

=======
    [SerializeField] ParticleSystem impactEffect;
>>>>>>> 1071e95743c89720d344a15d2a3a71a0e2dd3711
    protected override void Attack()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, _projectileSpawnPoint.position);
        lineRenderer.SetPosition(1, _currentTarget.position);
<<<<<<< HEAD

        if (!_isAttacking) 
        {
            StartImpactEffect();
            _isAttacking = true;
        }
        
        MoveImpactEffect();

=======
>>>>>>> 1071e95743c89720d344a15d2a3a71a0e2dd3711
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
