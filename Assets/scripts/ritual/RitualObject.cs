using UnityEngine;
using System.Collections;

abstract public class RitualObject : MonoBehaviour {

	public abstract string objectName();

	// this is what happens when player has object and presses action button
	// will depend on position
	public abstract void UpAction();
	public abstract void DownAction();
	public abstract void LeftAction();
	public abstract void RightAction();





}
