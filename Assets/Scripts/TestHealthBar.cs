using UnityEngine;
using UnityEngine.InputSystem;

public class TestHealthBar : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private float time = 0f;
    [SerializeField] private int damageAmount = 20;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);
        }

    }
}
