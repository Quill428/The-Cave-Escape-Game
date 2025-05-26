using UnityEngine;

public class camerachange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Camera RoomCamera1;
    public Camera RoomCamera2;
    public Camera RoomCamera3;
    public Camera RoomCamera4;
    public Camera RoomCamera5;
    public Camera RoomCamera6;
 
    //private Camera Target;
    [SerializeField] private Camera targetCamera;

    private void Start()
    {
        DisableCams();
       
        RoomCamera1.enabled = true;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger, switching cameras...");
            Debug.Log($"Switching to {targetCamera.name}");
            
            // Disable all other cameras in the scene
            foreach (Camera cam in Camera.allCameras)
            {
                cam.enabled = false;
            }
            
            // Enable the assigned target camera
            if (targetCamera != null)
            {
                targetCamera.enabled = true;
            }
            else
            {
                Debug.LogWarning("Target camera not assigned on CameraSwitcher");
            }
            //DisableCams();

            //targetCamera = Target;

            //targetCamera.enabled = true;

            //if (Target != null)
            //{
            //    Target.enabled = true;
            //    Debug.Log("Camera switched to: " + Target.name);
            //}
            //else
            //{
            //    Debug.LogWarning("Target camera is not assigned!");
            //}
        }
    }

    public void DisableCams()
    {
        RoomCamera1.enabled = false;
        RoomCamera2.enabled = false;
        RoomCamera3.enabled = false;
        RoomCamera4.enabled = false;
        RoomCamera5.enabled = false;
        RoomCamera6.enabled = false;
    }

    //[SerializeField] private Camera targetCamera; // This is the one to enable when triggered

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log($"Switching to {targetCamera.name}");
    //
    //        // Disable all other cameras in the scene
    //        foreach (Camera cam in Camera.allCameras)
    //        {
    //            cam.enabled = false;
    //        }
    //
    //        // Enable the assigned target camera
    //        if (targetCamera != null)
    //       {
    //            targetCamera.enabled = true;
    //        }
    //        else
    //        {
    //           Debug.LogWarning("Target camera not assigned on CameraSwitcher");
    //        }
    //    }
    //}

    private void Update()
    {
       
    }
    
    //public GameObject CameraTransfer;

    

    //public Transform cameraTargetPosition; // Empty GameObject representing the new camera position
    //public float moveSpeed = 5f;

    //public Camera newCamera;
    //public Camera currentCamera;

    //void Start()
    //{
    //
    //    camera1.enabled = true;
    //    camera2.enabled = false;
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey("1"))
    //    {
    //        camera2.enabled = false; camera1.enabled = true;



    //void Start()
    //{
    //    Camera2.enabled = false;
    //}

    // Update is called once per frame
    //void Update()
    //{

    //OnTriggerEnter
    //if collision gameobject is player
    //MoveCamera()
    //transform.position = Vector3.Lerp(transform.position, Target.transform.position, Time.deltaTime * Damping);
    //}
    //private void Trigger2Devent(Collider2D collision)
    //{
    //if (collision.CompareTag("Player"))
    //{
    //  CameraTransfer.target = gameObject;
    //}
    //}
}
