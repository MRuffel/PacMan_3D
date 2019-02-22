using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    #region Variable

    [SerializeField]
    bool m_inkyAndClyde;

    [SerializeField]
    Transform m_ghostTarget;

    Vector3 m_newDestination;

    NavMeshAgent m_ghost;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
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

        Vector3 m_destination = PlayerController.m_instance.m_ghostTarget;
        //Vector3 m_newVector = new Vector3(m_destination.position.x, 0, m_destination.position.z);

        Vector3 m_ghostPosition = new Vector3(m_ghost.transform.localPosition.x, 0, m_ghost.transform.localPosition.y);

        Debug.Log(m_destination + "1");
        Debug.Log(m_ghostPosition + "2");
        if (m_ghostPosition == m_destination)
        {
            Debug.Log("in");
            // Debug.Log(m_ghost.transform.localPosition);
            //Debug.Log(m_newVector);
            m_ghost.SetDestination(m_newDestination);
        }
        else{m_ghost.SetDestination(m_destination);}
    }
}
