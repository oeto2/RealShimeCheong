using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
	Dictionary<int, string[]> DialogData;

	void Awake()
	{
		DialogData = new Dictionary<int, string[]>();
		GenerateData();
	}

	void GenerateData()
	{
		DialogData.Add(1000, new string[] { "?�̰��� �׽�Ʈ��?","�׷� �׽�Ʈ�� �׽�Ʈ�� �׽�Ʈ�� �׽�Ʈ��"});
	}

	public string GetTalk(int id, int idx_Dialog)
	{
		return DialogData[id][idx_Dialog];
	}
}
