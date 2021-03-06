﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public UnityEvent damageTakeEvent;
    public SpriteRenderer render1;
    public SpriteRenderer render2;
    public bool canTakeDamage = true;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            RemoveHealth(1);
        }
        if (Input.GetKey(KeyCode.P))
        {
            AddHealth(1);
        }
    }

    private void Start()
    {
        maxHealth = int.MaxValue;
        health = starthealth;
        if (this.GetComponent<PlayerHealthInferface>() != null)
        {
            damageTakeEvent.AddListener(() =>
            {
                this.GetComponent<PlayerHealthInferface>().UpdateUI(health);
            });
            this.GetComponent<PlayerHealthInferface>().UpdateUI(health);
        }
    }

    public override void RemoveHealth(float amount)
    {
        if (canTakeDamage)
        {
            base.RemoveHealth(amount);
            damageTakeEvent.Invoke();
            StartCoroutine(DamageIndicator());
        }
    }

    public override void AddHealth(float amount)
    {
        base.AddHealth(amount);
        damageTakeEvent.Invoke();
    }

    public override void Die()
    {
    }

    public IEnumerator DamageIndicator()
    {
        canTakeDamage = false;
        render1.GetComponent<SpriteRenderer>().color = Color.red;  
        render2.GetComponent<SpriteRenderer>().color = Color.red;  
        yield return new WaitForSeconds(1);
        render1.GetComponent<SpriteRenderer>().color = Color.white;    
        render2.GetComponent<SpriteRenderer>().color = Color.white;    
        canTakeDamage = true;
        yield return null;
    }
}