using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] string _enemyTag = "Enemy";
    [SerializeField] string _goalTag = "Goal";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _enemyTag)
        {
            ChangeSceneGO();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _goalTag)
        {
            ChangeSceneGC();
        }
    }

    //�Q�[���I�[�o�[�V�[���ɑJ��
    void ChangeSceneGO()
    {
        SceneManager.LoadScene("GameOver");
    }
    //�Q�[���N���A�V�[���ɑJ��
    void ChangeSceneGC()
    {
        SceneManager.LoadScene("GameClear");
    }
}
