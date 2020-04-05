using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class UserManager : MonoBehaviour
{

	private static UserManager _UM; //instance
	private string _userName;

	#region GAME MANAGER PROPERTY

	public static UserManager UM 
	{
		get
		{
			return _UM;
		}
	}

	private void Awake()
	{
		MakeSingleton();
	}

	private void MakeSingleton()
	{
		if (_UM == null)
		{
			_UM = this;
		}
		else if (_UM != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	#endregion

	public void SetUsername (string name)
	{
		_userName = name;
	}

	public string GetUsername()
	{
		return _userName;
	}
}