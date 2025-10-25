using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene : MonoBehaviour
{
    public string HomeScreen;
    // Start is called before the first frame update
    public void LoadLevel() {
  SceneManager.LoadScene (HomeScreen);
}
}