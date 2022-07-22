using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject.Instantiate(bulletPrefab, firePoint); // 생성된 게임오브젝트를 Transform에 종속시킴
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }


}
