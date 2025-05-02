using UnityEngine;
using UnityEngine.SceneManagement;  // สำหรับการโหลด Scene

public class LoadSceneWithTimer : MonoBehaviour
{
    private float elapsedTime = 0f;   // ตัวแปรเก็บเวลาที่นับ
    private bool isTimerRunning = false;  // ตัวแปรตรวจสอบว่าเวลาเริ่มนับหรือยัง

    public float limitTime = 45f;

    void OnEnable()
    {
        // สมัครให้ทำงานเมื่อ Scene ถูกโหลด
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // ยกเลิกการสมัครเมื่อไม่ใช้
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // ฟังก์ชันที่เรียกเมื่อ Scene ถูกโหลด
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // เริ่มนับเวลาเมื่อ Scene ถูกโหลด
        isTimerRunning = true;
        elapsedTime = 0f;  // รีเซ็ตเวลาเมื่อ Scene ถูกโหลด
    }

    void Update()
    {
        // ถ้าเริ่มนับเวลาแล้ว
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;  // เพิ่มเวลาตามเวลาผ่านไปในแต่ละเฟรม

            // แสดงเวลาที่นับใน Console
            Debug.Log("Time Elapsed: " + elapsedTime.ToString("F2") + " seconds");

            // เมื่อครบ 45 วินาที, เรียกฟังก์ชันโหลด Scene
            if (elapsedTime >= limitTime)
            {
                LoadTargetScene();
                isTimerRunning = false;  // หยุดการนับเวลา
            }
        }
    }

    // ฟังก์ชันที่จะถูกเรียกเพื่อโหลด Scene
    public void LoadTargetScene()
    {
        // โหลด Scene ที่คุณต้องการ (Scene 0 ในที่นี้)
        SceneManager.LoadSceneAsync(0);
    }
}
