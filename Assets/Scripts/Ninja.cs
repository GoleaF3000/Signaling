using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _home;
    [SerializeField] private Transform _chest;
    private Transform _target;

    private void Start()
    {
        SetTargetHome();
    }

    private void Update()
    {       
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
    
    public void SetTargetChest()
    {        
        _target = _chest;
    }

    public void SetTargetHome()
    {        
        _target = _home;
    }
}