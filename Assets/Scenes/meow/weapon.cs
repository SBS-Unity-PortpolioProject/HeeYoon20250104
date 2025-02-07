using UnityEngine;

public class weapon : MonoBehaviour
{
    public int id;
    public int preFabId;
    public float damage;
    public int count;
    public float speed;
  
    void Update()
    {
        
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
                break;
        }
    }

    void Batch()
    {
        for(int index = 0; index < count; index++)
        {
            Transform bulllet = GameManager.instance.pool.Get(preFabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<bullet>().Init(damage, -1);
        }
    }
}
