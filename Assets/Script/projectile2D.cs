using UnityEngine;

public class projectile2D : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;       // เป้า
    public Rigidbody2D bulletPrefeb; // เก็บค่า Prefab ของลูกแก้ว

    private int projectileCount = 1; // จำนวนลูกแก้วที่สามารถยิงได้ (เริ่มต้นที่ 1 ลูก)

    void Update()
    {
        // เช็คกดเมาส์เพื่อยิง
        if (Input.GetMouseButtonDown(0) && projectileCount > 0)
        {
            ShootProjectile();  // ใช้ฟังชั่นยิง
        }

        // สูตรโกงรีเซ็ตลูกเเก้ว
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetProjectileCount(); //รีเซ็ตจำนวนลูกเเก้ว
        }
    }

    //ยิงลูกเเก้ว
    void ShootProjectile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            target.transform.position = new Vector2(hit.point.x, hit.point.y); // กำหนดตำแหน่งที่ลูกแก้วจะไป
            Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f); // คำนวณวิถีโค้ง

            Rigidbody2D firedBullet = Instantiate(bulletPrefeb, shootPoint.position, Quaternion.identity); // สร้างลูกแก้ว

            firedBullet.linearVelocity = projectileVelocity; // ตั้งค่า velocity ของลูกแก้ว
            projectileCount--;  // ลดจำนวนลูกแก้วที่สามารถยิงได้
            Debug.Log("Projectiles left: " + projectileCount); // แสดงจำนวนลูกแก้วที่เหลือ
        }
    }

    // ฟังก์ชันคำนวณวิถีโค้งของลูกแก้ว ที่จารย์สอนมา
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }

    // ฟังก์ชันรีเซ็ตจำนวนลูกแก้ว
    public void ResetProjectileCount()
    {
        projectileCount = 1;  // รีเซ็ตจำนวนลูกแก้วกลับมาเต็มที่ 1
        Debug.Log("Projectiles reset to: " + projectileCount);  // เอาไว้ดูเเทน UI ไปก่อน
    }

    // ฟังก์ชันเพื่อให้ UIController เข้าถึงจำนวนลูกแก้ว
    public int GetProjectileCount()
    {
        return projectileCount; // ส่งคืนค่าจำนวนลูกแก้วที่เหลือ
    }
}
