using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] public float maxHealth;
    public float currentHealth;
    private bool dead;

    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(dead)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if(currentHealth > 0)
        {
            animator.SetTrigger("hit");
        }
        else
        {
            if(!dead)
            {
                if(gameObject.tag == "Player")
                {
                    GetComponent<PlayerInput>().enabled = false;
                    dead = true;
                }
                animator.SetTrigger("die");
            }
            
        }
    }
}
