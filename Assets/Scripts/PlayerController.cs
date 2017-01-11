using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
  private Rigidbody rb;
  private int count;

  public float speed;
  public Text countText;
  public Text winText;
  public AudioSource audio;
  public AudioClip coin_audio;
  public AudioClip win_audio;

	void Start() {
		rb = GetComponent<Rigidbody>();
    count = 0;
    SetCountText();
    winText.text = "";
    audio = GetComponent<AudioSource>();
	}

	void FixedUpdate() {
		// CTRL + ' opens documentation while selecting a word
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVeritcal = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVeritcal);

    rb.AddForce(movement * speed);
	}

  void OnTriggerEnter(Collider other){
    if(other.gameObject.CompareTag("Pick Up")){
      other.gameObject.SetActive(false);
      count = count + 1;
      SetCountText();
      audio.PlayOneShot(coin_audio);
      if(count >= 13) {
        winText.text = "You Win!";
        audio.PlayOneShot(win_audio);
      }
    }
  }

  void SetCountText(){
    countText.text = "Count: " + count.ToString();
  }
		
}
