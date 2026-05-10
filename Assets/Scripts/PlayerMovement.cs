
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpAmt = 5f;
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
