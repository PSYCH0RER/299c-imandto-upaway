using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;  // ความเร็วในการเลื่อนกล้อง
    private Vector3 startPosition;     // ตำแหน่งเริ่มต้นของกล้อง
    private float scrollAmount = 0f;   // ตัวแปรในการบวกค่าเลื่อนของกล้อง

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้นของกล้อง
        startPosition = transform.position;
    }

    void Update()
    {
        // บวก scrollAmount ขึ้นเรื่อยๆ ตามความเร็วที่กำหนด
        scrollAmount += scrollSpeed * Time.deltaTime; 

        // เลื่อนกล้องขึ้นตาม scrollAmount
        transform.position = new Vector3(startPosition.x, startPosition.y + scrollAmount, startPosition.z);
    }
}
