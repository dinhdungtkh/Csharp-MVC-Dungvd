using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float bulletSpeed = 1000f;
    [SerializeField]
    private AudioSource audioSource;

    List<GameObject> bulletList;

    void Start()
    {
        bulletList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }


    }
    // Start is called before the first frame update
    void Fire()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = spawnPoint.position;
                bulletList[i].transform.rotation = spawnPoint.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                
                break;
            }       
        }
        audioSource.Play();
    }
    private void Fire2()
    {
        GameObject tempBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 1.0f);

        audioSource.Play();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Fire2();
           Fire();
        }
    }
    // Update is called once per frame


}
