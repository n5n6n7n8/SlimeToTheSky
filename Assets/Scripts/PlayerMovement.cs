
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpAmt = 5f;
    [SerializeField] private float moveSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    private bool shouldJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(keyboard == null)
        {
            Debug.Log("No keyboard detected");
            return;
        }
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            shouldJump = true;
        }
        if (keyboard.aKey.isPressed)
        {
            rb.AddForce(Vector3.left * moveSpeed, ForceMode.Force);
        }
        if (keyboard.dKey.isPressed)
        {
            rb.AddForce(Vector3.right * moveSpeed, ForceMode.Force);
        }
    }
    void FixedUpdate()
    {
        if (shouldJump)
        {
            rb.AddForce(Vector3.up * jumpAmt, ForceMode.Impulse);
            shouldJump = false;
        }
    }
}
