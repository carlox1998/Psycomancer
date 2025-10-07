using UnityEngine;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{

    public Image Background;
    public Color characterAura;
    public float velocity= 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Modify with character name for each case
    public void ScreenAura(){
        characterAura = GameObject.FindWithTag("Victor").GetComponent<Character>().characterAura;
        Background.color = Color.Lerp(Background.color, characterAura,Time.deltaTime* velocity);
    }
}
