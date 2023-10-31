using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    public float mouseSensX;
    public float mouseSensY;

    public Transform playerOrientation;

    float mouseX;
    float mouseY;

    float xCameraRotation;
    float yCameraRotation;

    new Camera camera;

    public LineRenderer laser;
    public Transform LookingAtObject { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        ProcessInputs();
        CheckPlayerRaycast();
    }
    void ProcessInputs()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensY;
    }
    void CameraRotation()
    {
        yCameraRotation += mouseX;
        xCameraRotation -= mouseY;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xCameraRotation, yCameraRotation, 0);
        playerOrientation.rotation = Quaternion.Euler(0, yCameraRotation, 0);
    }
    void CheckPlayerRaycast()
    {
        Vector3 cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        int interactionRange = 4;

        if (Physics.Raycast(cameraCenter, camera.transform.forward, out hit, interactionRange))
        {
            Transform objectHit = hit.transform;
            LookingAtObject = objectHit;
            laser.enabled = true;
            laser.SetPosition(0, cameraCenter);
            laser.SetPosition(1, hit.point);
        }
        else
        {
            LookingAtObject = null;
            laser.enabled = false;
        }
            
    }
}
