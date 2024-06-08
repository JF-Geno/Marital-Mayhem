using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SetMap(Sprite map)
    {
        Debug.Log("Selected");
        GameValues.Map = map;
    }

     public void PlayGame()
    {
        if(GameValues.Map  == null)
        {
            return;
        }
        SceneManager.LoadScene(3);
    }
}
