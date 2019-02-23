using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{

    #region Stats Variable
    [SerializeField]
    public int m_life;
    [SerializeField]
    public int m_score;
    [SerializeField]
    public int m_highScore;


    [SerializeField]
    Transform m_resetPosition;

    Vector3 m_tempVec3;

    #endregion

    #region UI
    [SerializeField]
    Text m_scoreText;
    [SerializeField]
    Text m_liveText;
    [SerializeField]
    Text m_highScoreText;

    #endregion

    #region Singleton

    //Instance
    public static PlayerManager m_instance = null;

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
        SetUI();
        PlayerController.m_instance.m_playerSetPos.transform.SetPositionAndRotation(m_tempVec3, Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        HighScore();
        PlayerController.m_instance.Control();
        if (m_life == 0)
        {
            Death();

        }
        SetUI();
    }


    void Death() {

        AudioManager.m_instance.Play("Death");

    }

    public void GetHit() {

        m_life --;
        AudioManager.m_instance.Play("Death");
       ResetPosition();

    }

    
    void ResetPosition() {
        // Create a Vector 3 from the playerGo
        m_tempVec3 = new Vector3(m_resetPosition.transform.position.x, m_resetPosition.transform.position.y, m_resetPosition.transform.position.z);
        //Set the reset position of the player
        PlayerController.m_instance.m_playerSetPos.transform.SetPositionAndRotation(m_tempVec3, Quaternion.Euler(0, 0, 0));
        
    }

    void HighScore() {

        if (m_score >= m_highScore) {

            m_highScore = m_score ;

        }

    }

    void SetUI() {

        m_scoreText.text = "Score : " + m_score;
        m_liveText.text = "Lives : " + m_life;
        m_highScoreText.text = "HighScore :" + m_highScore;

    }

}
