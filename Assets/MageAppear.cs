using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MageAppear : MonoBehaviour {




	public Movement playerScript;
	public MageControl mage;

	public ArrayList displayQueue;
	public MageDialog dialogEntries;

	bool displaying = false;
	float mageCountDown = 8.5f;
	float textCountDown = 0.0f;

	public Text textDisplay;
	public GameObject panel;
	private Animator textAnimator;


	void Start () 
	{
		displayQueue = new ArrayList ();
		textAnimator = textDisplay.GetComponent<Animator> ();
	}
	

	void Update () 
	{
		if (displaying) 
		{
			if(mageCountDown >= 0)
				mageCountDown -= Time.deltaTime;
			else
			{
				panel.SetActive(true);
				if(displayQueue.Count > 0)
				{
					AnimatorStateInfo info = textAnimator.GetCurrentAnimatorStateInfo(0);
					int state1 = Animator.StringToHash("Base.TextHidden");
					int state2 = Animator.StringToHash("Base.TextVisible");


					if(textCountDown <= 0 && info.nameHash == state1)
					{
					MageDialog.textDisplay next = popQueueText();
					textDisplay.text = next.displayText;
					textCountDown = next.displayTime;
					textAnimator.SetTrigger("showText");
					}


					if(info.nameHash == state2)
					{
					textCountDown -= Time.deltaTime;

						if(textCountDown <= 0)
							textAnimator.SetTrigger("hideText");
					}

				}
				else
				{ 

					textCountDown -= Time.deltaTime;
					
					if(textCountDown <= 0)
					{
						textAnimator.SetTrigger("hideText");
					}
					else
						return;

					AnimatorStateInfo info = textAnimator.GetCurrentAnimatorStateInfo(0);

					int state1 = Animator.StringToHash("Base.TextHidden");
					int state2 = Animator.StringToHash("Base.TextVisible");


					if(info.nameHash == state1)
					{
						displaying = false;
						mage.setMageToDissapear();
						playerScript.movementDisabled = false;
						gameObject.SetActive(false);
						panel.SetActive(false);
					}
				}

			}
		}
		else
		{   
			mageCountDown = 8.5f;
		}
	}

	MageDialog.textDisplay popQueueText()
	{
		MageDialog.textDisplay pop = (MageDialog.textDisplay)displayQueue [0];
		displayQueue.RemoveAt(0);
		return pop;
	}

	void queueText(MageDialog.textDisplay[] tlist)
	{
		foreach (MageDialog.textDisplay t in tlist) 
		{
			displayQueue.Add (t);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			displaying = true;
			playerScript.movementDisabled = true;
			mage.setMageToAppear();

			if(gameObject.tag == "MageIntro")
			{

				MageDialog.textDisplay[] introText = dialogEntries.getIntroDialog();


				queueText(introText);
			}
		}
	}
}
