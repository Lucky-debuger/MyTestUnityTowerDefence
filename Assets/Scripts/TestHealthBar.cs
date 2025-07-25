using UnityEngine;
using UnityEngine.InputSystem;

public class TestHealthBar : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public float time = 0f;
    public int damageAmount = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // time += Time.deltaTime * 3f;
        // if (time >= 3)
        // {
        //     TakeDamage(20);
        //     time = 0;
        // }
    }

    public void TakeDamage(InputAction.CallbackContext context)
    {
        // Debug.Log("Current phase:" + context.phase);
        if (context.started)
        {
            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);
        }

    }
}
