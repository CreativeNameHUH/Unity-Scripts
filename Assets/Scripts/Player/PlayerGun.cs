using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerGun : Variables
{
    public Camera PlayerCamera;
    public ParticleSystem MuzzleFlash;
    public AudioSource GunSound;
    public AudioSource ReloadSound;
    public TextMeshProUGUI DisplayAmmo;

    public float GunImpactForce = 20f;
    public int MagazineSize = PlayerGunMagSize;

    private bool _isReloading;

    private IEnumerator Reload()
    {
        ReloadSound.Play();
        yield return new WaitForSeconds(2);
        MagazineSize = PlayerGunMagSize;
        DisplayAmmo.text = "Ammo: " + MagazineSize;
        _isReloading = false;
    }

    private void Shoot()
    {
        RaycastHit hit;

        MuzzleFlash.Play();
        GunSound.Play();
        MagazineSize -= 1;
        DisplayAmmo.text = "Ammo: " + MagazineSize;

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
                hit.rigidbody.AddForce(-hit.normal * GunImpactForce);
            }
        }
    }

    private void Start()
    {
        DisplayAmmo.text = "Ammo: " + MagazineSize;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && MagazineSize > 0 && _isReloading == false)
        {
            Shoot();
        }

        if (Input.GetKeyUp(KeyCode.R) && MagazineSize < PlayerGunMagSize && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }

        if (MagazineSize == 0)
        {
            DisplayAmmo.text = "Press R";
        }

        if (PlayerGunUpgrade)
        {
            MagazineSize = PlayerGunMagSize;
            DisplayAmmo.text = "Ammo: " + MagazineSize;
            PlayerGunUpgrade = false;
        }
    }
}