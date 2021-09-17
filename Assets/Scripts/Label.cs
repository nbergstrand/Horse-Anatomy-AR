using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label : MonoBehaviour
{
    [SerializeField]
    Transform _lineTarget;

    [SerializeField]
    Transform _lineStart;

    LineRenderer _line;

    void Start()
    {
        _line = GetComponent<LineRenderer>();

        _line.startWidth = 0.005f;
        _line.endWidth = 0.005f;
        _line.material.color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        _line.SetPosition(0, _lineStart.position);
        _line.SetPosition(1, _lineTarget.position);
    }
}
