using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Player playerS;
    public int minDamage;
    public int maxDamage;  
    Health health;  

    void Start()
    {
        health = GetComponent<Health>();  
    }

    public void TakeDamage(int damage)
    {
        health.TakeDam(damage);

    }
    private void OnTriggerEnter2D(Collider2D collision)
        { 
        if (collision.CompareTag("Player"))  
        {
            playerS = collision.GetComponent<Player>();  
            DamagePlayer(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  
    {
        if (collision.CompareTag("Player"))  
        {
            playerS = null;
        }
    }

    void DamagePlayer()
    {
        if (playerS != null)  
        {
            int damage = UnityEngine.Random.Range(minDamage, maxDamage); 
            Debug.Log("Player take damage " + damage);
            playerS.TakeDamage(damage); 
        }
    }
}
