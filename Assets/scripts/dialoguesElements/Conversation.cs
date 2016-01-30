using UnityEngine;
using System.Collections;

[System.Serializable]
public class Conversation : object {


    public Replica[] replicas;
	[HideInInspector]
	public Group group;
	private int currentReplica = -1;

	public void Stop(){
		replicas [currentReplica].Stop ();
	}

	public void Play(){
		currentReplica = 0;
		replicas [currentReplica].Play (this);
	}

	public void SetAlpha(float alpha){

	}

	public void ReplicaFinished (){
		currentReplica++;
		if (currentReplica >= replicas.Length) {
			group.ConversationFinished ();
		} else {
			replicas [currentReplica].Play (this);
		}
	}
}
