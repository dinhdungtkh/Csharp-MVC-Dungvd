using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingHorse : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_horseRb;
    [SerializeField]
    private Animator m_animator;
    public float speed  = 100f;
    // Start is called before the first frame update
    void Update()
    {
        MoveHorse();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void PlayRunningAnimation()
    {
        m_animator.Play("Rig_Gallop_Harsh_RootMotion");
    }

    private void MoveHorse()
    {
        m_horseRb.velocity = new Vector3(0, 0,speed); // Adjust speed as needed
        PlayRunningAnimation();
    }
}

