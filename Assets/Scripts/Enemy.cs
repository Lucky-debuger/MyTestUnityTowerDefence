using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;
    public GameObject prefab;
    public string enemyType;

    private void Die()
    {
        EnemyFactory.Instance.ReturnToPool(gameObject, enemyType);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize()
    {

    }

    void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void TakeDamage(InputAction.CallbackContext context)
    // {
    //     // Debug.Log("Current phase:" + context.phase);
    //     if (context.started)
    //     {
    //         _currentHealth -= 20;
    //         healthBar.SetHealth(_currentHealth);
    //     }

    // }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        healthBar.SetHealth(_currentHealth);
    }
    // private void Die()
    // {
    //     Destroy(gameObject);
    // }
}
