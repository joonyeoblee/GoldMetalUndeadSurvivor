using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer sprite;
    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReserve = new Vector3(-0.35f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotResrve = Quaternion.Euler(0, 0, 35);
    void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    void LateUpdate()
    {
        bool isResrve = player.flipX;

        if (isLeft)//
        {
            transform.localRotation = isResrve ? leftRotResrve : leftRot;
            sprite.flipX = isResrve;
            sprite.sortingOrder = isResrve ? 4 : 6;
        }
        else
        {
            transform.localPosition = isResrve ? rightPosReserve : rightPos;
            sprite.flipX = isResrve;
            sprite.sortingOrder = isResrve ? 6 : 4;
        }

    }

}
