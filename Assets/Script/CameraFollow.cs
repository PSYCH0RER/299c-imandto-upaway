using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // ผู้เล่น (ตัวแปรประเภท Transform)
    public float smoothSpeed = 0.125f;  // ความเร็วในการเคลื่อนที่ของกล้อง
    public Vector3 offset;        // ระยะห่างจากผู้เล่นที่ต้องการให้กล้องอยู่

    private void LateUpdate()
    {
        // รับตำแหน่งของผู้เล่นในแนว Y-axis
        Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

        // เคลื่อนที่กล้องไปยังตำแหน่งที่ต้องการด้วยการใช้ Lerp เพื่อให้สมูท
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition + offset, smoothSpeed);
        
        // กำหนดตำแหน่งใหม่ของกล้อง
        transform.position = smoothedPosition;
    }
}
