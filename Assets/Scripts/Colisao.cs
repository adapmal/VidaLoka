using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour {

	protected Animator animator;
	
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void OnCollisionEnter(Collision other) {
		StartCoroutine (ResetMoto());
		animator.SetBool ("colidindo", true);
	}

	IEnumerator ResetMoto () {
		yield return new WaitForSeconds (4);
		
		animator.SetBool ("parabola", false);
		Movimentacao1.jaBateu = false;
		Movimentacao1.aterrisou = false;
		Application.LoadLevel (0);
	}
}

