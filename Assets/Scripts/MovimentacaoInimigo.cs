using UnityEngine;
using System.Collections;

public class MovimentacaoInimigo : MonoBehaviour {

	static public float velocidade_lateral = 0.1f;
	static public int chance_mudanca = 50; //Chance de mudar de faixa (%)

	private float[] posicoes = new float[] {-8.2f, -2.7f, 2.7f, 8.2f};
	private float[] velocidades = new float[] {0.1f, 0.2f, 0.3f, 0.4f};

	public float posicao_futura;
	public float velocidade;

	// Use this for initialization
	void Start () {
		if (Random.Range (0, 100) < chance_mudanca) {
			posicao_futura = posicoes [Random.Range (0, posicoes.Length)];
		} else {
			posicao_futura = transform.position.x;
		}
		velocidade = velocidades [Random.Range (0, velocidades.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if(posicao_futura > transform.position.x && posicao_futura-transform.position.x > 0.2)
			transform.Translate (1 * velocidade_lateral, 0, 0);
		else if(posicao_futura < transform.position.x && posicao_futura-transform.position.x < -0.2)
			transform.Translate (-1 * velocidade_lateral, 0, 0);

		transform.Translate (0, 0, velocidade/2, Space.World);
	}
}
