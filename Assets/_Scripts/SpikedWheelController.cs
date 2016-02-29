
//SpikedWheelCOntrollerController

/*  Developed by Shraddhaben Patel 300821026
    Last Modified by Shraddhaben Patel
    Last Modified Date: Feb 29,2016
    this file is used for controlling the Fire wheel or spiked wheel in the game.*/

using UnityEngine;
using System.Collections;

public class SpikedWheelController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private Transform _transform;


	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		this._transform.Rotate (0, 0, -3f);

	}
}
