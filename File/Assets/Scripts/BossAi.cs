using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossAi : MonoBehaviour
{
    public GameObject bullet; // Prefab viên đạn
    public float bulletSpeed = 5f; // Tốc độ viên đạn
    public float timeBtwFire = 2f; // Thời gian giữa các lần bắn
    private float fireCoolDown; // Đếm ngược thời gian bắn tiếp
    public bool roaming = false; // Không cần dùng cho boss trong ví dụ này
    public Seeker seeker;
    public float moveSpeed;

    private void Start()
    {
        fireCoolDown = timeBtwFire;
    }

    void Update()
    {
        fireCoolDown -= Time.deltaTime;
        if (fireCoolDown <= 0)
        {
            BossFireCircleShot();
            fireCoolDown = timeBtwFire; // Reset thời gian cooldown
        }
        Vector2 targetPosition = FindTarget();
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * bulletSpeed);
    }

    Vector2 FindTarget()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            return playerPos + Vector3.left * 6; // Boss luôn ở x đơn vị phía trên người chơi
        } 
        return transform.position;
    }

    void BossFireCircleShot()
    {
        int numberOfBullets = 15;
        float angleStep = 720f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector3 bulletDirection = rotation * Vector3.up;
            var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletDirection * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
