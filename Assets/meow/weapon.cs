using UnityEngine;

public class weapon : MonoBehaviour
{
    public int id;
    public int preFabId;
    public float damage;
    public int count;
    public float speed;

    float timer;
    player player;

    private void Awake()
    {
        player=GetComponentInChildren<player>();
    }

    private void Start()
    {
        Init();
    }

    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back*speed*Time.deltaTime);
                break;

            default:
                timer += Time.deltaTime;

                if(timer>speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }

    public void LevelUp(float damage, int per)
    {
        this.damage = damage;
        this.count = count;

        if (id == 0)
            Batch();
    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            
            default:
                speed = 0.3f;
                break;
        }
    }

    void Batch()
    {
        for(int index = 0; index < count; index++)
        {
            Transform bullet = GameManager.instance.pool.Get(preFabId).transform;
            bullet.parent = transform;

            

            Vector3 rotVec = Vector3.forward*360*index/count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up*1.5f, Space.World);
            

            bullet.GetComponent<bullet>().Init(damage, -1);
        }
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;

        Transform bullet = GameManager.instance.pool.Get(preFabId).transform;
        bullet.position = transform.position;
    }
}
