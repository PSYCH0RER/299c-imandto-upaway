using UnityEngine;
using UnityEngine.SceneManagement;  // สำหรับการโหลด Scene

public class ButtonHandler : MonoBehaviour
{
    // ฟังก์ชันที่จะถูกเรียกเมื่อคลิกปุ่มและโหลด Scene ตามชื่อที่ได้รับ
    public void OnButtonClick(string sceneName)
    {
        // โหลด Scene ตามชื่อที่ได้รับ
        SceneManager.LoadScene(sceneName);
    }

    // ฟังก์ชันสำหรับรีเซ็ตฉาก
    public void OnPlayAgainButtonClick()
    {
        // เริ่มเกมใหม่โดยการโหลดฉากปัจจุบันใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // โหลดฉากที่กำลังใช้งานอยู่
        Time.timeScale = 1f;  // รีสตาร์ทเวลา (หากคุณหยุดเวลาในเกม เช่น ตอน Game Over)
    }
}
