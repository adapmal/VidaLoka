﻿using UnityEngine;
using System.Collections;

public class Limite {
	public static float larguraPista = 21.5f;
	public static float deslocPista = 0.0f;
	public static float bordaEsq = deslocPista - larguraPista / 2.0f;
	public static float bordaDir = deslocPista + larguraPista / 2.0f;
	public static float limiarX = 0.07f;
	
	public static float tempoCapotagem = 5.0f;
	public static float dyMax = 0.42f;
}
public class Movimentacao1 : MonoBehaviour {
	
	public float tempoEscrito;
	
	public float speed;
	protected Animator animator;
	public float velocidadeMoto;
	public Limite limite;
	private GameObject moto;
	
	public float tempoCapotando = 0.0f;
	public float ay = 0.05f;
	public float dy;
	public bool capotando = false;
	
	public static bool aterrisou = false;
	public static bool jaBateu = false;
	
	void Start ()
	{

		animator = GetComponent<Animator> ();
		moto = GameObject.FindGameObjectWithTag ("Player");
		tempoEscrito = 0.0f;
	}
	
	float deltaX(float accX) {
		float delta = 0.0f;
		float absAccX = Mathf.Abs(accX);
		if (absAccX > Limite.limiarX) {
			delta = absAccX - Limite.limiarX;
		}
		if (accX < 0) {
			delta *= -1.0f;
		}
		return delta;
	}
	
	void Update () 
	{

		if (aterrisou)
			return;

		float tempoAtual = Time.time;
		float tempoCorrido = tempoAtual - tempoEscrito;
		tempoEscrito = tempoAtual;
		Rect metesq = new Rect(0, 0, Screen.width/2, Screen.height);
		Rect metdir = new Rect(Screen.width/2, 0, Screen.width/2, Screen.height);


		if (capotando) {
			UpdateCapote (tempoCorrido);
			return;
		}
		else if (animator.GetBool ("colidindo")) {
			animator.SetBool ("colidindo", false);
			animator.SetBool ("parabola", true);
			capotando = true;
			jaBateu = true;
			return;
		}

		float x = transform.position.x;
		float dx = deltaX(Input.acceleration.x);

		bool podeEsq = Limite.bordaEsq < x;
		bool podeDir = Limite.bordaDir > x;
		//Debug.Log (string.Format("{0}\t {1}\t {2}", Limite.bordaEsq, x, Limite.bordaDir));

		bool teclado = false;

		if ((dx < 0 && podeEsq) || (dx > 0 && podeDir))
			transform.Translate (dx, 0, 0);

		transform.Translate (0, 0, 2 * velocidadeMoto);

		if (Input.GetKey (KeyCode.A) && podeEsq) 
		{
			animator.SetBool ("Esq", true);
			animator.SetBool ("Dir", false);
			transform.Translate (-speed * 100 * Time.deltaTime, 0.0f, 0.0f);
			teclado = true;
		}

		if (Input.GetKey (KeyCode.D) && podeDir) 
		{
			animator.SetBool ("Esq", false);
			animator.SetBool ("Dir", true);
			transform.Translate (speed * 100 * Time.deltaTime, 0.0f, 0.0f);
			teclado = true;
		}

		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)) 
		{
						animator.SetBool ("Dir", false);
						animator.SetBool ("Esq", false);
		}

		if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.A)) 
		{
			animator.SetBool ("Dir", false);
			animator.SetBool ("Esq", false);
		}

		if (dx == 0 && teclado == false) {
			animator.SetBool("Dir", false);
			animator.SetBool ("Esq", false);

		}
		if (dx > 0.05)
		{
			animator.SetBool("Dir", true);
			animator.SetBool ("Esq", false);	
		}
		if (dx < -0.05)
		{
			animator.SetBool("Esq", true);
			animator.SetBool("Dir", false);
		}
		
		if (Input.GetKey (KeyCode.Mouse0) && metdir.Contains(Input.mousePosition))
		{
			animator.SetBool ("ChuteDir", true);
			animator.SetBool ("Dir", false);
			animator.SetBool ("Esq", false);
		}
		if (Input.GetKeyUp (KeyCode.Mouse0))
		{
			animator.SetBool ("ChuteDir", false);
		}
		if (Input.GetKey (KeyCode.Mouse0) && metesq.Contains(Input.mousePosition))
		{
			animator.SetBool ("ChuteEsq", true);
			animator.SetBool ("Dir", false);
			animator.SetBool ("Esq", false);
		}
		if (Input.GetKeyUp (KeyCode.Mouse0))
		{
			animator.SetBool ("ChuteEsq", false);
		}




	
		
	}
	
	void UpdateCapote(float dt) {
		tempoCapotando += dt;
		float maxt = Limite.tempoCapotagem;
		float dy0 = Limite.dyMax;
		dy = dy0 - 0.2f * tempoCapotando;
		
		transform.Translate (0, dy, 0.65f * velocidadeMoto);
		transform.rotation = Quaternion.identity;
		if (transform.position.y <= 0) {
			transform.position = new Vector3 (transform.position.x , 0, transform.position.z);
			capotando = false;
			aterrisou = true;
			Debug.Log("Distancia percorrida:");
			Debug.Log(transform.position.z);
		}
	}
}

