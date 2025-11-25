using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool goodSizeBullet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !goodSizeBullet)
            {
            int damage=Random.Range(minDamage,maxDamage);
            collision.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy") && goodSizeBullet)
            {
            int damage = Random.Range(minDamage, maxDamage);
            collision.GetComponent<EbemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss") && goodSizeBullet)
        {
            int damage = Random.Range(minDamage, maxDamage);
            collision.GetComponent<BossHealth>().TakeDamage(damage); // Sửa đổi tên component phù hợp
            Destroy(gameObject);
        }

    }
}