using UnityEngine;
using UnityEngine.SceneManagement;  // สำหรับการโหลดฉากใหม่

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverUI;   // UI ที่จะปรากฏขึ้นเมื่อชนกับผู้เล่น

    // สำหรับการใช้ Collider ที่ตั้งเป็น Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าถ้าชนกับ Player
        if (other.CompareTag("Player"))
        {
            // ทำให้ UI GAME OVER แสดงขึ้น
            gameOverUI.SetActive(true);

            // หยุดการเคลื่อนที่หรือทำให้เกมหยุด
            Time.timeScale = 0f;  // หยุดเกมชั่วคราว

            // ถ้าต้องการให้เล่นใหม่อาจจะใช้การโหลดฉากใหม่หลังจากคลิกปุ่ม
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // โหลดฉากใหม่
        }
    }
}
