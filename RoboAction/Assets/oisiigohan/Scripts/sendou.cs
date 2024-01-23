using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class sendou : MonoBehaviour
{
    public CinemachineDollyCart cart;
    const float speed = 0.04f;
    void FixedUpdate()
    {
        cart.m_Position += speed * walk.iswalk;
    }
}