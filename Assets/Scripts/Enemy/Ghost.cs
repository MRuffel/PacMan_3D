using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    #region Variable

    GameObject[] m_ghosts;

    [SerializeField]
    bool m_inkyAndClyde;

    Transform m_ghostSetPos;

    [SerializeField]
    public Transform m_resetPosition;
    
    [SerializeField]
    Transform m_ghostTarget;

    Vector3 m_newDestination;

    NavMeshAgent m_ghost;
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        m_ghosts = GhostsList.m_instance.m_ghosts;
        m_ghostSetPos = GetComponent<Transform>();
         m_ghost = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_inkyAndClyde)
        {
            TrackingWithNodes();
        }
        else { Tracking(); }
    }

    void Tracking() {

        Vector3 m_vectorDestination = new Vector3(m_ghostTarget.position.x, 0, m_ghostTarget.position.z);
        m_newDestination = m_vectorDestination;
        m_ghost.SetDestination(m_vectorDestination);
       
    }

    void TrackingWithNodes() {

        Vector3 m_destination = PlayerController.m_instance.m_ghostTarget; //Vector from the point of impact of the node      
        Vector3 m_ghostPosition = new Vector3(m_ghost.transform.localPosition.x, 0, m_ghost.transform.localPosition.y);

        if (m_ghostPosition == m_destination)
        {
            m_ghost.SetDestination(m_newDestination);
        }
        else{m_ghost.SetDestination(m_destination);}
    }
    
    public void ResetGhostPosition() {

        
        for (int i = 0; i < m_ghosts.Length; i++){
            Vector3 m_temp = new Vector3(m_resetPosition.transform.position.x, m_resetPosition.transform.position.y, m_resetPosition.transform.position.z);
            m_ghostSetPos.transform.SetPositionAndRotation(m_temp, Quaternion.Euler(0, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            PlayerManager.m_instance.GetHit();
            ResetGhostPosition();

        }


    }

}
