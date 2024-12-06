using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Gun;
    [SerializeField] private Transform barrel; //Posi��o de Onde a Bala Vai Aparecer
    [SerializeField] private float fireRate; //Cad�ncia de Tiro
    [SerializeField] private GameObject bullet; //Proj�til
   

    private float fireTimer; //Controle da Cad�ncia

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
