using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    //private Vector3 Camera;//переменная координат камеры
    //public float speed;//скорость зомбака
    // Start is called before the first frame update

    public float moveSpeed = 2f;//скорость ходьбы
    public float turnSpeed = 90;//скорость повортоа в секунду

    private CharacterController _controller;
    private Transform _thisTransform;
    private Transform _playerTransform;


    void Start()
    {


        //Camera = GameObject.Find("Player").transform.position;
        //получаем контроллер
        _controller = GetComponent<CharacterController>();

        //получаем компонент трансформации этого объекта 
        _thisTransform = transform;

        //получаем компонент трансформации камеры в пространстве
        targetForGhoul player = (targetForGhoul)FindObjectOfType(typeof(targetForGhoul));
        _playerTransform = player.transform;
    }

    private void FixedUpdate()
    {
        // Vector3 delta = transform.position - Camera.posit
        //задаем направление на игрока
        Vector3 playerDirection = (_playerTransform.position - _thisTransform.position).normalized;

        //угол поворота на игрока
        float angle = Vector3.Angle(_thisTransform.forward, playerDirection);

        //максимальный угол поворота на текущем кадре
        float maxAhgle = turnSpeed * Time.deltaTime;

        //вычисляем прямой поворто на игрока 
        Quaternion rot = Quaternion.LookRotation(_playerTransform.position - _thisTransform.position);

        //поворачиваем замбака на игрока с учетом скорости поворота
        if (maxAhgle < angle)
        {
            _thisTransform.rotation = Quaternion.Slerp(_thisTransform.rotation, rot, maxAhgle / angle);

        }
        else
        {
            _thisTransform.rotation = rot;

        }
        //если дистанция до игрока больше половины метра то раан
        if (Vector3.Distance(_playerTransform.position, _thisTransform.position) > 0.5f)
        {
            _controller.Move(_thisTransform.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            //вписать крики и отнимание жизни 
        }
        //гравитация 
        _controller.Move(Vector3.down * 10.0f * Time.deltaTime);
    }
    
}
