using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoGloul_IzI : MonoBehaviour

    
{
    public GameObject playerCube;
    public float speedMove = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerCube = GameObject.FindWithTag("TargetForZomback");
    }

    private void FixedUpdate()
    {
        float direction = playerCube.transform.position.x - transform.position.x;
        if (Mathf.Abs(direction) < 1.0f)
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
