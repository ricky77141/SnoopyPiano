using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private GameObject hitBox;

        private float horizontalMovement;

        private Rigidbody2D myBody;
        private SpriteRenderer sr;
        private PlayerAnimation playerAnim;
    
        private PlayerInputs playerInput;
        private Vector2 moveInput;
        private RaycastHit2D groundCast;
        private BoxCollider2D boxCol;

        private void Awake()
        {
            playerInput = new PlayerInputs();
            myBody = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            playerAnim = GetComponent<PlayerAnimation>();
            boxCol = GetComponent<BoxCollider2D>();
            playerInput.PlayerMove.Jump.performed += HandleJumping;
            playerInput.HammerHit.Hammer.performed += HammerHit;
        }

        private void OnEnable()
        {
            playerInput.PlayerMove.Enable();
            playerInput.HammerHit.Enable();
        }

        private void OnDisable()
        {
            playerInput.PlayerMove.Disable();
            playerInput.HammerHit.Disable();
        }

        private void Update()
        {
            moveInput = playerInput.PlayerMove.Movement.ReadValue<Vector2>();
            HandleAnimation();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            horizontalMovement = moveInput.x;
        
            if (horizontalMovement > 0)
                myBody.velocity = new Vector2(speed, myBody.velocity.y);
            else if (horizontalMovement < 0)
                myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            else
                myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
        
        void HandleJumping(InputAction.CallbackContext ctx)
        {
            if (IsGrounded())
            {
                Jump();
            }
        }

        void HammerHit(InputAction.CallbackContext ctx1)
        {
            if (myBody.velocity.x != 0)
                playerAnim.PlayHammerWalk();
            else
                playerAnim.PlayHammer();
        }
        
        bool IsGrounded()
        {
            groundCast = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, groundMask);
            
            return groundCast.collider != null;
        }
        void Jump()
        {
            myBody.velocity = Vector2.up * jumpForce;
        }
        
        void HandleAnimation()
        {
            if ((int)myBody.velocity.x < 0)
                sr.flipX = true;
            else if ((int)myBody.velocity.x > 0)
                sr.flipX = false;

            if (myBody.velocity.y == 0)
                playerAnim.PlayWalk(Mathf.Abs((int)myBody.velocity.x));

            //Gives the y parameter for the animation. This is for jumping.
            playerAnim.PlayJump(IsGrounded(), myBody.velocity.y);    
        }

        public void ActivateHammer()
        {
            hitBox.SetActive(true);
        }

        public void DeactivateHammer()
        {
            hitBox.SetActive(false);
        }
    }
}
