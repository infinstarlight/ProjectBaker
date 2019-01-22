using System.Collections;
using UnityEngine;
//For prototyping only
namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(AudioSource))]

    public class BaseWeapon : MonoBehaviour
    {
        public float currentAmmo;
        public float maxAmmo;
        private bool bHasInfiniteAmmo = false;

        public float fireRate;

        public Transform gunEnd_Right;
        private Transform projectileSpawnPoint;
        public Transform gunEnd_Left;
        public BaseProjectile weaponProjectile;
        private AudioSource weaponAudio;
        private float nextFire;
        private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

        public AudioClip weaponFireClip;
        public AudioClip weaponEmptyClip;

        //Temporary for prototyping - will need to update logic for custom controller script
        private PlatformerCharacter2D character2D;

        private void Awake()
        {
            weaponAudio = GetComponent<AudioSource>();
            character2D = GetComponentInParent<PlatformerCharacter2D>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            AttackWithWeapon();
         if(character2D.m_FacingRight)
            {
                projectileSpawnPoint = gunEnd_Right;
            }

         if(!character2D.m_FacingRight)
            {
                projectileSpawnPoint = gunEnd_Left;
            }

        }

        void AttackWithWeapon()
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                StartCoroutine(ShotEffect());

                

                if (currentAmmo != 0 || bHasInfiniteAmmo)
                {
                    if (weaponProjectile != null)
                    {
                        Instantiate(weaponProjectile, projectileSpawnPoint.position, Quaternion.identity);
                        Physics2D.IgnoreCollision(weaponProjectile.GetComponent<BoxCollider2D>(), GetComponentInParent<BoxCollider2D>());
                       
                    }

                }
            }
        }

        private IEnumerator ShotEffect()
        {
            weaponAudio.PlayOneShot(weaponFireClip);

            yield return shotDuration;
        }
    }
}
