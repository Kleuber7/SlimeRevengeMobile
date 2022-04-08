using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start ()
	{
		Lives = startLives;

		Rounds = 0;
	}

}
