using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TypeEnemy
{
    RUN = 1,
    SKE = 2
}
[System.Serializable]
public class EnemyObject
{
    public TypeEnemy type;
    public GameObject prefabs;
}

public class EnemySpawner : MonoBehaviour
{
    public int speed = 10;
    public float repeatRate = 10f;
    public float spawnTime = 0.8f;
    public List<EnemyObject> listEnemy;
    public Transform left;
    public Transform right;
    public int number = 6;

	// Use this for initialization
	void Start ()
	{
        InvokeRepeating("SpawnEnemy", 2f, repeatRate);
	}

    void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else if (spawnTime <= 0)
        {
            spawnTime = 0.8f;
        }
        SpawnEnemy();
        if (repeatRate > 0)
        {
            repeatRate -= Time.deltaTime;
        }
        else if(repeatRate<=0)
        {
            repeatRate = 10f;
            number = 6;
        }
    }

    void SpawnEnemy()
    {
        if (spawnTime <= 0 && number>0)
        {
            GameObject objectE = RandomEnemy();
            Transform pos = RandomSpawn();
            GameObject instance =
                Instantiate( objectE, pos.position , Quaternion.identity) as GameObject;
            number--;
        }
        
    }

    GameObject RandomEnemy()
    {
        int typeE = Random.Range(1, 2);
        TypeEnemy t = (TypeEnemy) typeE;
        for (int i = 0; i < listEnemy.Count; i++)
        {
            if (listEnemy[i].type == t)
            {
                return listEnemy[i].prefabs;
            }
        }
        return null;
    }

    Transform RandomSpawn()
    {
        int n = Random.Range(1, 3);
        if (n == 1)
        {
            return left;
        }
        else
        {
            return right;
        }
    }
}
