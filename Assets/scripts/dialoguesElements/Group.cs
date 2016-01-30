using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Group : MonoBehaviour {

	public const int CONVERSATION_NB = 3;

	private GroupSpot chosenSpot;
	private Conversation[] conversations;

	public void Init(GroupeParam param){
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
		}
		//Instantiate PNJ
	}

	private Conversation AddRdmConversation(ref List<Conversation> pool){
		int rdm = Random.Range (0, pool.Count);
		Conversation c = pool [rdm]; 
		pool.RemoveAt (rdm);
		return c;
	}
}
