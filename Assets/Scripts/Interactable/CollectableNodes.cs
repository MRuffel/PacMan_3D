using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNodes : MonoBehaviour
{
    #region Variable

    [SerializeField]
    int m_points;


    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == m)
        {
            PlayerController.m_instance.m_score += m_points;

        }

    }
}
