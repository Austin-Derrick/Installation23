using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    private bool isBeingHeld = false;

    [SerializeField]
    public int maxAmmo;
    public int currentAmmo;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform firePosition;

    Rigidbody2D bulletRB;

    [SerializeField]
    private float shootForce = 10f;

    [SerializeField] LineRenderer lineRenderer;

    [SerializeField]
    float damage;

    [SerializeField]
    int weaponTypeDebug;


    public string[] weaponOptions = new string[3] { "Automatic Rifle", "DMR", "Burst Rifle" };
    private string weaponType;

    private bool canFire = true;
    private float nextFire;
    [SerializeField]
    float burstRate;

    float nextBurst;
    public bool reloading = false;

    [SerializeField]
    private float firingRate;

    [SerializeField]
    private float reloadTime;

    //Audio
    AudioSource source;
    [SerializeField]
    AudioClip[] shot;
    string aud_weapontype;

    public void Start()
    {
        GenerateWeapon();
        source = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }
    public void Awake()
    {
       
    }
    public void setIsBeingHeld()
    {
        isBeingHeld = true;
    }

    private void Update()
    {
        FireWeapon();
        Reload();
    }
    private void GenerateWeapon()
    {
        if(weaponTypeDebug != 0)
        {
            switch(weaponTypeDebug)
            {
                case 1:
                    weaponType = "Automatic Rifle";
                    break;
                case 2:
                    weaponType = "DMR";
                    break;
                case 3:
                    weaponType = "Burst Rifle";
                    break;

            }
        }
        Debug.Log("Weapon type is " + weaponType);

        switch(weaponType)
        {
            case "Automatic Rifle":
                damage = Random.Range(20, 30);
                firingRate = Random.Range(.07f, .1f);
                reloadTime = 1f + (damage/50);
                maxAmmo = 15 + ((Random.Range(1, 5) * 5));
                
                break;
            case "DMR":
                damage = Random.Range(75, 100);
                firingRate = .5f;
                reloadTime = .5f + (damage / 50);
                maxAmmo = 4 + Random.Range(0, 6);
                
                break;
            case "Burst Rifle":
                damage = Random.Range(35, 45);
                burstRate = Random.Range(.075f, .125f);
                firingRate = burstRate * 4;
                reloadTime = .2f + (damage / 50);
                maxAmmo = 3 * (Random.Range(5, 10));
                
                break;
        }
    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadCoroutine());
        }
    }
    IEnumerator ReloadCoroutine()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        reloading = false;
    }

    public void FireWeapon()
    {
        switch (weaponType)
        {
            case "Automatic Rifle":
                if (Input.GetMouseButton(0) && Time.time > nextFire && currentAmmo != 0 && !reloading) //&& isBeingHeld == true)
                {
                    aud_weapontype = "Machine Gun";
                    FireRound();
                   
                }
                break;
            case "DMR":
                if (Input.GetMouseButtonDown(0) && Time.time > nextFire && currentAmmo != 0 && !reloading) //&& isBeingHeld == true)
                {
                    aud_weapontype = "Pistol";
                    FireRound();
                    
                }
                break;
            case "Burst Rifle":
                if (Input.GetMouseButtonDown(0) && Time.time > nextBurst && currentAmmo != 0 && !reloading) //&& isBeingHeld == true)
                {
                    aud_weapontype = "Burst Shot";
                    StartCoroutine(TimeBetweenBurst(burstRate));
                }
                break;
        }
    }
    public void FireRound()
    {
        nextFire = Time.time + firingRate;
        currentAmmo--;
        StartCoroutine(shootBullet(firePosition));
        FindObjectOfType<AudioManager>().Play(aud_weapontype);
        //source.PlayOneShot(shot[Random.Range(0, shot.Length)]);
    }
    public void BurstFire(float Delay)
    {
        
    }
    public IEnumerator shootBullet(Transform shootPosition)
    {
        //GameObject bulletToFire = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation, null);
        //bulletRB = bulletToFire.GetComponent<Rigidbody2D>();
        //Vector2 bulletDirection = shootPosition.right;
        //bulletRB.AddForce(shootForce * bulletDirection, ForceMode2D.Impulse);

        RaycastHit2D hitInfo = Physics2D.Raycast(shootPosition.position, firePosition.right);

        if (hitInfo)
        {
            if (hitInfo.collider.isTrigger != true)
            {
                Debug.Log("The Bullet is not hitting a trigger");
                lineRenderer.SetPosition(0, shootPosition.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                if (hitInfo.collider.gameObject.CompareTag("Player") || hitInfo.collider.gameObject.CompareTag("Enemy"))
                {
                    hitInfo.collider.gameObject.GetComponent<Damagable>().hitByPlayer(damage);
                    //hitInfo.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
                }
            }
            else
            {
                Debug.Log("The Bullet is hitting a trigger");
            }           
        }
        else
        {
            lineRenderer.SetPosition(0, shootPosition.position);
            lineRenderer.SetPosition(1, shootPosition.position + shootPosition.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
    public IEnumerator TimeBetweenBurst(float burstDelay)
    {
        nextBurst = Time.time + firingRate;
        for (int x = 0; x < 3; x++)
        {
            currentAmmo--;
            StartCoroutine(shootBullet(firePosition));
            FindObjectOfType<AudioManager>().Play("Pistol");
            //source.PlayOneShot(shot[Random.Range(0, shot.Length)]);
            yield return new WaitForSeconds(burstDelay);

        }
        
    }
}