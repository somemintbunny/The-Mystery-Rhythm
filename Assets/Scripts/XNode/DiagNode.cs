using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class DiagNode : BaseNode {

	// Use this for initialization
	[Input] public int entry;
	[Output] public int exit;
	public string SpeakerName;
	public string DialogueLine;
	public Sprite sprite;

	public override string GetString()
	{
		return "DialogueNode/" + SpeakerName + "/" + DialogueLine;
	}

	public override Sprite GetSprite()
	{
		return sprite;
	}
}