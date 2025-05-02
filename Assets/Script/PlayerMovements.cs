using UnityEngine;
using System.Collections;  // เพิ่มการใช้งาน System.Collections สำหรับ IEnumerator และ Coroutine

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;  // ความแรงในการกระโดด
    private Rigidbody2D rb;
    private Animator animator;
    private float moveX;
    private bool isGrounded;  // เช็คว่าอยู่บนพื้นหรือไม่
    private bool isJumping;   // เช็คว่าอยู่ในระหว่างกระโดด

    public Transform groundCheck;   // จุดที่ใช้ในการเช็คว่าตัวละครอยู่บนพื้น
    public LayerMask groundLayer;   // เลเยอร์ที่ใช้ในการตรวจสอบพื้น

    private float resetTime = 2f;   // เวลา 2 วินาทีในการรีเซ็ต rotation
    private bool isResetting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); // รับค่าการเคลื่อนที่ในแนวนอน (A, D หรือ ลูกศรซ้าย/ขวา)

        // ตรวจสอบการกระโดด
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);  // ตรวจสอบว่าอยู่บนพื้นหรือไม่

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // ถ้ากด Spacebar และอยู่บนพื้น
        {
            Jump();
        }

        // ถ้าตัวละครอยู่บนพื้นและไม่กระโดดแล้ว ให้กลับไปเป็น idle
        if (isGrounded && !isJumping)
        {
            animator.SetBool("isWalking", moveX != 0);  // ถ้าเดิน จะเล่น animation เดิน
        }

        // อัปเดตการเคลื่อนที่ในแนวนอน
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // ตรวจสอบการเดินและหันหน้าไปตามทิศทาง
        if (moveX > 0) // เดินไปทางขวา
        {
            Flip(true); // หันหน้าไปทางขวา
        }
        else if (moveX < 0) // เดินไปทางซ้าย
        {
            Flip(false); // หันหน้าไปทางซ้าย
        }

        // รีเซ็ต Rotation Z ถ้าเกินค่า 80 หรือ -80 และนับถอยหลัง 2 วิ
        CheckRotationReset();
    }

    // ฟังก์ชันเพื่อเปลี่ยนทิศทางการหมุน
    void Flip(bool facingRight)
    {
        // ใช้การพลิกของ SpriteRenderer แทนการใช้ localScale.x
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = !facingRight; // พลิกภาพถ้าหากเดินไปทางซ้าย
    }

    // ฟังก์ชันกระโดด
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // การกระโดด
        isJumping = true;  // ตั้งค่าเป็นกระโดด
        animator.SetBool("isJumping", true); // เล่น Animation กระโดด
    }

    // ฟังก์ชันที่จะถูกเรียกเมื่อร่างกายของตัวละครตกลงพื้น
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumping && isGrounded) // ถ้าเคยกระโดดแล้วและตกลงพื้น
        {
            isJumping = false; // รีเซ็ตสถานะการกระโดด
            animator.SetBool("isJumping", false); // หยุด Animation กระโดด
        }
    }

    // ฟังก์ชันสำหรับเช็ค Rotation และรีเซ็ตค่า Z เมื่อเกินเงื่อนไข
    void CheckRotationReset()
    {
        float currentZRotation = transform.rotation.eulerAngles.z;

        // เช็คว่า Rotation Z เกิน 80 หรือ น้อยกว่า -80
        if (currentZRotation > 80f || currentZRotation < 280f) // 280 คือ -80 ในมุมวงกลม
        {
            if (!isResetting)
            {
                StartCoroutine(ResetRotationCoroutine()); // เริ่มนับถอยหลัง 2 วินาที
            }
        }
    }

    // Coroutine สำหรับรีเซ็ต Rotation Z
    private IEnumerator ResetRotationCoroutine()
    {
        isResetting = true;  // ตั้ง flag ให้รู้ว่ากำลังกรีเซ็ต

        // รอ 2 วินาที
        yield return new WaitForSeconds(resetTime);

        // รีเซ็ต Rotation Z ให้เป็น 0
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        isResetting = false;  // รีเซ็ต flag
    }
}
