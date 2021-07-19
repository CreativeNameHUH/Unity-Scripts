using UnityEngine;

public class PlayerGun : Variables
{
    public Camera PlayerCamera;
    public ParticleSystem MuzzleFlash;

    public float GunImpactForce = 20f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        
        MuzzleFlash.Play();
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, PlayerGunRange))
        {
            Debug.Log(hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(PlayerGunDamage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(- hit.normal * GunImpactForce);
            }
        }

    }
}
