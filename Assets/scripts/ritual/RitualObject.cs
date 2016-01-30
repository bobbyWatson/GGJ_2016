using UnityEngine;
using System.Collections;

abstract public class RitualObject : MonoBehaviour {

	public abstract string objectName();

	public abstract void UpAction(); // action when player has object and presses UpAction (depends on position) 
	public abstract string UpActionInfo(); // tells what the action will do, but does nothing

	public abstract void DownAction();
	public abstract string DownActionInfo();

	public abstract void LeftAction();
	public abstract string LeftActionInfo();

	public abstract void RightAction();
	public abstract string RightActionInfo();

}
