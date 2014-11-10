using UnityEngine;
using System.Collections;

public class UnderwaterScript : MonoBehaviour {
	
	bool underWater;

	public GameObject waterObj;
	public GameObject underWaterObj;
	public GameObject player;

	private Vector3 regularGrav = new Vector3(0.0f,-9.81f,0.0f);
	private Vector3 waterGrav = new Vector3(0.0f,-2.0f,0.0f);

	public GameObject projectors;

	// Use this for initialization
	void Start () 
	{
		underWater = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (underWaterObj.activeInHierarchy) 
		{
			if(player.rigidbody.position.y < underWaterObj.transform.position.y)
			{
				underWater = true;
				RenderSettings.fog = true;
				Physics.gravity = waterGrav;
				projectors.SetActive(true);
			}
			else
			{
				underWater = false;
				RenderSettings.fog = false;
				Physics.gravity = regularGrav;
				projectors.SetActive(false);
			}
		}

	}

	public bool isUnderWater()
	{
		return underWater;
	}
}
