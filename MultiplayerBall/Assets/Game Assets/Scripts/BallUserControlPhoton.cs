using Photon.Pun;
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControlPhoton : MonoBehaviourPun
    {
        [SerializeField]
        private Ball ball; // Reference to the ball controller.
        [SerializeField]
        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.
        [SerializeField]
        private Transform cam; // A reference to the main camera in the scenes transform
        [SerializeField] //2
        private GameObject _cam; // 2 A reference to the main camera in the scenes transform
        [SerializeField]
        private Vector3 camForward; // The current forward direction of the camera
        [SerializeField]
        private bool jump; // whether the jump button is currently pressed
        //[SerializeField]
        public GameObject _mainCamera;


        private void Awake()
        {
                // Set up the reference.
                ball = GetComponent<Ball>();
                // get the transform of the main camera
                if (Camera.main != null)
                {
                    cam = Camera.main.transform;
                    if (base.photonView.IsMine)
                    {
                        Camera.main.GetComponent<SmoothFollow>().SetTarget(transform);
                    }
                }
                else
                {
                    Debug.LogWarning(
                        "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                    // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
                }
        }

       /* private void Start()
        {
            if (base.photonView.IsMine)
            {
                // cam = PhotonNetwork.Instantiate("Camera", new Vector3(0f,0f,0f), Quaternion.identity, 0);
                //Vector3 _camPos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 70);

                //instantiating camera - then for each player theres one camera in the game
                // _cam = PhotonNetwork.Instantiate("Camera", _camPos, Quaternion.identity, 0);
                //cam = _cam.GetComponent<Transform>();
                // cam.GetComponent<Camera>().enabled = true;
                
                cam = GameObject.Find("MainCamera").GetComponent<Transform>();
                Debug.Log("Camera found " + cam);
                //_mainCamera.GetComponent<Camera>().enabled = false;

            }
        }*/
        private void Update()
        {
            // Get the axis and jump input.
            if (base.photonView.IsMine)
            {
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                jump = CrossPlatformInputManager.GetButton("Jump");
                //move = (v * Vector3.forward + h * Vector3.right).normalized;
                // calculate move direction
                if (cam != null)
                {
                    // calculate camera relative direction to move:
                    camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                    move = (v * camForward + h * cam.right).normalized;
                }
                else
                {
                    // we use world-relative directions in the case of no main camera
                    move = (v * Vector3.forward + h * Vector3.right).normalized;
                }
            }
        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            if (base.photonView.IsMine)
            {
                ball.Move(move, jump);
                jump = false;
            }
        }
    }
}
