using UnityEngine;
using System.Collections;

public class TimedStateTransition : MonoBehaviour
{
	public float nextState = 10f; // how long to exist in the world
	private float targetTime;


	// Use this for initialization
	void Start()
	{
		// set the targetTime to be the current time + nextState seconds
		targetTime = Time.time + nextState;
		this.GetComponent<Animator>().SetBool("NotExist", false);
		this.GetComponent<Animator>().SetBool("Exist", true);
	}

	// Update is called once per frame
	void Update()
	{
		// continually check to see if past the target time
		if (Time.time >= targetTime)
		{
			if (this.GetComponent<Animator>().GetBool("Exist"))
			{
				// trigger the Animator to make the transition from exsiting to not existing (sredina to kraj)
				this.GetComponent<Animator>().SetBool("NotExist", true);
				this.GetComponent<Animator>().SetBool("Exist", false);
				// setting target time for the next round
				targetTime = Time.time + nextState + 1;

				// trigger the Animator to make tranition from not existing to existing (nepostojanje to pocetak=
			}
			else if (this.GetComponent<Animator>().GetBool("NotExist"))
			{
				this.GetComponent<Animator>().SetBool("Exist", true);
				this.GetComponent<Animator>().SetBool("NotExist", false);
				// setting target time for the next round
				targetTime = Time.time + nextState + 1;

			}


		}
	}


}