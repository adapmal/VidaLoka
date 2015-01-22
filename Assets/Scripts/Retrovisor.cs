using UnityEngine;
using System.Collections;


public class Retrovisor : MonoBehaviour {
	protected Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.gameObject.name == "Moto")
		{
		animator.SetBool ("Pe", true);
		Score.score += 1;
		}
	
		
	}
}
