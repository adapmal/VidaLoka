// ...

	public GameObject moto;

	public float velocidadeBase = 4.0f;
	public float velocidadeMaxima = 8.0f;
	public float aceleracaoComum = 0.1f;
	public float aceleracaoPosColisao = 0.3f;
	public float esperaAposColisao = 1.5f;

	public float tempoEscrito;
	public float velocidadeAtual;
	public float aceleracaoAtual;

	public bool colidindo = false;

	// --------------------------------------------------------------------------------------------

	void Start () {
		moto = GameObject.FindGameObjectWithTag("Moto");

		tempoEscrito = 0.0f; // ou Time.time, se possível
		velocidadeAtual = 0.0f;
		aceleracaoAtual = aceleracaoPosColisao;
	}

	void Update () {

		tempoAtual = Time.time;
		tempoCorrido = tempoAtual - tempoEscrito;
		tempoEscrito = tempoAtual;

		if (colidindo) {
			velocidadeAtual = 0.0f;
			colidindo = false;
		}

		float deltaZ = velocidadeAtual * tempoCorrido;

		velocidadePrevista = velocidadeAtual + aceleracaoAtual * tempoCorrido;
		if (velocidadePrevista > velocidadeMaxima)
			velocidadeAtual = velocidadeMaxima;
		else
			velocidadeAtual = velocidadePrevista;

		if (velocidadeAtual < velocidadeBase) {
			aceleracaoAtual = aceleracaoPosColisao;
		}
		else {
			aceleracaoAtual = aceleracaoComum;
		}

		transform.Translate(0, 0, deltaZ);
	}