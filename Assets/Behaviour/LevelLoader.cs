using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	public string SceneName;

	public void load(){
		SceneManager.LoadScene (SceneName);
	}
}
