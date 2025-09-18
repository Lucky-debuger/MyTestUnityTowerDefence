using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    private Transform _target;
    private int _damage;
    [SerializeField] private float _speed = 10f;

    public void Initialize(Transform target, int damage)
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
        // Debug.Log(_target);

        if (Vector3.Distance(transform.position, _target.transform.position) < 0.3f)
        {
            HitTarget();
        }
    }

    void MoveToEnemy()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void HitTarget()
    {
        if (impactEffect)
        {
            GameObject insEffect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(insEffect, 2f);
        }

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DealDamage(_target); // Когда стоит писать нижнее подчеркивание, а когда нет?
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        // for (int i = 0; i < colliders.Length; i++)
        // {
        //     Debug.Log(colliders[i].transform.root.tag); // Почему всё получать через Transform?
        // }

        foreach (Collider collider in colliders)
        {

            if (collider.transform.root.tag == "Enemy")
            {
                DealDamage(collider.transform);
            }
        }
    }

    void DealDamage(Transform enemy) // Почему именно Transform мы могли написать по видео вместо Enemy? 
    {
        enemy.root.GetComponent<Enemy>().TakeDamage(_damage);
        Debug.Log("ААА");
        // Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected() // Чем OnDrawGizmosSelected отличается от OnDrawGizmos?
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
