using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

	public int minLevel = 0;
	public int currentLevel;

	public levelBar levelBar;

    // Start is called before the first frame update
    void Start()
    {
		currentLevel = minLevel;
		levelBar.SetMinLevel(minLevel);
    }
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Addlevel(1);
		}
    }


	void Addlevel(int level)
	{
		currentLevel += level;

		levelBar.SetLevel(currentLevel);
	}
}
