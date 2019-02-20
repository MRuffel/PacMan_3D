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
    float m_force;

    float m_horizontalMovement;
    float m_verticalMovement;
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

        m_horizontalMovement = Input.GetAxis("Horizontal");
        m_verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(m_horizontalMovement, 0f, m_verticalMovement);


        m_player.AddForce(movement * m_force * Time.deltaTime);

    }

}
