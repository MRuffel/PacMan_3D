using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public Vector3 m_ghostTarget;

    #region Control Variable

    [SerializeField]
    Rigidbody m_playerRB;

    [SerializeField]
    public Transform m_playerTransform;

    [SerializeField]
    float m_force;

    [SerializeField]
    float m_speed;

    [SerializeField]
    float m_initialForce;
    [SerializeField]
    float m_initialSpeed;

    [SerializeField]
    float m_rotYW;

    [SerializeField]
    float m_rotYA;


    [SerializeField]
    float m_rotYS;


    [SerializeField]
    float m_rotYD;


    #endregion

    #region Singleton
    //Instance
    public static PlayerController m_instance = null;

    //Manage the singleton lifecycle
     protected void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else if (m_instance != this)
            Destroy(this);
    }

    #endregion

     private void Start()
    {
        m_initialForce = m_force;
        m_initialSpeed = m_speed;

    }


    public void Control() {

       
        #region Input WASD
        if (Input.GetKey(KeyCode.W))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0,m_rotYW, 0);
            m_playerRB.AddForce( new Vector3(0,0,1 * m_force) * m_speed);            
        }
        else m_playerRB.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0, m_rotYA, 0);
            m_playerRB.AddForce(new Vector3(-1 * m_force, 0, 0) * m_speed);
        }
        else m_playerRB.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.S))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0, m_rotYS, 0);
            m_playerRB.AddForce(new Vector3(0, 0,-1 * m_force) * m_speed);
        }
        else m_playerRB.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0, m_rotYD, 0);
            m_playerRB.AddForce(new Vector3(1 * m_force,0,0) * m_speed);
        }
        else m_playerRB.velocity = new Vector3(0, 0, 0);
        #endregion

        #region Diagonal Blocker
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            m_force *= 0;
            m_speed *= 0;
        }
        
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            m_force *= 0;
            m_speed *= 0;
        }
        
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            m_force *= 0;
            m_speed *= 0;
        }
        
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            m_force *= 0;
            m_speed *= 0;
        }
        else { m_force = m_initialForce; m_speed = m_initialSpeed; }

        #endregion
       


    }


    private void OnTriggerEnter(Collider other){
        if (other.tag == "Node") {
            Transform m_transform = other.transform.GetComponent<Transform>();
            m_ghostTarget = new Vector3 (m_transform.position.x,0,m_transform.position.z);

        }
    }
}
