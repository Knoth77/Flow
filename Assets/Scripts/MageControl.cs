using UnityEngine;
using System.Collections;

public class MageControl : MonoBehaviour 
{

	public float smooth = 1.0f;



	private GameObject armature;
	private GameObject body;
	private GameObject robe;
	private GameObject effect;
	private GameObject lightObj;
	private Light light;
	private ParticleEmitter emit;

	private bool mageActive = false;
	private bool doneGrowing = false;
	private bool doneShrinking = true;
	private bool doParticleAnimation = true;

	void Start()
	{
		armature = transform.Find ("Armature").gameObject;
		body = transform.Find("Body").gameObject;
		robe = transform.Find("Robe").gameObject;
		effect = transform.Find ("MistEffect").gameObject;
		lightObj = transform.Find ("MageLight").gameObject;
		light = lightObj.GetComponent<Light> ();
		emit = effect.GetComponent<ParticleEmitter> ();
	}

	void Update()
	{

		if (mageActive && doParticleAnimation) 
		{
			emitterGrow();

			if(doneGrowing)
			{
				mageAppear();
				emitterShrink();
			}

		}
		else if(!mageActive)
		{  
			emitterGrow();
			
			if(doneGrowing)
			{
				mageVanish();
				emitterShrink();
			}
		}



	}

	public void setMageToAppear()
	{
		mageActive = true;
		doneGrowing = false;
		doParticleAnimation = true;
		effectAppear ();
	}

	public void setMageToDissapear()
	{
		mageActive = false;
		effectAppear ();
	}

	void mageAppear()
	{
		armature.SetActive (true);
		body.SetActive (true);
		robe.SetActive (true);
	}

	void mageVanish()
	{
		armature.SetActive (false);
		body.SetActive (false);
		robe.SetActive (false);
	}

	void effectAppear()
	{
		effect.SetActive (true);
	}

	void effectVanish()
	{
		effect.SetActive (false);
	}

	void emitterGrow()
	{

		if (doneGrowing)
						return;

		emit.minSize = Mathf.Lerp (emit.minSize, 4, smooth * Time.deltaTime);
		emit.maxSize = Mathf.Lerp (emit.maxSize, 4, smooth * Time.deltaTime);

		emit.minEnergy = Mathf.Lerp (emit.minEnergy, 2, smooth * Time.deltaTime);
		emit.maxEnergy = Mathf.Lerp (emit.maxEnergy, 2, smooth * Time.deltaTime);

		light.intensity = Mathf.Lerp (light.intensity, 8, (smooth) * Time.deltaTime);

		if (4 - emit.minSize <= .0001) 
		{
			doneGrowing = true;
			doneShrinking = false;
		}
	}

	void emitterShrink()
	{
		if (doneShrinking)
						return;

		emit.minSize = Mathf.Lerp (emit.minSize, 0, smooth * Time.deltaTime);
		emit.maxSize = Mathf.Lerp (emit.maxSize, 0, smooth * Time.deltaTime);
		
		emit.minEnergy = Mathf.Lerp (emit.minEnergy, 0, smooth * Time.deltaTime);
		emit.maxEnergy = Mathf.Lerp (emit.maxEnergy, 0, smooth * Time.deltaTime);


		light.intensity = Mathf.Lerp (light.intensity, 0, (smooth) * Time.deltaTime);

		if (4 - emit.minSize >= 3.9999) 
		{
			doneShrinking = true;
			doneGrowing = false;
			doParticleAnimation = false;
			effectVanish();

		}
	}


}
