using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float RotateSpeed;

    private float x_Rotate;
    private float y_Rotate;
    private float x_cur = 0;

    private float max_Rotate;
    private float min_Rotate;

    private float x_dir = 1f;
    private float z_dir = 1f;

    private Rigidbody rb;

    private float MoveSpeed;
    private Camera cam;

    private void Start()
    {
        MoveSpeed = 10f;
        rb = GetComponent<Rigidbody>();
        cam = gameObject.GetComponentInChildren<Camera>();

        x_Rotate = 0;
        y_Rotate = 0;
        RotateSpeed = 10f;

        min_Rotate = -75f;
        max_Rotate = 30f;
    }

    void Update()
    {
        Move();

        CameraMove();
    }

    private void Move()
    {
        x_dir = Input.GetAxis("Horizontal");
        z_dir = Input.GetAxis("Vertical");

        rb.MovePosition(transform.position + ((transform.right * x_dir + transform.forward * z_dir).normalized * MoveSpeed) * Time.deltaTime);
    }

    private void CameraMove()
    {
        x_Rotate = Input.GetAxis("Mouse X");
        y_Rotate = Input.GetAxis("Mouse Y");

        x_cur -= y_Rotate * RotateSpeed;
        x_cur = Mathf.Clamp(x_cur, min_Rotate, max_Rotate);

        cam.transform.localEulerAngles = new Vector3(x_cur, 0f, 0f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, x_Rotate, 0f) * RotateSpeed));
    }
}
