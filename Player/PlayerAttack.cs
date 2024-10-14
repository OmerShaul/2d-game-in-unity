
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;


    private Animator anim;
    private PlayerMovement playerMovement;
    private float CooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && CooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        CooldownTimer += Time.deltaTime;       

    }


    private void Attack()
    {
        anim.SetTrigger("attack");
        SoundManager.instance.PlaySound(fireballSound);
        CooldownTimer = 0;
        //pool fireballs-using same fireball over and over again, they are invisable and then visable...

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));

    }  


    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
                return i;
        }
        
        return 0;
    }

}





