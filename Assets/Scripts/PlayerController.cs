using UnityEngine;
using TMPro;

namespace RayOfHope
{
    public class PlayerController : MonoBehaviour
    {
        AudioManager audioManager;
        public float movePower = 10f;
        public float jumpPower = 15f;

        private Rigidbody2D rb;
        private Animator anim;
        private int direction = 1;
        private bool isGrounded = false;
        private ShieldMode shieldMode;

        public GameObject lightOrbPrefab;
        public Transform lightOrbStaff;
        private int orbCount = 5;
        public TextMeshProUGUI orbAmmoText;


        public Coroutine currentSpeedBoostCoroutine;

        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            shieldMode = GetComponent<ShieldMode>();
        }

        private void Update()
        {
            Run();

            if ((isGrounded && Input.GetButtonDown("Jump")) || Input.GetButton("Vertical"))
            {
                Jump();
            }

            if (Input.GetMouseButtonDown(1) && orbCount > 0) // Right mouse button clicked
            {
                ShootOrb();
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            isGrounded = true;
            anim.SetBool("isJump", false);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isGrounded = false;
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            float moveInput = Input.GetAxisRaw("Horizontal");

            if (moveInput < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;
            }
            else if (moveInput > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;
            }

            transform.localScale = new Vector3(direction, 1, 1);
            transform.position += movePower * Time.deltaTime * moveVelocity;

            if (Mathf.Abs(moveInput) > 0 && isGrounded)
            {
                anim.SetBool("isRun", true);
            }
            else
            {
                anim.SetBool("isRun", false);
            }
        }

        public void Jump()
        {
            if (!isGrounded || anim.GetBool("isJump"))
            {
                return; // Making sure Lumi can't jump while already jumping or in mid-air
            }
            audioManager.PlaySFX(audioManager.jump);
            anim.SetBool("isJump", true);
            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            Invoke("ResetJump", 0.2f); // Delay to prevent rapid consecutive jumps
        }

        public void ResetJump()
        {
            anim.SetBool("isJump", false);
        }

        void TakeDamage()
        {
            if (shieldMode != null)
            {
                shieldMode.TakeDamage();
            }
            else
            {
                // Normal damage logic here.
            }
        }

        void ShootOrb()
        {
            if(lightOrbPrefab != null && lightOrbStaff != null)
            {
                GameObject orb = Instantiate(lightOrbPrefab, lightOrbStaff.position, Quaternion.identity);
                orb.GetComponent<LightOrb>().Launch(direction);
                orbCount--;
                orbAmmoText.text = "Orb Ammo: " + orbCount.ToString();
            }
        }
    }
}
