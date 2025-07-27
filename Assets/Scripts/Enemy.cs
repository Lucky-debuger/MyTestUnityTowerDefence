using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void TakeDamage(InputAction.CallbackContext context)
    {
        // Debug.Log("Current phase:" + context.phase);
        if (context.started)
        {
            _currentHealth -= 20;
            healthBar.SetHealth(_currentHealth);
        }

    }
}
