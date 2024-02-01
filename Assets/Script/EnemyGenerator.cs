using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //���ԊԊu�̍ŏ��l
    [SerializeField] float _minTime = 2f;
    //���ԊԊu�̍ő�l
    [SerializeField] float _maxTime = 5f;
    //�����ꏊX��
    [SerializeField] float _appearancePositionX = 0f;
    //�����ꏊY��
    [SerializeField] float _appearancePositionY = 0f;
    //�����ꏊZ��
    [SerializeField] float _appearancePositionZ = 0f;

    //�G�������ԊԊu
    private float _interval;
    //�o�ߎ���
    private float _time = 0f;

    void Start()
    {
        //���ԊԊu�����肷��
        _interval = GetRandomTime();
    }

    void Update()
    {
        //���Ԍv��
        _time += Time.deltaTime;

        //�������Ԃ��傫���Ȃ����Ƃ�)
        if (_time > _interval)
        {
            //enemy��������
            GameObject enemy = Instantiate(enemyPrefab);
            //���������G�̍��W�����肷��(
            enemy.transform.position = new Vector3(_appearancePositionX, _appearancePositionY, _appearancePositionZ);
            //�o�ߎ��Ԃ�������
            _time = 0f;
            //���̎��ԊԊu�����肷��
            _interval = GetRandomTime();
        }
    }

    //�����_���Ȏ��Ԃ𐶐�����
    private float GetRandomTime()
    {
        return Random.Range(_minTime, _maxTime);
    }
}
