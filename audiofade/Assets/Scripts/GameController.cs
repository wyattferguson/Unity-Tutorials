using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button inButton;
    public Button outButton;
    private AudioSource musicPlayer;

	// Use this for initialization
	void Start () {
        musicPlayer = GetComponent<AudioSource>();
        inButton.onClick.AddListener(DoFadeIn);
        outButton.onClick.AddListener(DoFadeOut);
    }
	
    void DoFadeIn() {
        StartCoroutine(AudioController.FadeIn(musicPlayer, 2f));
    }

    void DoFadeOut() {
        StartCoroutine(AudioController.FadeOut(musicPlayer, 2f));
    }

}
