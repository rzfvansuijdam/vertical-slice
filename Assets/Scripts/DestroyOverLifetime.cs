﻿// Gemaakt door Emile
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverLifetime : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 10;

    private void Start()

    {
        StartCoroutine(DeathDelay());
    }

    public IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(this.gameObject);
    }
}