using UnityEngine;
using System.Collections;

public class CausticsRenderer : MonoBehaviour {

	public float fps = 30.0f;
	private Texture2D[] texts;

	private int frame;
	private Projector projector;

	void Start()
	{
		texts = new Texture2D[201];
		projector = GetComponent<Projector> ();

		for (int i = 0; i < texts.Length; i++) 
		{

			string fileName;

			if(i < 10)
			{
				fileName = "Caustics/B&W_Water_0000" + i.ToString();
			}
			else if (i < 100)
			{
				fileName = "Caustics/B&W_Water_000" + i.ToString();
			}
			else
			{
				fileName = "Caustics/B&W_Water_00" + i.ToString();
			}


			texts[i] = (Texture2D)Resources.Load(fileName);
		}

		//Object[] textures = Resources.LoadAll("Caustics");
		//Object texture = Resources.Load("Caustics/B&W_Water_00000");
		//Debug.Log (texture.name);


		NextFrame ();
		InvokeRepeating ("NextFrame", 1 / fps, 1 / fps);
	}

	void NextFrame()
	{
		projector.material.SetTexture ("_ShadowTex", texts[frame]);
		frame = (frame + 1) % texts.Length;

	}
}
