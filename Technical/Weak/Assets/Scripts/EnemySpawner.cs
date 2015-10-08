using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyObjects;
    public int Speed = 10;
    public float RepeatRate = 3f;
	// Use this for initialization
	void Start ()
	{
        InvokeRepeating("SpawnEnemy", 2f, 3);
	}

    void SpawnEnemy()
    {
        GameObject instance =
            Instantiate(EnemyObjects[0], gameObject.transform.position, Quaternion.identity) as GameObject;
        if (instance != null)
        {
            Speed = Random.Range(1, 5);
            instance.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
    }

}
