using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    // ฟังก์ชันที่เรียกเมื่อกดปุ่ม Play (เริ่มเกม)
    public void PlayGame()
    {
        // โหลด Scene 1 (Gameplay)
        SceneManager.LoadSceneAsync(1);
    }

    // ฟังก์ชันที่ใช้เมื่อกดปุ่ม MainMenu (กลับไปที่หน้า MainMenu)
    public void MainMenu()
    {
        // โหลด Scene 0 (MainMenu)
        SceneManager.LoadSceneAsync(0);  
    }

    // ฟังก์ชันที่ใช้เมื่อกดปุ่ม Credits
    public void Credits()
    {
        // โหลด Scene Credits
        SceneManager.LoadSceneAsync(2);  
    }

    // ฟังก์ชันที่ใช้เมื่อกดปุ่ม Exit
    public void Exit()
    {
        // ออกจากเกม
        Application.Quit();  
    }

    // ฟังก์ชันสำหรับสลับเสียงระหว่าง 0 และ 0.135f
    public void ToggleMute()
    {
        if (AudioListener.volume == 0f)
        {
            // ถ้าเสียงถูกปิด, เปิดเสียงที่ระดับ 0.135f
            AudioListener.volume = 1f;
        }
        else
        {
            // ถ้าเสียงไม่เป็น 0, ปิดเสียง
            AudioListener.volume = 0f;
        }
    }
}
