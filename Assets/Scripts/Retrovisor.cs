using UnityEngine;
using System.Collections;


public class Retrovisor : MonoBehaviour {
	protected Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other) {
		animator.SetBool ("Pe", true);
	
		
	}
}
