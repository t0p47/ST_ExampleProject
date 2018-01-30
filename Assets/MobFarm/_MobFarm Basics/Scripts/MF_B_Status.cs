using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MF_B_Status : MF_AbstractStatus {

    public bool isCameraFollowMe = false;
    [Tooltip("UI text healt")]
    public Text healthText;
    GameObject arena;
    ShipsCounter shipsCounter;
    Camera mainCam;
	[Tooltip("Object to create upon destruction.")]
	public GameObject blastObject;
	[Tooltip("Radius of the blast object. 0 = Use object's default size.")]
	public float fxRadius; // 0 = don't change size

	public override float health {
		get { return _health; }
		set { _health = value;
            if (isCameraFollowMe) {
                if (healthText==null) {
                    healthText = GameObject.Find("HealthText").GetComponent<Text>();
                }
                healthText.text = "Health:" + maxHealth + "/" + _health;
            }
			if ( _health <= 0 ) {
                shipsCounter = (GameObject.FindGameObjectWithTag("Arena")).GetComponent<ShipsCounter>();
                //shipsCounter.removeShip(this.gameObject);
                if (isCameraFollowMe) {
                    mainCam = Camera.main;
                    mainCam.GetComponent<CameraController>().changeShip();
                }
				Destroy(gameObject);
				if (blastObject) {
					GameObject blastObj = (GameObject)Instantiate( blastObject, transform.position, Quaternion.identity );
					if ( fxRadius != 0 ) {
						blastObj.transform.localScale = new Vector3( fxRadius*2, fxRadius*2, fxRadius*2 );
					}
				}
			}
		}
	}

    public void shieldDamage() {

    }
}
