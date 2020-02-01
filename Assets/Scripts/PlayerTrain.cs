using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTrain : MonoBehaviour
{
    public InputActions input;
    public Transform origin;

    public float rotation = 180;
    public float rotChange = 5;
    public float velocity = 2;
    public float velChange = 0.1f;
    public float vMax = 2;
    public float vMin = 0.5f;

    public float MaxX = 9;
    public float MaxY = 5;
    public float radiusMin = 1.5f;

    float velocityInput = 0;
    float rotationInput = 0;

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

    public void AdjustRotation(InputAction.CallbackContext context)
    {
        if (rotationInput != -context.ReadValue<float>())
        {
            Debug.LogFormat("Roation updated to: {0}", -context.ReadValue<float>());
        }
        rotationInput = -context.ReadValue<float>();
    }

    public void AdjustVelocity(InputAction.CallbackContext context)
    {
        if (velocityInput != context.ReadValue<float>())
        {
            Debug.LogFormat("Velocity updated to: {0}", context.ReadValue<float>());
        }
        velocityInput = context.ReadValue<float>();
    }

    void FixedUpdate()
    {
        velocity += velocityInput * velChange * Time.fixedDeltaTime;
        velocity = Mathf.Clamp(velocity, vMin, vMax);

        float rotDiff = (rotationInput * rotChange * Time.fixedDeltaTime);

        transform.position = transform.position + (transform.up * velocity * Time.fixedDeltaTime);

        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotDiff);

        float distToOrigin = Vector2.Distance(transform.position, origin.position);
        float originalEulerZ = transform.rotation.eulerAngles.z;

        if (Mathf.Abs(transform.position.x) > MaxX || Mathf.Abs(transform.position.y) > MaxY)
        {
            transform.LookAt(origin);
            float targetEulerZ = Mathf.Clamp(transform.rotation.eulerAngles.z - originalEulerZ, -5, 5);
            transform.rotation = Quaternion.Euler(0, 0, originalEulerZ + targetEulerZ);

            if (Mathf.Abs(transform.position.x) > MaxX + (MaxX / 8) || Mathf.Abs(transform.position.y) > MaxY + (MaxY / 8))
            {
                transform.position = transform.position + (origin.position - transform.position) * velChange * Time.fixedDeltaTime;
            }
        }
        else if (distToOrigin < radiusMin)
        {
            transform.LookAt(origin);
            transform.rotation = Quaternion.Inverse(transform.rotation);
            float targetEulerZ = Mathf.Clamp(transform.rotation.eulerAngles.z - originalEulerZ, -5, 5);
            transform.rotation = Quaternion.Euler(0, 0, originalEulerZ + targetEulerZ);
        }
    }

    void Update () {
    }
}
