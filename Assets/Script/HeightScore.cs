using UnityEngine;
using UnityEngine.UI;  // สำหรับการใช้งาน UI Text
using TMPro;  // สำหรับการใช้งาน TextMeshPro

public class HeightScore : MonoBehaviour
{
    public TMP_Text heightText;  // ใช้ TMP_Text แทน Text
    public Transform player; // อ้างอิงไปยัง Transform ของ Player

    void Update()
    {
        // ตรวจสอบว่ามีการอ้างอิงไปยัง heightText และ player หรือไม่
        if (heightText != null && player != null)
        {
            // รับค่า Y-position ของผู้เล่น
            float heightInFeet = player.position.y * 3.28084f;  // แปลงจากเมตรเป็นฟุต (1 เมตร = 3.28084 ฟุต)

            // อัปเดต Text UI ให้แสดงค่าความสูง
            heightText.text = heightInFeet.ToString("F1") + " ft";  // ใช้ "F1" เพื่อแสดงทศนิยม 1 ตำแหน่ง
        }
    }
}
