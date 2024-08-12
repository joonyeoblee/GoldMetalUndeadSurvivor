using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.forward * speed * Time.deltaTime); //시계방향으로 회전

                break;

            case 1:
                break;

            default:
                break;
        }

        // ... Test Code..
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp(20, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
            LocateWeapon();

    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed -= 150; //무기가 움직이는 속도 음수여야 시계방향
                LocateWeapon();
                break;

            case 1:
                break;

            default:
                break;
        }
    }

    void LocateWeapon()
    {
        for (int index = 0; index < count; index++)
        {
            //bullet이 생성될때 Pool의 자식으로 등록 이를 바꾸기 위한 Transform
            Transform bullet;
            if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.Instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            // 무기 회전
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity per.



        }
    }
}