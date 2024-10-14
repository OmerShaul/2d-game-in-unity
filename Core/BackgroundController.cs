using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float parallaxEffect;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float backgroundMovement = (player.position.x - initialPosition.x) * parallaxEffect;
        transform.position = new Vector3(initialPosition.x + backgroundMovement, transform.position.y, transform.position.z);
    }
}