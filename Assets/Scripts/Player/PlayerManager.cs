using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Stats Variable
    [SerializeField]
    public int m_life;
    [SerializeField]
    public int m_score;
    [SerializeField]
    int m_highScore;




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
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController.m_instance.Control();
    }
}
