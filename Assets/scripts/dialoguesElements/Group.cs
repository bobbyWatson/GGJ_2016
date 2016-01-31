using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Group : MonoBehaviour {

	public const int CONVERSATION_NB = 3;
	public const float FULL_DIALOGUE_RADIUS = 100;
	public const float TWEEN_DIALOGUE_RADIUS = 600;
	public Pnj[] pnjs;

	private Transform player;
	private GroupSpot chosenSpot;
	private Conversation[] conversations;
	private Conversation currentConversation;
	private int lastConversation = -1;

	public void Init(GroupeParam param){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		chosenSpot =  PreparationManager.Instance.spots[param.groupSpots [PreparationManager.Instance.chosenLD]];
		transform.position = chosenSpot.transform.position;
		//conversation
		conversations = new Conversation[CONVERSATION_NB];
		List<Conversation> conversationPool = new List<Conversation> ();
		foreach (Conversation c in param.conversations) {
			conversationPool.Add (c);
		}
		for (int i = 0; i < conversations.Length; i++) {
			conversations [i] = AddRdmConversation (ref conversationPool);
			conversations [i].group = this;
		}
		//Instantiate PNJ
		pnjs = new Pnj[param.pnj.Length];
		for(int i = 0; i < param.pnj.Length; i++){
			GameObject o = Instantiate (PreparationManager.Instance.pnjPrefab) as GameObject;
			Pnj pnj = o.GetComponent<Pnj> ();
			pnjs [i] = pnj;
			pnj.transform.SetParent (transform, true);
			pnj.transform.position = chosenSpot.CharactersSpots [i].position;
			Vector3 dir = transform.position - pnj.transform.position;
			if (dir.x > 0) {
				if (dir.y > 0)
					pnj.GetComponent<SpriteRenderer> ().sprite = PreparationManager.Instance.rightTopPnj;
				else
					pnj.GetComponent<SpriteRenderer> ().sprite = PreparationManager.Instance.rightBotPnj;
			} else {
				if (dir.y > 0)
					pnj.GetComponent<SpriteRenderer> ().sprite = PreparationManager.Instance.leftTopPnj;
				else
					pnj.GetComponent<SpriteRenderer> ().sprite = PreparationManager.Instance.leftBotPnj;
			}

		}
		SpriteManager.Instance.GetGoodSprites ();
	}

	private Conversation AddRdmConversation(ref List<Conversation> pool){
		int rdm = Random.Range (0, pool.Count);
		Conversation c = pool [rdm]; 
		pool.RemoveAt (rdm);
		return c;
	}

	void Update(){
		float dist = Vector2.Distance (player.position, transform.position);
		if (dist < TWEEN_DIALOGUE_RADIUS) {
			if (currentConversation == null) {
				ChooseCoversation ();
				currentConversation.Play ();
			}
			//tween value
			float tweenValue;
			if (dist > FULL_DIALOGUE_RADIUS) {
				tweenValue = TweenConversation (dist);				
			} else {
				tweenValue = 0.9f;
			}
			currentConversation.SetAlpha (tweenValue);
		} else {
			if (currentConversation != null) {
				currentConversation.Stop ();
				currentConversation = null;
			}
		}
	}

	float TweenConversation(float dist){
		return Mathf.Lerp(0.9f,0f, ((dist - FULL_DIALOGUE_RADIUS) / (TWEEN_DIALOGUE_RADIUS - FULL_DIALOGUE_RADIUS)));
	}

	void ChooseCoversation(){
		int convNb = -1;
		do{
			convNb = Random.Range(0, conversations.Length);
		}while(convNb == lastConversation);
		currentConversation = conversations [convNb];
		lastConversation = convNb;
	}

	public void ConversationFinished(){
		ChooseCoversation ();
		currentConversation.Play ();
	}

}
