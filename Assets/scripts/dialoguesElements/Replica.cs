using UnityEngine;
using System.Collections;

[System.Serializable]
public class Replica : object {
    public int character;
    public string text;

	[System.NonSerialized]
	private Conversation conv;

	public void Play(Conversation conversation){
		conv = conversation; 
		conv.group.pnjs [character].StartReplica (this);
	}

	public void Stop(){
		conv.group.pnjs [character].StopReplica ();
	}

	public void Finished (){
		conv.ReplicaFinished ();
	}
}
