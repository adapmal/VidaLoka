using UnityEngine;
using System.Collections;

public class Inimigos : MonoBehaviour {
	
	public GameObject[] inimigos;
	public float nextfire = 0.5f;	
	public float fireRate;
	public Transform OndeInim;
	private float[] posicoes = new float[] {-8.4f, -2.7f, 2.7f, 8.4f} ;
	
	
	public GameObject Estrada;
	public Transform ondeStr;
	public float nextestrada = 0.4f;	
	public float estradaRate;
	
	public GameObject Acostamento;
	public Transform ondeAcos;
	public float nextacos = 0.4f;	
	public float acosRate;
	
	
	void Start (){
		inimigos = GameObject.FindGameObjectsWithTag ("Inimigos");
	}
	void Update () {	
		
		if (Time.time > nextfire)
		{
			nextfire = Time.time + fireRate + Random.Range (0f,0.5f);
			Instantiate (inimigos[Random.Range(0,inimigos.Length)],new Vector3 (posicoes[Random.Range(0,4)], 0, OndeInim.position.z), OndeInim.rotation);
			
		}
		if (Time.time > nextestrada)
		{
			nextestrada = Time.time + estradaRate;
			Instantiate (Estrada, new Vector3 (0,-0.1f, ondeStr.position.z), ondeStr.rotation);
		}
		
		if (Time.time > nextacos)
		{
			nextacos = Time.time + acosRate;
			Instantiate (Acostamento, new Vector3 (Limite.bordaEsq - 1.05f, 0, ondeAcos.position.z), ondeAcos.rotation);
			Instantiate (Acostamento, new Vector3 (Limite.bordaDir + 1.05f, 0, ondeAcos.position.z), ondeAcos.rotation);
		}
		
		
		
	}
}


