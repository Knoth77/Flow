using UnityEngine;
using System.Collections;

public class RiseWater : MonoBehaviour {

	public GameObject waterObj;
	public GameObject underWaterObj;
	private bool waterRising = false;

	private float waterLevel = 148.0f;
	private float underWaterLevel = 147.0f;
	public float riseRate = 0.0f;

	Vector3 newWaterPos;
	Vector3 newUnderWaterPos;
	

	// Use this for initialization
	void Start ()
	{

		//startWaterRising ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waterRising)
		{
			waterRise();
		}
	}

	void waterRise()
	{
		newWaterPos = new Vector3 (waterObj.transform.position.x, waterObj.transform.position.y + riseRate, waterObj.transform.position.z);
		newUnderWaterPos = new Vector3 (underWaterObj.transform.position.x, underWaterObj.transform.position.y + riseRate, underWaterObj.transform.position.z);



		waterObj.transform.position = newWaterPos;
		underWaterObj.transform.position = newUnderWaterPos;

	;


		if ((waterObj.transform.position.y >= 148) && (underWaterObj.transform.position.y >= 147)) 
		{
			waterRising = false;
		}


	}

	public void startWaterRising()
	{
		waterRising = true;
		waterObj.SetActive (true);
		underWaterObj.SetActive (true);

	}



}
