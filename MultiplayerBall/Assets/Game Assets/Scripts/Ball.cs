using Photon.Pun;
using System;
using UnityEngine;
namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviourPun
   // public class Ball : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        [SerializeField] private float _x;
        [SerializeField] private float _y;
        [SerializeField] private float _z;

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
            if (base.photonView.IsMine)
            {
                Debug.Log("aaa");
               // _x = transform.position.x;
               // _x = transform.position.y;
               // _x = transform.position.z;
            }
        }

        private void Awake()
        {
            Debug.Log("bbb");
            //transform.position = new Vector3(_x, _y, _z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "instadeath")
            {
               // m_Rigidbody.transform.position = new Vector3(0, 0, 0);
                Destroy(gameObject);
                if (base.photonView.IsMine)
                {
                    GameObject.Find("Canvases").GetComponent<GameCanvasManager>().GameOver();
                }
                //GameObject.Find("Canvases").GetComponent<GameCanvasManager>().GameOver();
            }
        }

        public void Move(Vector3 moveDirection, bool jump)
        {
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the moyve direction.
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower);
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection * m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
            }
        }
    }
}
