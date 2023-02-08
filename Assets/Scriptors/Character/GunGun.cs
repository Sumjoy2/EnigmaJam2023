using UnityEngine;

public class GunGun : MonoBehaviour
{
    //GunStat
    public int damage;
    public float fireRate, range, reloadTime, timeBetweenShots;
    public int magSize, bulletsPertap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools
    bool shotting, readyToShoot, Reloading;

    //reference
    public Camera MainCamera;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    private void Awake()
    {
        bulletsLeft =  magSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = input.GetKey(KeyCode.Mouse0);
        else shooting = input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) Reload();
        //Shoot

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPertap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = MainCamera.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if(rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.getComponent<ShootingAi>().TakeDamage(damage);
        }
        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShots);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

   private void ReloadFinished()
   {
   bulletsLeft = magSize;
   reloading = false;

   }
}
