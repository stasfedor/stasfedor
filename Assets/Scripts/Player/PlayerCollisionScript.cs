using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class PlayerCollisionScript : MonoBehaviour
    {

        [SerializeField] private PlayerScript PlayerScript;

        internal Rigidbody2D _rb2d;

        [Header("Ground Check System")] [SerializeField]
        private LayerMask[] _canJumpFromThis_Layer;
        [SerializeField] private Transform groundCheckPoint1, groundCheckPoint2;
        [SerializeField] private float _groundCheckRadius;
        
        [Header("Interact")] 
        [SerializeField] float _interactCheckRadius;
        private Collider2D[] _interactResult = new Collider2D[1];
        [SerializeField] private LayerMask _interactebleLayer;
        

        [Header("Bools")] internal bool _isStand;
        


        private void Awake()
        {
            Debug.Log("PlayerCollisionScript Awake Starting" + _rb2d);
            _rb2d = GetComponent<Rigidbody2D>();
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
            GroundLogick();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {

        }

        private void OnCollisionStay2D(Collision2D col)
        {

        }

        private void OnCollisionExit2D(Collision2D col)
        {

        }

        private void GroundLogick()
        {
            if (IsGrounded1() || IsGrounded2())
                _isStand = true;
            else _isStand = false;
        }

        

        private void OnDrawGizmos()
        {
            Gizmos.color = IsGrounded1() ? Color.green : Color.red;
            Gizmos.DrawSphere(groundCheckPoint1.position, _groundCheckRadius);
            Gizmos.color = IsGrounded2() ? Color.green : Color.red;
            Gizmos.DrawSphere(groundCheckPoint2.position, _groundCheckRadius);
            //Debug.DrawRay(groundCheckPoint1.position, new Vector3(0f, -_groundCheckRadius, 0f), IsGrounded1() ? Color.green : Color.red);
            //Debug.DrawRay(groundCheckPoint2.position, new Vector3(0f, -_groundCheckRadius, 0f), IsGrounded2() ? Color.green : Color.red);
        }
        
        internal void Interact()
        {
            var size =  Physics2D.OverlapCircleNonAlloc(transform.position, _interactCheckRadius, 
                                                                    _interactResult, _interactebleLayer);
            for (int i = 0; i < size; i++)
            {
                var interacteble = _interactResult[i].GetComponent<Components.InteractibleObject>();
                if (interacteble != null) interacteble.Interact();
            }
        }
    }
}
