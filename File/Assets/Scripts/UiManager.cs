using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance; // Tạo một instance để dễ dàng truy cập từ các script khác.
    public GameObject bnGameOver; // Đây là button hoặc panel của Game Over.

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        bnGameOver.SetActive(false); // Đảm bảo button game over không hiển thị khi bắt đầu game.
    }

    public void ShowGameOver()
    {
        bnGameOver.SetActive(true); // Hàm này sẽ được gọi khi nhân vật chết.
    }
}
