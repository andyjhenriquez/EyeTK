using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
	public Image LoadingBar;
	float currentValue;
	public float timeComplete;
	float timeElapsed;
	bool m_UpdateTimer;

	// Use this for initialization
	void Start()
	{
		timeElapsed = 0;
	}

	// Update is called once per frame
	void Update()
	{
		
		if (currentValue < 1)
		{
			timeElapsed += Time.deltaTime;
			//Debug.Log(timeElapsed);
			currentValue = (timeElapsed / timeComplete);
		}
		else
		{
			//setInactive();
			currentValue = 0;
			timeElapsed = 0;
		}

		LoadingBar.fillAmount = currentValue;
	}

	public void setInactive()
    {
		currentValue = 0;
		timeElapsed = 0;
		gameObject.active = false;
		//Debug.Log("unactive");
	}

	public void UpdateTimerState(bool state)
	{
		m_UpdateTimer = state;
	}
}