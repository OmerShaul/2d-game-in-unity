using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; // sound that we will play when picking up a new checkpoint
    private Transform currentCheckpoint; // we will store our last checkpoint here
    private Health playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();

    }


    public void CheckRespawn()
    {
        
        if (currentCheckpoint == null)
        {
            // show gameover screen
            uiManager.GameOver();
            
            return; // dont execute the rest of this function
        }
        
        // check if the checkpoint is avalible
        transform.position = currentCheckpoint.position; // move player to check point position
        playerHealth.Respawn(); // restore player health and reset animation


        // move camera to checkpoint room (**for this to work the checkpoint objects have to be placed as a child of the room object)
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ( collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint that we activated as the current one
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; // deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("appear"); // trigger checkpoint animation
        }


    }

}
