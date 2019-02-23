using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsList : MonoBehaviour
{
    [SerializeField]
    public GameObject [] m_ghosts;

    #region Singleton

    //Instance
    public static GhostsList m_instance = null;

    //Manage the singleton lifecycle
    protected void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else if (m_instance != this)
            Destroy(this);
    }

    #endregion

}
