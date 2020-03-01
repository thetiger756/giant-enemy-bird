using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;


    public Animator animator;
    private float recoilSpeed = .1f;
    private float reloadSpeed = .4f;
    private bool notRecoiling = true;


    public GameObject Ball;
    public float speed = 100f;

    public AudioSource soundSource;
    public AudioSource otherSource;
    public AudioClip cannonFire;
    public AudioClip damageSound;

    public GameObject impactEffect;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && notRecoiling)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (notRecoiling)
        {
            muzzleFlash.Play();

            StartCoroutine(Recoil());

            RaycastHit hit;

            //Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);

            //GameObject instBall = Instantiate(Ball, transform.position, Quaternion.LookRotation(ray.direction));
            //Rigidbody instBallRigidbody = instBall.GetComponent<Rigidbody>();
            //instBallRigidbody.AddForce(ray.direction * speed);

            soundSource.clip = cannonFire;
            soundSource.Play();



            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    otherSource.clip = damageSound;
                    otherSource.Play();
                }

                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    IEnumerator Recoil()
    {
        animator.SetBool("Recoiling", true);
        notRecoiling = false;

        yield return new WaitForSeconds(recoilSpeed);

        animator.SetBool("Recoiling", false);

        yield return new WaitForSeconds(reloadSpeed);

        notRecoiling = true;
    }

    
}
