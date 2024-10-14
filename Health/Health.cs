
using UnityEngine;
using System.Collections;


public class Health : MonoBehaviour
{
   [Header ("Health") ]
   [SerializeField] private float startingHealth;
   public float currentHealth{ get; private set; }
   private Animator anim;
   private bool dead;

   
   [ Header ("iFrames")]
   [SerializeField] private float iFramesDuration;
   [SerializeField] private int numberOfFlashes;
   private SpriteRenderer spriteRend;


   [ Header ("Components")]
   [SerializeField] private Behaviour[] components;
   private bool Invulnerable;

   [Header("Death Sound")]
   [SerializeField] private AudioClip deathSound;
   [SerializeField] private AudioClip hurtSound;


   private void Awake()
   {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
   }

    public void TakeDamage (float _damage)
    {
        if (Invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if ( !dead )
            {
                
                // deactivates all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;
                
                anim.SetBool("moving", true);
                anim.SetTrigger("die");
                
                dead = true;
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    
    }

    public float getHealth() 
    {
        return currentHealth;
    }

    public void AddHealth(float _Value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _Value, 0, startingHealth);
    }

    
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invulnerability());
        // activates all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
    }
    
    
    
    
    
    private IEnumerator Invulnerability()
    {
        
        Invulnerable = true;

        Physics2D.IgnoreLayerCollision( 10, 11, true);
        //Invulnerability Duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds( iFramesDuration / (numberOfFlashes * 1));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds( iFramesDuration / (numberOfFlashes * 1));
        }
        Physics2D.IgnoreLayerCollision( 10, 11, false);
        Invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}