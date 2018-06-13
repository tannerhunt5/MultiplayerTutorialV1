using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

    public GameObject EnemyPrefab;
    public int NumberOfEnemies;

    public override void OnStartServer()
    {
        for (int i = 0; i  < NumberOfEnemies; i++)
        {
            var SpawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
            var SpawnRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);

            var Enemy = (GameObject)Instantiate(EnemyPrefab, SpawnPosition, SpawnRotation);
            NetworkServer.Spawn(Enemy);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
