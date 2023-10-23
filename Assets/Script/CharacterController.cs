using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    [SerializeField] float maxspeed = 3.0f;
    [SerializeField] float rotatespeed = 360.0f;

    private SimpleAnimation _simpleAnimation = null; // Unity�� SimpleAnimation�V�X�e�����g�p����B
    private Camera mainCamera = null;

    // ���͕ێ��p
    private Vector3 inputDirection;
    private Vector3 lookingDirection;


    // Start �͍ŏ��̃t���[���X�V�̑O�ɌĂяo����܂��B
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _simpleAnimation = GetComponent<SimpleAnimation>();
        lookingDirection = new Vector3(1, 0, 1);
        _simpleAnimation.GetState("WAIT").speed = 0.7f; // �A�j���[�V�����N���b�v�̍Đ����x��1.0�{
        _simpleAnimation.GetState("RUN").speed = 1.2f;  // �A�j���[�V�����N���b�v�̍Đ����x��1.0�{


        mainCamera = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        // �L�[���͂��擾

        inputDirection.z = Input.GetAxis("Horizontal");
        inputDirection.x = Input.GetAxis("Vertical");

        // ���C���J�����̌����ɂ���ē��͂𒲐�
        Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        inputDirection = cameraForward * inputDirection.x + mainCamera.transform.right * inputDirection.z;

        moveDirection = inputDirection * maxspeed;
        // �����ꂩ�̕����ɓ��͂�����ꍇ�B
        if (inputDirection != Vector3.zero)
        {
            // ��]�I
            lookingDirection = inputDirection;
            // ���s�A�j���[�V�����ɑJ��
            _simpleAnimation.CrossFade("RUN", 0.2f);
        }
        else
        {
            // �R���g���[������̓��͂��Ȃ��A��~�A�j���[�V�����ɑJ�ځB
            _simpleAnimation.CrossFade("WAIT", 0.2f);
        }

        // �����]������(�X���[�Y�ɉ�]����悤�A�኱�f�B���C�������Ă��܂�)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookingDirection), (rotatespeed * Time.deltaTime));
        controller.Move(moveDirection * Time.deltaTime);
    }
}
