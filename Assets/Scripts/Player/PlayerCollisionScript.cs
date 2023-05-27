using System;
using System.Security.Cryptography.X509Certificates;
using Components;
using UnityEngine;
using UnityEditor;
using Utils;


namespace PlayerScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class PlayerCollisionScript : MonoBehaviour
    {

        [SerializeField] private PlayerScript PlayerScript;

        internal Rigidbody2D _rb2d;
        private float _defaultGravityScale;
        private float TOLERANCE = 0.31f;

        [Header("Ground Check System")] 
        [SerializeField] private LayerMask[] _canJumpFromThis_Layer;
        [SerializeField] private Transform groundCheckPoint1, groundCheckPoint2;
        [SerializeField] private float _groundCheckRadius;

        [Header("Walls System")] 
        [SerializeField] private LayerCheck _wallCheck;
        
        [Header("Interact")] 
        [SerializeField] float _interactCheckRadius;
        private Collider2D[] _interactResult = new Collider2D[1];
        [SerializeField] private LayerMask _interactebleLayer;

        [Header("Attack1")] 
        [SerializeField] private CheckCircleOverlap _attack1Range;

        [Header("Bools")] 
        internal bool _isStand;
        internal bool _isOnWall;

        private void Awake()
        {
            Debug.Log("PlayerCollisionScript Awake Starting" + _rb2d);
            _rb2d = GetComponent<Rigidbody2D>();
            _defaultGravityScale = _rb2d.gravityScale;
        }
        void Start()
        {
            Debug.Log("PlayerCollisionScript Update Starting");
            
        }

        internal bool IsGrounded1()
        {
            return Physics2D.OverlapCircle(groundCheckPoint1.position, _groundCheckRadius, _canJumpFromThis_Layer[0]);
        }

        internal bool IsGrounded2()
        {
            return Physics2D.OverlapCircle(groundCheckPoint2.position, _groundCheckRadius, _canJumpFromThis_Layer[0]);
        }


        void Update()
        {
            GroundLogic();
            WallLogic();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.IsInLayer(_canJumpFromThis_Layer[0]))
            {
                var contact = other.contacts[0];
                if (contact.relativeVelocity.y >= PlayerScript._slamDownVelocity && contact.relativeVelocity.y < PlayerScript._damageVelocity)
                {
                    PlayerScript.PlayerParticlesScript.SpawnSlamJumpDust();
                }

                if (contact.relativeVelocity.y >= PlayerScript._damageVelocity)
                {
                    GetComponent<HealthComponent>().ApplyHealthDelta(-1*((contact.relativeVelocity.y-PlayerScript._damageVelocity)/(contact.relativeVelocity.y/PlayerScript._heightDamageModify)));
                    PlayerScript.PlayerParticlesScript.SpawnSlamJumpDustHeight();
                }
            }
        }

        private void OnCollisionStay2D(Collision2D col)
        {

        }

        private void OnCollisionExit2D(Collision2D col)
        {

        }

        internal void GroundLogic()
        {
            if (IsGrounded1() || IsGrounded2())
                _isStand = true;
            else _isStand = false;
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = IsGrounded1() ? GizmosColors.TransparentGreen : GizmosColors.TransparentRed;
            Handles.DrawSolidDisc(groundCheckPoint1.position, Vector3.forward, _groundCheckRadius);
            Handles.color = IsGrounded2() ? GizmosColors.TransparentGreen : GizmosColors.TransparentRed;
            Handles.DrawSolidDisc(groundCheckPoint2.position, Vector3.forward, _groundCheckRadius);
            
            Handles.color = GizmosColors.TransparentWhiteBlue;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _interactCheckRadius);
        }
#endif

        public void Interact()
        {
            var size =  Physics2D.OverlapCircleNonAlloc(transform.position, _interactCheckRadius, 
                                                                    _interactResult, _interactebleLayer);
            for (int i = 0; i < size; i++)
            {
                var interacteble = _interactResult[i].GetComponent<Components.InteractibleObject>();
                if (interacteble != null) interacteble.Interact();
            }
        }
        
        public void DoAttack1()
        {
           var gos =  _attack1Range.GetObjectsInRange();
           foreach (var go in gos)
           {
               var hp = go.GetComponent<HealthComponent>();
               if (hp != null && go.CompareTag("Enemy"))
               {
                   hp.ApplyHealthDelta(-PlayerScript._attack1Damage);
               }
           }
        }

        private void WallLogic()
        {
            if (_wallCheck.IsTouchingLayer && Math.Abs(PlayerScript.PlayerMovementScript._direction.x - transform.localScale.x) < TOLERANCE)
            {
                _isOnWall = true;
                _rb2d.gravityScale = 0f;
            }
            else
            {
                _isOnWall = false;
                _rb2d.gravityScale = _defaultGravityScale;
            }
        }
    }
}
