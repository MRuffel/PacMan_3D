using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Stats Variable

    int m_life;
    int m_score;
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
