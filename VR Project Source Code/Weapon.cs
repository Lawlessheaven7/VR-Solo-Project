using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Animator weaponAnimator;
    public AudioClip weaponSFX;
    public Transform raycastOrigin;
    public GameObject bullet;
    public TextMeshProUGUI ammoText;
    public Transform bulletSpawnPoint;
    public bool charge = false;
    [Header("Weapon Visual")]
    public GameObject magicRing;
    public float Ammos, maxAmmos;
    public int rechargeSpeed;
    

    private AudioSource weaponAudiosource;

    private RaycastHit hit;


    private void Awake()
    {
        
        weaponAudiosource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        magicRing.SetActive(false);
        Ammos = maxAmmos;
    }

    // Update is called once per frame
    void Update()
    {
        if (charge && Ammos <= maxAmmos)
        {
            //slowly regenerate the weapon ammos
            Ammos += rechargeSpeed * Time.deltaTime; 
        }

        if (Ammos >= maxAmmos)
        {
            Ammos = maxAmmos;

        } else if(Ammos <= 0)
        {
            Ammos= 0;
        }

        ammoText.text = Ammos.ToString("F0");
        
    }

    public void WeaponFired()
    {
        if (Ammos > 0)
        {
            //animate the weapon
            weaponAnimator.SetTrigger("Fire");
            //play weapon sfx
            weaponAudiosource.PlayOneShot(weaponSFX);
            //raycast
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit))
            {

                Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                Ammos--;
            }
        }
    }

    public void onGrab()
    {
        magicRing.SetActive(true);
        charge = false;
}

    public void onLetGo()
    {
        magicRing.SetActive(false);
        charge = true;
    }
}
