using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collition)
    {
        if (!collition.CompareTag("Area")) return;

        // 기존 시스템 사용시 코드
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;

        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        // float diffX = Mathf.Abs(playerPos.x - myPos.x);
        // float diffY = Mathf.Abs(playerPos.y - myPos.y);

        // Input System 사용시 코드
        // Vector3 playerDir = GameManager.Instance.player.inputVec;
        // float diffX = playerDir.x < 0 ? -1 : 1;
        // float diffY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
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

                break;

        }
    }
}