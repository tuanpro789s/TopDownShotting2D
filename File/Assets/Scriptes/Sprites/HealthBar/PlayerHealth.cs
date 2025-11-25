using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    public UnityEvent OnDeath;//nguoi choi chet
    public float safeTime;
    float _safeTimeCoolDown;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);


    }
    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    private void TakeDamage(int damage)
    {
        if (_safeTimeCoolDown <= 0)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
            {
                currentHealth = 0;
                OnDeath.Invoke();
            }
            _safeTimeCoolDown = safeTime;
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        _safeTimeCoolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
}
