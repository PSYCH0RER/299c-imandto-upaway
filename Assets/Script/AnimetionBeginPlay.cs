using UnityEngine;

public class AnimetionBeginPlay : MonoBehaviour
{
    public Animator animetionBegin;  // ตัวแปร Animator

    private void Start()
    {
        // เรียก Trigger "StartAnimation" เพื่อเริ่มแอนิเมชั่นใน MainMenu
        animetionBegin.SetTrigger("StartAnimation");
    }
}
