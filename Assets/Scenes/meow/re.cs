using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   
    Collider2D Coll;

    private void Awake()
    {
        Coll = GetComponent<Collider2D>();
    }
        
    void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("area"))
            return; // Ż��!

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffx = Mathf.Abs(playerPos.x - myPos.x); // �÷��̾� ��ġ - Ÿ�ϸ� ��ġ ( �Ÿ����ϱ�? )
        float diffy = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.input;
        float dirX = playerDir.x < 0 ? -1 : 1; // 3�� ������ ( ���� ) ? ( turn �� ) : ( false �� )
        float dirY = playerDir.y < 0 ? -1 : 1;

        Debug.Log("diffy : " + diffy);
        Debug.Log("diffx : " + diffx);

        switch (transform.tag)
        {
            case "ground":
                {
                    if (diffx > diffy)
                    {
                        transform.Translate(Vector3.right * dirX * 40, Space.Self);
                    }
                    else if (diffx < diffy)
                    {
                        transform.Translate(Vector3.up * dirY * 40, Space.Self);
                    }
                }
                break;
            case "enermy":
                if (Coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }

                break;
        }
    }
}

