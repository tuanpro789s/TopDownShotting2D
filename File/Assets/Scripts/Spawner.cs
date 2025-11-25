using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của kẻ thù thường
    public float startTimeBtwSpawn = 2f; // Thời gian giữa các lần spawn
    public Transform playerTransform; // Vị trí của người chơi
    private float timeBtwSpawn; // Đếm ngược thời gian để spawn kế tiếp
    private int currentEnemies = 0; // Số lượng kẻ thù hiện tại trên sân
    private int maxEnemies = 10; // Số lượng tối đa kẻ thù có thể có trên sân cùng lúc
    public float spawnRadius = 20f; // Khoảng cách gần người chơi mà kẻ thù có thể xuất hiện
    public bool playerAlive = true; // Giả sử người chơi còn sống

    private void Update()
    {
        if (timeBtwSpawn <= 0 && currentEnemies < maxEnemies && playerAlive) // Chỉ spawn nếu người chơi còn sống
        {
            SpawnEnemyNearPlayer();
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    private void SpawnEnemyNearPlayer()
    {
        Vector2 spawnPos = playerTransform.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        currentEnemies+= 3; // Tăng số lượng kẻ thù hiện tại
    }

    public void EnemyDied() // Hàm này được gọi khi một kẻ thù bị tiêu diệt
    {
        currentEnemies--; // Giảm số lượng kẻ thù hiện tại
        if (currentEnemies <= 7)
            SpawnEnemyNearPlayer();
    }

    // Gọi hàm này khi người chơi chết
    public void PlayerDied()
    {
        playerAlive = false;
    }
}
