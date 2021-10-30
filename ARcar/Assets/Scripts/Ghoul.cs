using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    //private Vector3 Camera;//���������� ��������� ������
    //public float speed;//�������� �������
    // Start is called before the first frame update

    public float moveSpeed = 2f;//�������� ������
    public float turnSpeed = 90;//�������� �������� � �������

    private CharacterController _controller;
    private Transform _thisTransform;
    private Transform _playerTransform;


    void Start()
    {


        //Camera = GameObject.Find("Player").transform.position;
        //�������� ����������
        _controller = GetComponent<CharacterController>();

        //�������� ��������� ������������� ����� ������� 
        _thisTransform = transform;

        //�������� ��������� ������������� ������ � ������������
        targetForGhoul player = (targetForGhoul)FindObjectOfType(typeof(targetForGhoul));
        _playerTransform = player.transform;
    }

    private void FixedUpdate()
    {
        // Vector3 delta = transform.position - Camera.posit
        //������ ����������� �� ������
        Vector3 playerDirection = (_playerTransform.position - _thisTransform.position).normalized;

        //���� �������� �� ������
        float angle = Vector3.Angle(_thisTransform.forward, playerDirection);

        //������������ ���� �������� �� ������� �����
        float maxAhgle = turnSpeed * Time.deltaTime;

        //��������� ������ ������� �� ������ 
        Quaternion rot = Quaternion.LookRotation(_playerTransform.position - _thisTransform.position);

        //������������ ������� �� ������ � ������ �������� ��������
        if (maxAhgle < angle)
        {
            _thisTransform.rotation = Quaternion.Slerp(_thisTransform.rotation, rot, maxAhgle / angle);

        }
        else
        {
            _thisTransform.rotation = rot;

        }
        //���� ��������� �� ������ ������ �������� ����� �� ����
        if (Vector3.Distance(_playerTransform.position, _thisTransform.position) > 0.5f)
        {
            _controller.Move(_thisTransform.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            //������� ����� � ��������� ����� 
        }
        //���������� 
        _controller.Move(Vector3.down * 10.0f * Time.deltaTime);
    }
    
}
