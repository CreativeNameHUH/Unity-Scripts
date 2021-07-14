using Gamekit3D;
using UnityEngine;

public class PlayerGun : Variables
{
    public Camera PlayerCamera;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, PlayerGunRange))
        {
            Debug.Log(hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(PlayerGunDamage);
            }
        }

    }
}
