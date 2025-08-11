using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float _attackRange = 10f;
    [SerializeField] protected float _attackRate = 1f;
    [SerializeField] protected int _damage = 10;
    [SerializeField] protected Transform _projectileSpawnPoint;

    protected float _nextAttackTime;
    protected Enemy _currentTarget;
    public bool isAcitive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAcitive)
        {
            return;
        }

        RotateHead();
        if (Time.time >= _nextAttackTime)
        {
        FindTarget();
        if (_currentTarget != null)
        {
            Attack();
            _nextAttackTime = Time.time + 1f / _attackRate;
        }
        }
        
    }

    protected virtual void FindTarget()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, _attackRange, LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length == 0)
        {
            _currentTarget = null;
            return;
        }
        float closestDistance = Mathf.Infinity;
        foreach (var enemyCollider in enemiesInRange)
        {
            float distance = Vector3.Distance(transform.position, enemyCollider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                // _currentTarget = enemyCollider.GetComponentInParent<Enemy>();
                _currentTarget = enemyCollider.transform.root.GetComponent<Enemy>();
            }
               
        }
    }

    protected abstract void Attack();   
    protected abstract void RotateHead();
}
