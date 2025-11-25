using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbemyController : MonoBehaviour //gay xac thuong khi nhan vat cham vao enemy
{
    Player playerS;
    public int minDamage;
    public int maxDamage;
    Health health; //mau cua enemy
    public void Start() 
    {
        health = GetComponent<Health>();

    }
    public void TakeDamage(int damage)
    {
       health.TakeDam(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)// khi quai di chuyen gan nhan vat
    {
        if (collision.CompareTag("Player"))
        {
            playerS = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f); //sau 0s thi thuc hien va sau 0.1 giay se gay sat thuong tiep

        }
    }
    private void OnTriggerExit2D(Collider2D collision)// khi quai roi khoi nhan vat
    {
        if (collision.CompareTag("Player"))
        {
            playerS = null;
            CancelInvoke("DamagePlayer");

        }
    }
    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);// lay ngau nhien gia tri toi thieu va toi da
        Debug.Log("Player take damage " + damage);
        playerS.TakeDamage(damage);

    }
}
