using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;// noi tao ra vien dan
    public float TimeBtwFire = 3f; // toc do dan 
    public float bulletForce = 20f;// luc cua vien dan khi roi khoi sung
    private float timeBtwFire;
    public GameObject fireEffect;
    public int maxAmmo = 30; // Số lượng đạn tối đa trong một lần nạp
    private int currentAmmo; // Số lượng đạn hiện tại
    private float reloadTime = 1.5f; // Thời gian nạp đạn
    private bool isReloading = false;
    public AudioSource shootingAudioSource;
    public AudioClip fireSound;
    public AudioClip reloadSound;

    private void Start()
    {
        currentAmmo = maxAmmo;
        shootingAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RotateGun();
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        // Giảm thời gian chờ còn lại cho đến khi bắn được lần tiếp theo
        if (timeBtwFire > 0)
        {
            timeBtwFire -= Time.deltaTime;
        }
        // Kiểm tra xem người chơi có nhấn chuột và liệu có thể bắn được không
        if (Input.GetMouseButtonDown(0) && timeBtwFire <= 0 && currentAmmo > 0)
        {
            timeBtwFire = TimeBtwFire;
            FireBullet();
        }

        // Nạp đạn khi nhấn R và có đạn để nạp
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !isReloading)
        {
            StartCoroutine(Reload());
        }

    }
    IEnumerator Reload()
    {
        isReloading = true;
        shootingAudioSource.PlayOneShot(reloadSound);
        Debug.Log("Dang nap dan...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void RotateGun()// di chuyen sung theo goc quay chuot
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;


        // chinh sung xoay nguoc khi quay ve ben trai
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);


    }
    void FireBullet()// quan ly dan va toc do dan
    {
        currentAmmo--; // Giảm số lượng đạn khi bắn
        timeBtwFire = Time.deltaTime;// Reset thời gian chờ cho đến lần bắn tiếp theo
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Instantiate(fireEffect, firePos.position, transform.rotation, transform);// Tạo viên đạn và hiệu ứng bắn đạn
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);// Thêm lực vào viên đạn để nó bay đi
        shootingAudioSource.PlayOneShot(fireSound);


    }
}
