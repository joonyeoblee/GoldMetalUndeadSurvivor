using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // Enemy의 Collider2D
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collition)
    {
        if (!collition.CompareTag("Area")) return;

        // 기존 시스템 사용시 코드
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;

        switch (transform.tag)
        {
            case "Ground":
                float dirX = playerPos.x - myPos.x;
                float dirY = playerPos.y - myPos.y;

                dirX = dirX > 0 ? 1 : -1;
                dirY = dirY > 0 ? 1 : -1;

                float diffX = Mathf.Abs(dirX);
                float diffY = Mathf.Abs(dirY);

                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));
                    //플레이어의 진행방향보다 좀더 앞에 재배치
                    transform.Translate(ran + dist * 2);
                }
                break;

        }
    }
}