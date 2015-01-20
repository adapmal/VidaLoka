// ...

	public float larguraDaPista = 8.0f;
	public GameObject[] cenarios;
	public GameObject buraco;

	public float periodoMinimoEntreCenarios = 0.5f;
	public float distanciaMinimaDoCentroDaPista = 0.5f + larguraDaPista/2.0f;

	public float periodoMinimoEntreBuracos = 4.0f;

	float nextCenario, nextBuraco;

	// --------------------------------------------------------------------------------------------

	void Start () {
		cenarios = GameObject.FindGameObjectsWithTag("Cenarios");
		buraco = GameObject.FindGameObjectWithTag("Buraco");

		nextCenario = Time.time + 2 * periodoMinimoEntreCenarios;
		nextBuraco = Time.time + 5 * periodoMinimoEntreBuracos;
	}

	void Update () {

		// Instanciando CENÁRIO
		if (Time.time > nextCenario) {

			bool naEsquerda = Random.Range(0, 2) == 0;

			float x = distanciaMinimaDoCentroDaPista;
			x += Random.Range(0.0f, 5.0f);
			if (naEsquerda)
				x *= -1;

			GameObject cenario = cenarios[Random.Range(0, cenarios.length)];
			Vector3 posicaoCenario = new Vector3(x, 0, OndeCen.position.z);
			Instantiate(cenario, posicaoCenario, OndeCen.rotation);

			float nextCenario = Time.time + periodoMinimoEntreCenarios;
			nextCenario += Random.range(0.0f, 1.0f);
		}

		// Instanciando BURACO
		if (Time.time > nextBuraco) {

			float x = Random.Range(-larguraDaPista/2, larguraDaPista/2);
			Vector3 posicaoBuraco = new Vector3(x, 0, OndeBur.position.z);
			Instantiate(buraco, posicaoBuraco, OndeBur.rotation);

			float nextBuraco = Time.time + periodoMinimoEntreBuracos;
			nextBuraco += Random.range(0.0f, 4.0f);
		}
	}
