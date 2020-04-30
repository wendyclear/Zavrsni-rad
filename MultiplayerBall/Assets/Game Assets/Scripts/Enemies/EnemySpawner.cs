using UnityEngine;
using System.Collections;
using Photon.Pun;

public class EnemySpawner : MonoBehaviour
{
	// javne variable

	[SerializeField]
	public float xMinRange = -4.0f;
	[SerializeField]
	public float xMaxRange = 4.0f;
	[SerializeField]
	public float yMinRange = 0.0f;
	[SerializeField]
	public float yMaxRange = 0.0f;
	[SerializeField]
	public float zMinRange = -100.0f;
	[SerializeField]
	public float zMaxRange = 100.0f;
	[SerializeField]
	public float numberOfEnemies = 20.0f;
	[SerializeField]
	public float timeToPoplulateLevel = 3.0f;
	public GameObject[] spawnObjects; // what prefabs to spawn

	//privatne variable
	private float nextSpawnTime;
	private float secondsBetweenSpawning;


	// Inicijalizacija
	void Start()
	{   // definicija vremena za instanciranje sljedećeg objekta (u koliko vremena se svi instanciraju)
		secondsBetweenSpawning = timeToPoplulateLevel / numberOfEnemies;
		nextSpawnTime = (float)PhotonNetwork.Time + secondsBetweenSpawning;
	}

	// Ova funkcija se poziva jednom po okviru
	void Update()
	{
		//jesu li svi neprijatelji kreirani? ako nisu provjeri treba li novog
		if (numberOfEnemies > 0)
		{
			// je li vrijeme za generiranje novog neprijatelja
			if (PhotonNetwork.Time >= nextSpawnTime)
			{
				// Spawn the game object through function below
				MakeThingToSpawn();
				//reduce the number of enemies
				numberOfEnemies = numberOfEnemies - 1;

				// definicija sljedećeg termina generiranja objekta
				nextSpawnTime = (float)PhotonNetwork.Time + secondsBetweenSpawning;
			}
		}
	}

	void MakeThingToSpawn()
	{
		Vector3 spawnPosition;

		// generiranje slučajne varijable pozicije
		spawnPosition.x = Random.Range(xMinRange, xMaxRange);
		spawnPosition.y = Random.Range(yMinRange, yMaxRange);
		spawnPosition.z = Random.Range(zMinRange, zMaxRange);

		// slučajno generiranje objekta koji će se pojaviti
		int objectToSpawn = Random.Range(0, spawnObjects.Length);

		// instanciranje objekta
		//GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;
		GameObject spawnedObject = PhotonNetwork.InstantiateSceneObject(spawnObjects[objectToSpawn].name, spawnPosition, transform.rotation) as GameObject;

		// postavljanje objekta spawnera kao roditelja kreiranog objekta (čuvamo hijerarhiju čistom)
		spawnedObject.transform.parent = gameObject.transform;
	}
}
