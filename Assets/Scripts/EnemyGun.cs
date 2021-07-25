using UnityEngine;

public class EnemyGun : Variables
{
    //public ParticleSystem MuzzleFlash;
    public Rigidbody EnemyBody;
    public float GunImpactForce;
    public void Shoot()
    {
        RaycastHit hit;

        //MuzzleFlash.Play();
        if (Physics.Raycast(EnemyBody.transform.position, EnemyBody.transform.forward, out hit, EnemyGunRange))
        {
            PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();

            if (player != null)
            {
                Debug.Log("Enemy: " + hit.transform.name);
                player.TakeDamage(EnemyGunDamage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * GunImpactForce);
            }
        }

    }
}
