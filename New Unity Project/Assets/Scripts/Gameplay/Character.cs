﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{

    #region members

    public Animator _anim;
    public float _rotateSpeed;

    //private float m_moveSpeed = 0.25f;
    private float m_moveSpeed = 1.0f;
    private float m_horizontalValue;
    private float m_verticalValue;

    #endregion

    #region Properties

    public float MoveSpeed
    {
        get { return m_moveSpeed; }
        set { m_moveSpeed = value; }
    }

    public float HorizontalValue
    {
        get { return m_horizontalValue; }
        set { m_horizontalValue = value; }
    }

    public float VerticalValue
    {
        get { return m_verticalValue; }
        set { m_verticalValue = value; }
    }


    #endregion

    #region Mono Functions

    void Start()
    {

        KeyBinder.Instance.DefineActions("Horizontal", new AxisActionConfig(KeyType.Movement, 0, Horizontal));
        KeyBinder.Instance.DefineActions("Vertical", new AxisActionConfig(KeyType.Movement, 0, value => { VerticalValue = value; }));
    }

    void FixedUpdate()
    {
        if (HorizontalValue != 0f || VerticalValue != 0f)
        {
            //_anim.SetBool("Walk", true);
            ApplyMove(MoveSpeed);
        }
        else
        {
            //_anim.SetBool("Walk", false);
        }

    }

    #endregion

    #region Character Functions

    void Horizontal(float value)
    {
        Vector3 currEuler = transform.localRotation.eulerAngles;
        currEuler.y += value * _rotateSpeed;

        transform.localRotation = Quaternion.Euler(currEuler);
        //_camera.transform.Rotate(Vector3.right, (-value * _rotateSpeed));
    }

    void ApplyMove(float moveSpeed)
    {
        transform.position += VerticalValue > 0 ? transform.right * moveSpeed : -transform.right * moveSpeed;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    #endregion


}