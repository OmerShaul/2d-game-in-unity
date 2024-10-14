
using UnityEngine;

public class Spikehead : EnemyDamage
{
    
    [Header("Spikehead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private float checkTimer;
    private Vector3 destination;
    private bool attacking;

    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;
    
    private void OnEnable()
    {
        stop();
    }

    private void Update()
    {
        //move only when attacking
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay)
                CheckForPlayer();
        }

    }

    private void CheckForPlayer()
    {
        
        CalculateDirections();
        //checks if spikehead sees the player
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }


    }

    private void CalculateDirections()
    {
        directions[0] = transform.right * range; // right direction
        directions[1] = -transform.right * range; // left direction
        directions[2] = transform.up * range; // up direction
        directions[3] = -transform.up * range; // down direction

    }

    private void stop()
    {
        destination = transform.position; // set destination ascurrent position so it doesnt move
        attacking = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(impactSound);
        base.OnTriggerEnter2D(collision);
        stop();//stop spikehead when hits somthing
    }

}