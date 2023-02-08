using UnityEngine;

public class GunGun : MonoBehaviour
{
    //GunStat
    public int damage;
    public float fireRate, range, reloadTime;
    public int magSize;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shotting, readyToShoot, Reloading;

    void Awake()
    {
        
    }

    
}
