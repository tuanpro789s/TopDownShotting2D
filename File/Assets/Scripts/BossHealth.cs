using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 2000;  // Đặt máu tối đa của boss là 2000
    [HideInInspector] public int currentHealth;
    private TimeScore timeScore;
    public HealthBar healthBar;

    public float invulnerabilityDuration = 0.5f;  // Thời gian không thể bị sát thương
    private float invulnerabilityTimer;
    public bool isInvulnerable = false;  // Boss có đang trong trạng thái không thể bị sát thương không

    public bool isDead = false;
    public UnityEvent OnDeath;
    public AudioSource damageSound;
    public AudioSource deathSound;

    private void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (invulnerabilityTimer <= 0 && !isInvulnerable)
        {
            currentHealth -= damage;
            damageSound.Play();

            if (healthBar != null)
                healthBar.UpdateBar(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                isDead = true;
                deathSound.Play();
                OnDeath.Invoke();
                Die();
            }

            invulnerabilityTimer = invulnerabilityDuration;
        }
    }

    private void Update()
    {
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    public void Die()
    {
        if (timeScore != null)
        {
            timeScore.IncrementScore(10);  // Tăng điểm khi tiêu diệt boss
        }
        Destroy(gameObject);  // Hủy boss
    }

    public void Death()
    {
        
        Debug.Log("Boss is dead!");
    }
}
