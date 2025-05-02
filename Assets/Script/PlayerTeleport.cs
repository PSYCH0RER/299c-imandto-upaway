using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;  // ใช้เก็บ GameObject ของ Orb ที่มี Tag "Teleporter"
    private projectile2D projectileScript;

    void Start()
    {
        // หาตำแหน่ง destination ของ "Teleporter" (Orb) ที่มี Tag "Teleporter"
        FindLatestTeleporter();

        projectileScript = GetComponent<projectile2D>();
    }

    void Update()
    {
        // กดปุ่ม Q เพื่อวาร์ปไปยังตำแหน่งของ Teleporter (Orb)
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (currentTeleporter != null) // ตรวจสอบว่า destination ถูกกำหนดไว้
            {
                // วาร์ป Player ไปยังตำแหน่งของ Orb ที่มี Tag "Teleporter"
                transform.position = currentTeleporter.transform.position;

                // ทำลาย destination object (Orb) เมื่อ Player วาร์ปไป
                Destroy(currentTeleporter.gameObject);  // ทำลาย object ปลายทาง

                // ค้นหา Teleporter ใหม่ที่ถูกสร้างขึ้น (Orb ใหม่)
                FindLatestTeleporter();

                projectileScript.ResetProjectileCount();
            } else
            
            {
                FindLatestTeleporter();
    
            }
        }
    }

    // ฟังก์ชันนี้จะค้นหา Orb ที่มี Tag "Teleporter" ในฉาก
    private void FindLatestTeleporter()
    {
        // ค้นหาวัตถุทั้งหมดที่มี Tag "Teleporter"
        GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");

        if (teleporters.Length > 0)
        {
            // เลือก Orb ตัวสุดท้ายที่พบเป็น destination ใหม่
            currentTeleporter = teleporters[teleporters.Length - 1];  // เลือก Orb ตัวสุดท้ายที่สร้าง
        }
    }
}
