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

            // ทำลายผู้เล่นออกจาก Scene
            Destroy(other.gameObject);  // ทำลาย GameObject ที่มี Tag "Player"
        }
    }
}
