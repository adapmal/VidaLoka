using UnityEngine;
using System.Collections;

public class MovApagador : MonoBehaviour {

		Transform target;
		public float distapagador;
		
		void Start () {
			target = GameObject.Find ("Moto").transform;
			
		}
		
		
		void Update () {
			if (!Movimentacao1.jaBateu)
				transform.position = target.position + new Vector3 (0,0,-distapagador);
		}
	}
