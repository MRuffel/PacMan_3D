using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    [SerializeField]
    Transform m_portal;

    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            PlayerController.m_instance.m_playerTransform.localPosition = m_portal.transform.position;
        }

    }
}
