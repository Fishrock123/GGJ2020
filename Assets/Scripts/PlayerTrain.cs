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
    Vector2 directionInput;

    public AudioSource trainMoveSFX;

    public ParticleSystem trackParticles;

    public LineRenderer cursorLine;

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

    public void AdjustDirection(InputAction.CallbackContext context)
    {
        //directionInput = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position ;
    }

    void FixedUpdate()
    {
        // Quaternion rot = Quaternion.AngleAxis(rotationInput * rotChange * Time.fixedDeltaTime, Vector3.forward);

        directionInput = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        directionInput = directionInput.normalized * (directionInput.magnitude * 0.5f);
        if (directionInput.magnitude > 0.001) {
            velocityInput = directionInput.magnitude - 0.5f;

            transform.up = Vector2.Lerp(transform.up, directionInput, rotChange * Time.fixedDeltaTime);
        }
        else
        {
            velocityInput = -1;
        }

        velocity += velocityInput * velChange * Time.fixedDeltaTime;
        velocity = Mathf.Clamp(velocity, vMin, vMax);

        transform.position = transform.position + (transform.up * velocity * Time.fixedDeltaTime);

        // transform.rotation = transform.rotation * rot;

        float distToOrigin = Vector2.Distance(transform.position, origin.position);
        float originalEulerZ = transform.rotation.eulerAngles.z;

        if (Mathf.Abs(transform.position.x) > MaxX || Mathf.Abs(transform.position.y) > MaxY)
        {

            transform.up = Vector2.Lerp(transform.up, origin.position - transform.position, rotChange * 1.5f * Time.fixedDeltaTime);

            if (Mathf.Abs(transform.position.x) > MaxX + 1 || Mathf.Abs(transform.position.y) > MaxY + 1)
            {
                transform.position = transform.position + (origin.position - transform.position) * velChange * Time.fixedDeltaTime;
            }
        }
        else if (distToOrigin < radiusMin)
        {
            transform.up = Vector2.Lerp(transform.up, -(origin.position - transform.position), rotChange * 1.5f * Time.fixedDeltaTime);

            if (distToOrigin < radiusMin - 1f) {
                transform.position = transform.position + (-(origin.position - transform.position)) * velChange * Time.fixedDeltaTime;
            }
        }

        trainMoveSFX.volume = velocity / vMax;

        trackParticles.startRotation = Mathf.Deg2Rad * -transform.eulerAngles.z;
    }

    public void Update()
    {
        cursorLine.positionCount = 2;
        cursorLine.SetPosition(0, transform.position);
        cursorLine.SetPosition(1, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }

    public void DisableSound()
    {
        trainMoveSFX.Stop();
    }
}
