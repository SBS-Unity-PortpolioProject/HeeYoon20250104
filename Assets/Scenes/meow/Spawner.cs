using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public Transform[] spawnData;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            GameManager.instance.pool.Get(1);
            timer = 0;
        }

        if(Input.GetButtonDown("Jump"))
        {
            GameManager.instance.pool.Get(1);
        }

        void spawn()
        {
            GameObject emnemy = GameManager.instance.pool.Get(Random.Range(0,2));
            emnemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        }
    }
}
[System.Serializable]
public class SpawnData
{
    public int health;
}

