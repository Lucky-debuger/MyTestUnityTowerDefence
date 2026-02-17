using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;
    public GameObject prefab;
    public string enemyType;

    void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        healthBar.SetHealth(_currentHealth);
    }
    public void Die()
    {
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }
}
