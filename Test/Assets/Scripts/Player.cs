using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private Camera cam;

    private float mvX = 0;
    private float mvZ = 0;

    private float rotX;
    private float rotY;

    private float turnSpeed = 6f;
    private float minTurnAngle = -45;
    private float maxTurnAngle = 45;

    private Rigidbody rigidbody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get mouse inputs
        rotY = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // Clamp vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(1, 0, 0), -transform.up, out hit, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(-1, 0, 0), -transform.up, out hit, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(0, 0, 1), -transform.up, out hit, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(0, 0, -1), -transform.up, out hit, 1.1f))
            {
                rigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }

        // Calculate movement
        mvX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        mvZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    }

    void FixedUpdate()
    {
        // Move the player
        transform.Translate(new Vector3(mvX, 0, mvZ));

        // Rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + rotY, 0);
    }
}
