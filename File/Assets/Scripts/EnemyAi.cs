using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAi : MonoBehaviour
{
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;
    public bool updateContinuesPath;
    public Seeker seeker;
    // them chuc nang ban
    public bool isShootable = false;// Tick neu muon enemy ban dan
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCoolDown;
    bool reachDestination = false;// kiem tra xem Ai da di het duong chua
    Path path;
    Coroutine movecoroutine;
    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
    }
    private void Update()
    {
        fireCoolDown -= Time.deltaTime;
        if (fireCoolDown < 0)
        {
            fireCoolDown = timeBtwFire;
            EnemyFireBullet();
        }
    }
    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);// tao ra vien dan moi
        //them luc cho vien dan
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().transform.position; //lay vi tri nguoi choi
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone())// neu no chua di den diem cuoi cung thi khong tinh toan lai
            seeker.StartPath(transform.position, target, OnPathComplete);// Tinh toan duong di ngan nhat
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            MoveToTarget();
        }

    }
    void MoveToTarget()
    {
        if (movecoroutine != null)
            StopCoroutine(movecoroutine);
        movecoroutine = StartCoroutine(MoveToTargetCoroutine());


    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;// tinh toan huong
            //tinh toan luc
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;//Tac dong luc vao vi tri nhan vat
            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);// chung ta co chuyen sang dia diem tiep theo khong
            if (distance < nextWPDistance)
            {
                currentWP++;

            }
            yield return null;// tam dung va thuc hien sau 1 khoang thoi gian



        }
        reachDestination = true;
    }
    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position; //lay vi tri nguoi choi
        if (roaming == true)// AI chay xung quanh va ban nguoi choi
        {
            return (Vector2)playerPos + (Random.Range(10f, 50f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
        }
        else
        {
            return playerPos; // AI chay den truc tiep den nguoi choi
        }
    }
}