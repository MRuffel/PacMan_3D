using UnityEngine;

public class CollectableNodes : MonoBehaviour
{
    #region Variable

    [SerializeField]
    int m_points;


    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.m_instance.m_score += m_points;
            this.gameObject.SetActive(false);
        }

    }
}
