using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetForGhoul : MonoBehaviour
{
    private CharacterController _controller;
    private Transform _thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();//получаем контроллер
        _thisTransform = transform;//получаем компонент трансформации объекта к которому привязан компонент 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
