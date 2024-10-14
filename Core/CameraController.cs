using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistanceX;
    [SerializeField] private float aheadDistanceY;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float zoomOutAmount;

    private float lookAheadX;
    private float lookAheadY;
    private Camera mainCamera;
    private float initialCameraSize;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        initialCameraSize = mainCamera.orthographicSize;
    }

    private void Update()
    {
        float targetX = player.position.x + lookAheadX;
        float targetY = player.position.y + lookAheadY;

        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * cameraSpeed);
        float newY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * cameraSpeed);

        transform.position = new Vector3(newX, newY, transform.position.z);

        lookAheadX = Mathf.Lerp(lookAheadX, aheadDistanceX * player.localScale.x, Time.deltaTime * cameraSpeed);
        lookAheadY = Mathf.Lerp(lookAheadY, aheadDistanceY * player.localScale.y, Time.deltaTime * cameraSpeed);

        // Zoom out the camera
        float targetSize = initialCameraSize + zoomOutAmount;
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform newRoom)
    {
        transform.position = new Vector3(newRoom.position.x, newRoom.position.y, transform.position.z);
        mainCamera.orthographicSize = initialCameraSize;
    }
}