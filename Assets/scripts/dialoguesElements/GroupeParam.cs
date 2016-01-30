using UnityEngine;
using System.Collections;

[System.Serializable]
[CreateAssetMenu(fileName = "newGroup", menuName = "Group Config", order = 0)]
public class GroupeParam : ScriptableObject {

    [SerializeField]
    public Conversation[] conversations;
	
}
