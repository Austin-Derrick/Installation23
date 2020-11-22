using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    bool isBeingHeld = false;
    int ammo = 5;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePosition;
    Rigidbody2D bulletRB;
    float shootForce = 10f;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float damage = 25;

    //Audio
    AudioSource source;
    [SerializeField]
    AudioClip [] shot;

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void setIsBeingHeld()
    {
        isBeingHeld = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) )//&& isBeingHeld == true)
        {
            StartCoroutine( shootBullet(firePosition));
            if (!source.isPlaying)
            {
                source.clip = shot[Random.Range(0, shot.Length)];
                source.Play();
            }
        }
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
                    hitInfo.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
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
}