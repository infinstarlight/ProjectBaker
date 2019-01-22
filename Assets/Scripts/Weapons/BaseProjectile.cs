using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets._2D
{


    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class BaseProjectile : MonoBehaviour
    {

        public float baseDamage;
        public float damageMultiplier;
        public float damageModifier;
        [SerializeField]private float totalDamageToApply;

        public float hitForce;
        private Rigidbody2D rb2D;
        private PlatformerCharacter2D character2D;
        //private GameObject hitObject;
        private CharacterStats GetCharacterStats;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            character2D = FindObjectOfType<PlatformerCharacter2D>();
        }

        // Start is called before the first frame update
        void Start()
        {
            if(character2D.m_FacingRight)
            {
                rb2D.velocity = transform.right * hitForce;
            }
            if(!character2D.m_FacingRight)
            {
                rb2D.velocity = -transform.right * hitForce;
            }

            totalDamageToApply = baseDamage + (1 * damageMultiplier) + (1 * damageModifier);
        }

        // Update is called once per frame
        void Update()
        {
            Destroy(gameObject, 2f);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Ignore Player
            if(collision.gameObject.GetComponentInChildren<CharacterStats>() != null)
            {
                GetCharacterStats = collision.gameObject.GetComponentInChildren<CharacterStats>();
                GetCharacterStats.ApplyDamage(totalDamageToApply);
                Destroy(gameObject);
            }
        }
    }
}