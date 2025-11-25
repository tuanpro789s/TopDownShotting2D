using UnityEngine;
using UnityEngine.Events;

public class Health1 : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int currentHealth;
    public HealthBar healthBar;
    public AudioSource damageSound;
    public AudioSource deathSound;
    public UnityEvent OnDeath;
    public bool isBoss = false; // Xác định đối tượng có phải là boss không
    public bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDam(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Death();
            }
            else
            {
                damageSound.Play();
                if (healthBar != null)
                    healthBar.UpdateBar(currentHealth, maxHealth);
            }
        }
    }

    private void Death()
    {
        currentHealth = 0;
        isDead = true;
        deathSound.Play();
        OnDeath.Invoke();
        if (!isBoss)
        {
            Destroy(gameObject, 0.125f); // Delay cho kẻ thù thường để hiệu ứng có thể phát
        }
        
    }
    public UnityEvent onDeath;

    private void Awake()
    {
        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    public void Die()
    {
        // Logic khi chết
        onDeath.Invoke(); // Thông báo cho bất kỳ ai đang lắng nghe
    }

}
