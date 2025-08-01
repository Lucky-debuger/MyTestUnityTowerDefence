using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy _target;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed = 10f;

    public void Initialize(Enemy target, int damage)
    {
        _target = target;
        _damage = damage;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        MoveToEnemy();

        if (Vector3.Distance(transform.position, _target.transform.position) < 0.3f)
        {
            DealDamage();
        }
    }

    void MoveToEnemy()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void DealDamage()
    {
        _target.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
