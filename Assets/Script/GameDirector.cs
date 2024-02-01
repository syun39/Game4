using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _goal;
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _timer;
    //��������
    [SerializeField] float _timeLimit = 60.0f;
    
    void Start()
    {
        _player = GameObject.Find("Player");
        _goal = GameObject.Find("Goal");
        _text = GameObject.Find("Distance");
        _timer = GameObject.Find("Timer");
    }

    void Update()
    {
        float length = _goal.transform.position.z - _player.transform.position.z;
        _text.GetComponent<Text>().text = "�S�[���܂�" + length.ToString("F1") + "m";

        _timeLimit -= Time.deltaTime;
        _timer.GetComponent<Text>().text = "�c��" + _timeLimit.ToString("F1") + "�b";

        //�������Ԃ�0�ɂȂ�����Q�[���I�[�o�[�V�[���ɑJ��
        if (_timeLimit < 0)
        {
            ChangeSceneGO();
        }
    }

    void ChangeSceneGO()
    {
        SceneManager.LoadScene("GameOver");
    }
}
