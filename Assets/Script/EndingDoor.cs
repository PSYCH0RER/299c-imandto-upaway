using UnityEngine;
using UnityEngine.SceneManagement;  // สำหรับการโหลดฉากใหม่

public class EndingDoor : MonoBehaviour
{
    // สำหรับการใช้ Collider ที่ตั้งเป็น Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าถ้าชนกับ Player
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
