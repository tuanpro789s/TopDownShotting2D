
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int currentHealth;
    private TimeScore timeScore;
    public HealthBar healthBar;
    private float safeTime;
    public float safeTimeDuration = 0f;
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

    public void TakeDam(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;
            if (healthBar != null)
                healthBar.UpdateBar(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                isDead = true;
                deathSound.Play();
                OnDeath.Invoke();
                Die();
            }
            else
            {
                damageSound.Play();
            }

            safeTime = safeTimeDuration;
        }
    }

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void Death()
    {
        if (gameObject.CompareTag("Player"))
        {
            UiManager.instance.ShowGameOver();
        }

        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.125f);
        }
    }

    private void Update()
    {
        if (safeTime > 0)
            safeTime -= Time.deltaTime;
    }

    private void Die()
    {
        if (timeScore != null)
        {
            timeScore.IncrementScore(1); // Tăng điểm khi tiêu diệt enemy
        }
        // Hủy đối tượng
        Destroy(gameObject);

        // Kiểm tra nếu đối tượng này là Player thì mới hiển thị Game Over
        if (gameObject.tag == "Player")
        {
            if (UiManager.instance != null)
                UiManager.instance.ShowGameOver();  // Hiển thị màn hình Game Over
        }
    }


}
