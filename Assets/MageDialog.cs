using UnityEngine;
using System.Collections;

public class MageDialog : MonoBehaviour {

	public struct textDisplay
	{
		public string displayText;
		public float displayTime;
	}


	public textDisplay[] introDialog;


	void Start () 
	{
		introDialog = new textDisplay[4];

		introDialog [0].displayText = "Water Sage: I havent seen one of your kind in a long time.  This temple was built long ago to teach \n those worthy how to master the element of water, and my job now is to teach you.";
		introDialog [0].displayTime = 5.5f;

		introDialog [1].displayText = "Water Sage: Water is the element of change and adaptation.  For you to succeed you must be \n like the water in the temple, \n always adapting to your situation.";
		introDialog [1].displayTime = 4.5f;

		introDialog [2].displayText = "Water Sage: I will grant you your first ability to use.  It enables you to release a jet of water in the \n direction your facing.  \n It can be used to move objects but it also can activate special objects around the temple.";
		introDialog [2].displayTime = 4.5f;

		introDialog [3].displayText = "Now you are ready to continue, we will meet again.  And remeber the path to mastery \n is not always straight forward";
		introDialog [3].displayTime = 3.5f;
	}

	public textDisplay[] getIntroDialog()
	{
		return introDialog;
	}
	

}
