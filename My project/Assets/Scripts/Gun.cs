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
    // Start is called before the first frame update
    void Fire()
    {
        GameObject bullet = Instantiate(this.bullet, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward.normalized * bulletSpeed, ForceMode.Impulse);  
        Destroy(bullet, 2.0f);

    }
    private void Fire2(){
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
            Fire2();
        }
    }
    // Update is called once per frame

    
}
