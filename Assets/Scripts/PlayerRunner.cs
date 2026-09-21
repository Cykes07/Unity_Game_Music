using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] float bpm = 100f;
    [SerializeField] float unitsPerBeat = 4f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float jumpBeats = 1f;

    // beats por segundo * unidades por beat = unidades por segundo
    float groundY;
    float jumpTimer;
    bool jumping;
    float Speed => bpm / 60f * unitsPerBeat;
    float JumpDuration => jumpBeats * 60f / bpm;

    void Start()
    {
        groundY = transform.position.y;
    }

    void Update()
    {
        var pos = transform.position;
        pos.x += Speed * Time.deltaTime;

        bool pressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        if (!jumping && pressed)
        {
            jumping = true;
            jumpTimer = 0f;
        }

        if (jumping)
        {
            jumpTimer += Time.deltaTime;
            float t = jumpTimer / JumpDuration;      // 0 = despega, 1 = aterriza

            if (t >= 1f)
            {
                jumping = false;
                pos.y = groundY;
            }
            else
            {
                pos.y = groundY + 4f * jumpHeight * t * (1f - t);
            }
        }

        transform.position = pos;
    }
}
