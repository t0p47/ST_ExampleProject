using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    [SerializeField]
    Text healthText;
    [SerializeField]
    Text cameraModeText;
    [SerializeField]
    GameObject viewButtonsUI;
    [SerializeField]
    GameObject shipStatusUI;
    ShipCameras shipCameras;
    ShipsCounter shipsCounter;
    FlyCam flyCam;
    bool isCamFree = true;
    private GameObject ship;
    List<GameObject> shipsList; 

	// Use this for initialization
	void Start () {
        flyCam = GetComponent<FlyCam>();
        shipsCounter = GameObject.FindGameObjectWithTag("Arena").GetComponent<ShipsCounter>();
	}

    // Update is called once per frame
    void Update() {
        //Fly cam
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            transform.parent = null;
            flyCam.enabled = true;
            isCamFree = true;
            cameraModeText.text ="Camera mode: Free fly cam";
            if (ship != null)
            {
                ship.GetComponent<MF_B_Status>().isCameraFollowMe = false;
            }
            ship = null;
            viewButtonsUI.SetActive(false);
            shipStatusUI.SetActive(false);
        }
        //Ship follow cam
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            viewButtonsUI.SetActive(true);
            flyCam.enabled = false;
            isCamFree = false;
            cameraModeText.text = "Camera mode: Ship follow cam";
            changeShip();
            shipStatusUI.SetActive(true);
        }
        if (!isCamFree) {
            if (Input.GetKeyDown(KeyCode.C))
            {
                changeShip();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                changeTeam();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                setFrontView();
            }
        }
	}

    public void changeShip() {
        if (ship != null) {
            ship.GetComponent<MF_B_Status>().isCameraFollowMe = false;
        }
        shipsList = new List<GameObject>();
        //shipsList = shipsCounter.getShipsList();
        ship = shipsList[Random.Range(0, shipsList.Count)];
        ship.GetComponent<MF_B_Status>().isCameraFollowMe = true;
        setFrontView();
        healthText.text = "Health: " + ship.GetComponent<MF_B_Status>().maxHealth + "/" + ship.GetComponent<MF_B_Status>().health;
    }

    void changeTeam() { }

    public void setFrontView() {
        shipCameras = ship.GetComponent<ShipCameras>();
        transform.SetParent(shipCameras.frontView);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void setSideView() {
        shipCameras = ship.GetComponent<ShipCameras>();
        transform.SetParent(shipCameras.sideView);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void setBackView() {
        shipCameras = ship.GetComponent<ShipCameras>();
        transform.SetParent(shipCameras.backView);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
