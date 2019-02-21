using UnityEngine;
using UnityEngine.Audio;

public class Collectables : MonoBehaviour
{
    #region Variable

    [SerializeField]
    int m_points;

    [SerializeField]
    string m_tagName;

    [SerializeField]
    string m_clipName;

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == m_tagName)
        {

            AudioManager.m_instance.Play(m_clipName);
            PlayerManager.m_instance.m_score += m_points;
            this.gameObject.SetActive(false);
        }

    }
}
