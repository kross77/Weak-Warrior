using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public int speed = 10;
    public float repeatRate = 3f;
	// Use this for initialization
	void Start ()
	{
        InvokeRepeating("SpawnEnemy", 2f, repeatRate);
	}

    void SpawnEnemy()
    {
        GameObject instance =
            Instantiate(enemyObjects[0], gameObject.transform.position, Quaternion.identity) as GameObject;
    }

}
