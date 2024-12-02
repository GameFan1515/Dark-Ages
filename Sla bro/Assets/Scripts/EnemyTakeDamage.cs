using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private bool EnemyEnable;
    
    [SerializeField] private float MaxHealth;
    private float CurrentLife;
    [SerializeField] private float Enemydamage;
    [SerializeField] GameObject Enemy;

    void Start()
    {

        CurrentLife = MaxHealth;
    }

    private void Update()
    {
        EnemyEnables(EnemyEnable);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Is Colliding");
            HealthSystem Health = collision.gameObject.GetComponent<HealthSystem>();
            if (Health != null)
            {
                Health.TakeDamage(Enemydamage * Time.deltaTime);
                Debug.Log(Health.healthAmount);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentLife -= damage;

        if (CurrentLife <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void EnemyEnables(bool EnemyEnable)
    {
        if (EnemyEnable)
        {
            Enemy.SetActive(true);
        }
        else
        {
            Enemy.SetActive(false);
        }
    }

}
