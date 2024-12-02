using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform barrel; //Posição de Onde a Bala Vai Aparecer
    [SerializeField] private float fireRate; //Cadência de Tiro
    [SerializeField] private GameObject bullet; //Projétil

    private float fireTimer; //Controle da Cadência

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }
    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        fireTimer = Time.time + fireRate;

        //Instantiate
        Instantiate(bullet, barrel.position, barrel.rotation);
    }

    private bool CanShoot()
    {
        return Time.time > fireTimer;
    }
}
