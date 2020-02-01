using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTrain : MonoBehaviour
{
    public InputActions input;
    public Transform origin;

    public float rotation = 0; // degrees around origin
    public float radius = 2;
    float radiusInput = 0;
    public float rMax = 5;
    public float rMin = 1;

    public float speed = 3f;

    void Awake()
    {
        input = new InputActions();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AdjustRadius(InputAction.CallbackContext context)
    {
        radiusInput = context.ReadValue<float>();
    }

        void FixedUpdate()
    {
        radius += radiusInput * Time.fixedDeltaTime;
        radius = Mathf.Clamp(radius, rMin, rMax);
    }

    void Update () {

        Vector3 left = new Vector3(origin.position.x - radius, origin.position.y, origin.position.z);

        Debug.DrawRay(left, left + left, Color.green);

        Vector3 right = new Vector3(origin.position.x + radius, origin.position.y, origin.position.z);

        Debug.DrawRay(right, right + right, Color.red);

        rotation += Time.deltaTime * (speed / radius);
        rotation = rotation % 360;

        float rot_02 = rotation / 180;

        Vector3 xform;
        if (rot_02 > 1) {
            xform = Vector3.Slerp(right, left, rot_02 - 1);
            transform.position = new Vector3(xform.x, -xform.z, xform.y);
        } else {
            xform = Vector3.Slerp(left, right, rot_02);
            transform.position = new Vector3(xform.x, xform.z, xform.y);
        }

        transform.rotation = Quaternion.LookRotation(transform.position - origin.position, Vector3.up);
    }
}
