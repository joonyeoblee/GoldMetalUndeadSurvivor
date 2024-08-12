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
                transform.Rotate(Vector3.forward * speed * Time.deltaTime); //�ð�������� ȸ��

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
                speed -= 150; //���Ⱑ �����̴� �ӵ� �������� �ð����
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
            //bullet�� �����ɶ� Pool�� �ڽ����� ��� �̸� �ٲٱ� ���� Transform
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

            // ���� ȸ��
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity per.



        }
    }
}