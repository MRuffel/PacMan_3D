using UnityEngine;

public class CollectableNodes : MonoBehaviour
{
    #region Variable

    [SerializeField]
    int m_points;

    
    



    #endregion

        void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.m_instance.Play("Wakka");
            PlayerManager.m_instance.m_score += m_points;
            this.gameObject.SetActive(false);
        }

    }
}
