using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour {

    /*private float EffectTime;

    private float[] RemainingTime;

    private UnityEngine.Color ShieldColor;
    private UnityEngine.Color tempColor;
    private byte hitCount = 0;
    private float shieldHP;

    private GameObject shield;

    //alpha value of the ENTIRE shield in the moment of hit. minimum value is the shieldcolor alpha
    float tempAlpha = 0.01f;
    //the time in ms while the above flashing happens
    float flashTime;
    
    //UI Text type object to show shield HP readout
    [SerializeField]
    UnityEngine.UI.Text textHP;

    void Start()
    {
	    hitCount = 0;
	    RemainingTime = new float[10];
	
	    ShieldColor = shield.GetComponent<Renderer>().material.GetColor("_ShieldColor");
	    EffectTime = shield.GetComponent<Renderer>().material.GetFloat("_EffectTime");
	    shieldHP = shield.GetComponent<Renderer>().material.GetFloat("_ShieldHP");
	
	    tempColor = ShieldColor;
	    tempColor.a = Mathf.Clamp(tempAlpha, ShieldColor.a, 1);
    }

    void Update()
    {
	    //shield regeneration
	    shieldHP = Mathf.Clamp(shieldHP + 0.005f * Time.deltaTime, 0, 1);
	
	    //if there is shield turn on collider
	    if(shieldHP > 0.001)
	    {
            shield.GetComponent<Renderer>().material.SetFloat("_ShieldHP", shieldHP);
		    this.GetComponent<Collider>().enabled = true;
	    }
	
	    if(Mathf.Max(RemainingTime) > 0)
	    {
		    if(Mathf.Max(RemainingTime) < (EffectTime - flashTime))
		    {
			    shield.GetComponent<Renderer>().material.SetColor("_ShieldColor", ShieldColor);
		    }
		
		    for(var i=0; i<10; i++)
		    {
			    RemainingTime[i] = Mathf.Clamp(RemainingTime[i] - Time.deltaTime * 1000, 0, EffectTime);
                shield.GetComponent<Renderer>().material.SetFloat("_RemainingTime" + i.ToString(), RemainingTime[i]);
                //shield.GetComponent<Renderer>().material.SetVector("_Position" + i.ToString(), transform.Find("hitpoint" + i.ToString()).position);		
            }
        }
	
	    textHP.text = "Shield:" + (Mathf.RoundToInt(shieldHP * 1000)).ToString();
    }
	
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollision enter");
	    //draining shield HP
	    shieldHP = Mathf.Clamp(shieldHP - 0.001f, 0, 1);
	
	    //if there is no shield, turn off collider, so the shots can hit the ship instead
	    if(shieldHP <= 0.001)
	    {
		    shieldHP = 0;
		    this.GetComponent<Collider>().enabled = false;
            shield.GetComponent<Renderer>().material.SetFloat("_ShieldHP", shieldHP);
	    }
	    else
	    {
		    foreach (ContactPoint contact  in collision.contacts)
		    {
                shield.GetComponent<Renderer>().material.SetColor("_ShieldColor", tempColor);
                shield.GetComponent<Renderer>().material.SetFloat("_ShieldHP", shieldHP);
			    //transform.Find("hitpoint" + hitCount.ToString()).position = contact.point;
			    RemainingTime[hitCount] = EffectTime;
			    hitCount++;
			    if(hitCount > 9)
				    hitCount = 0;
		    }
	    }
    }*/
}
