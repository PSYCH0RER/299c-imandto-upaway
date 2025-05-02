using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;  // ความเร็วในการไหลขึ้น
    private Vector3 startPosition;     // ตำแหน่งเริ่มต้นของกล้อง

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้นของกล้อง
        startPosition = transform.position;
    }

    void Update()
    {
        // เลื่อนกล้องขึ้นด้านบนในแนวแกน Y ตามความเร็วที่กำหนด
        transform.position = new Vector3(startPosition.x, startPosition.y + Time.time * scrollSpeed, startPosition.z);
    }
}
