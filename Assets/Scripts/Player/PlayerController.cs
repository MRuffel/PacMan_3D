using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Stats Variable
    [SerializeField]
    int m_life;
    [SerializeField]
    public int m_score;
    [SerializeField]
    int m_highScore;




    #endregion
    #region Control Variable

    [SerializeField]
    Rigidbody m_player;


    [SerializeField]
    Transform m_playerTransform;

    [SerializeField]
    float m_force;

  
    #endregion

    #region Singleton
    //Instace
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

    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Control();
    }


    void Control() {


        if (Input.GetKey(KeyCode.W)) {

            m_playerTransform.localRotation = Quaternion.Euler(0,-90, 0);
            m_player.AddForce( new Vector3(0,0,1 * m_force) * m_force);
        }
        else m_player.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0, 180, 0);
            m_player.AddForce(new Vector3(-1 * m_force, 0, 0) * m_force);
        }
        else m_player.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.S))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0,90, 0);
            m_player.AddForce(new Vector3(0, 0,-1 * m_force) * m_force);
        }
        else m_player.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            m_playerTransform.localRotation = Quaternion.Euler(0,0, 0);
            m_player.AddForce(new Vector3(1 * m_force,0,0) * m_force);
        }
        else m_player.velocity = new Vector3(0, 0, 0);
        /*switch (Input.GetKeyDown()) {

        case :
            m_playerTransform.localRotation = Quaternion.Euler(0, 180, 0);
            m_player.AddForce(transform.forward * m_force);
            break;



    }*/
    }

}
