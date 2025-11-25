using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score = 0;

    private void Start()
    {
        UpdateScore(0);  // Khởi tạo điểm số ban đầu là 0
    }

    // Hàm này được gọi để tăng điểm
    public void IncrementScore(int points)
    {
        score += points;
        UpdateScore(score);
    }

    // Hàm này cập nhật điểm số trên giao diện người dùng
    private void UpdateScore(int newScore)
    {
        text.text = newScore.ToString();
    }
}
