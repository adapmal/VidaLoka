using UnityEngine;
using System.Collections;

public class MovimentacaoCamera : MonoBehaviour {

	Transform target;
	public float distcam;

	void Start () {
		target = GameObject.Find ("Moto").transform;
		camera.transparencySortMode = TransparencySortMode.Orthographic;
		transform.Rotate (Vector3.left, -1f);
	
	}
	

	void Update () {
		if (!Movimentacao1.jaBateu)
			transform.position = target.position + new Vector3 (0,5f,-distcam);

	}


}
