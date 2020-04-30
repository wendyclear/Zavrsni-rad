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
        [SerializeField] public bool _playerFinished;

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            _playerFinished = false;
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "instadeath")
            {
                if (base.photonView.IsMine)
                {
                    if (GameObject.Find("GameFinishedCanvas") == null)
                    {
                        GameObject.Find("CanvasManager").GetComponent<GameCanvasManager>().GameOver();
                    }
                }
            }
            else if (other.gameObject.tag == "finish")
            {
                if (base.photonView.IsMine)
                {
                    int place = GameObject.Find("FinishCounter").GetComponent<FinishCounter>().Finish();
                    GameObject.Find("CanvasManager").GetComponent<GameCanvasManager>().GameFinished(place) ;
                    _playerFinished = true;
                }
            }

            else if (other.gameObject.tag == "buff")
            {
                Destroy(other.gameObject);
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
