using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviourPun
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        [SerializeField] private float _x;
        [SerializeField] private float _y;
        [SerializeField] private float _z;
        [SerializeField] public bool _playerFinished;


        private const byte ColorChange = 0;
        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;

        private void OnEnable()
        {
            PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
        } 

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            _playerFinished = false;
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;

        }

        private void Update()
        {
            if (base.photonView.IsMine && Input.GetKeyDown(KeyCode.C)) ChangeColor();
        }

        private void ChangeColor()
        {
            GameObject.Find("Floor").GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            object[] data = new object[] { GameObject.Find("Floor").GetComponent<MeshRenderer>().material.color.r, GameObject.Find("Floor").GetComponent<MeshRenderer>().material.color.b, GameObject.Find("Floor").GetComponent<MeshRenderer>().material.color.g};
            PhotonNetwork.RaiseEvent(ColorChange, data, RaiseEventOptions.Default, SendOptions.SendUnreliable);
        }

        private void NetworkingClient_EventReceived(EventData obj)
        {
            if (obj.Code == ColorChange)
            {
               object[] datas = (object[])obj.CustomData;
               Color c = new Color((float)datas[0], (float)datas[1], (float)datas[2]);
               GameObject.Find("Floor").GetComponent<MeshRenderer>().material.color = c;
            }
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
                    GameObject.Find("CanvasManager").GetComponent<GameCanvasManager>().GameFinished() ;
                    _playerFinished = true;
                }
            }

            else if (other.gameObject.tag == "buff")
            {
                Destroy(other.gameObject);
                if (base.photonView.IsMine)
                {
                    GameObject.Find("CanvasManager").GetComponent<GameCanvasManager>().GetBuff();
                }
            }

            else if (other.gameObject.tag == "Player" )
            {
                other.GetComponent<PhotonView>().RPC("Collide", RpcTarget.);
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

        [PunRPC]
        public void Collide(PhotonMessageInfo pmi)
        {
            GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }
    }
}
