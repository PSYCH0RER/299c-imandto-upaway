using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;  // Prefab ของ Orb ที่จะสร้าง

    void Start()
    {
        // สร้าง Orb ใหม่ที่ตำแหน่งของ Teleporter
        CreateNewOrb();
    }

    void CreateNewOrb()
    {
        if (orbPrefab != null)
        {
            // สร้าง Orb ใหม่ที่ตำแหน่งของ Teleporter
            GameObject orbInstance = Instantiate(orbPrefab, transform.position, Quaternion.identity);
            orbInstance.tag = "Teleporter";  // ตั้งค่า Tag ให้เป็น "Teleporter"
        }
    }
}
