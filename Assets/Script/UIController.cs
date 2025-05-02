using UnityEngine;
using UnityEngine.UI; // สำหรับการใช้งาน UI

public class UIController : MonoBehaviour
{
    public Text projectileText;  // Text UI ที่แสดงจำนวนลูกแก้ว
    public projectile2D projectileScript;  // อ้างอิงถึงสคริปต์ projectile2D เพื่อดึงข้อมูล projectileCount

    void Start()
    {
        UpdateProjectileUI();  // เรียกใช้เพื่อแสดงจำนวนลูกแก้วตอนเริ่มเกม
    }

    void Update()
    {
        // รีเฟรช UI ทุกครั้งที่จำนวนลูกแก้วใน projectile2D มีการเปลี่ยนแปลง
        UpdateProjectileUI();
    }

    // ฟังก์ชันอัปเดต UI
    void UpdateProjectileUI()
    {
        // ดึงค่า projectileCount จาก projectile2D และแสดงใน UI
        projectileText.text = projectileScript.GetProjectileCount() + "/1";  // แสดงผลใน UI
    }
}
