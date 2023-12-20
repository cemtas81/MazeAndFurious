using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using MoreMountains.NiceVibrations;
using System.Threading;


public class swipteInput : MonoBehaviour
{
	private int zaman;
	Animator animator;
	public GameObject charAnimFire;

	public Transform kayroRotate;
	public Transform kup;
	public Transform kup_newPos;


	public LineRenderer lineRenderer;
	private Vector3 go;

	public LineRenderer linePrefab;
	public LineRenderer l;

	// If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
	public const float MAX_SWIPE_TIME = 0.5f;

	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public const float MIN_SWIPE_DISTANCE = 0.017f;

	public static bool swipedRight = false;
	public static bool swipedLeft = false;
	public static bool swipedUp = false;
	public static bool swipedDown = false;

	private bool callOneTime = false;
	private bool callOneTimeMusic = false;
	private bool callShowad = false;
	private bool callComplete = false;
	private bool callFail = false;



	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;

	//HashSet<Vector3> boyali = new HashSet<Vector3>();
	//Vector3 baslangicPos;

	HashSet<Tuple<int, int>> visitedNodes;

	public static int score0 = 1;
	public static int score1 = 0;
	public static int toplamScore = 1;
	public static int scoreConverter = 0;
	public static int newScore = 0;
	public static int levelEnd = 0;
	public int levelScore;
	public int kupX;
	public int kupZ;

	private int totalGem;
	private int levelGem;

	public static int level;

	public Text totalGemText;
	public Text scoreText;//sure
	public Text sureShadowText;
	public Text levelShadowText;
	public Text sureText;
	public Text levelText;//levelIndex
	public Text realScoreEND;//endlevel popup levelscore
	public Text realScorePAUSE;//pause popup levelScore
	public Text levelGemText;
	public Text allGemText;
	public Text keyCountText;
	public Text charNameText;

	public static int ifcase;

	public GameObject confetti;

	public GameObject pausePU;

	public static float sure = 59;

	public GameObject starPanel;

	public GameObject nextButtonReal;

	public GameObject shieldButton;

	public GameObject pause;

	public GameObject play;

	public Button kayroSelect;
	public Sprite spr1;
	public Sprite spr2;
	public Sprite spr3;
	public Sprite spr4;
	public Sprite spr5;

	Scene scene;

	public bool timeBool = true;
	private bool controlBool = true;

	private int zeminCounter;
	private int duvarCounter;

	public string path;
	public int toplam = 0;

	public static int tuzakX;
	public static int tuzakZ;

	public static int slowerZ;
	public static int slowerZ_2;

	public static int slowerX;
	public static int slowerX_2;

	public static int slower;

	public float tuzakRot;
	//public GameObject kazikTuzak;

	public static int tuzakDirection;
	public static int goWay;

	public static float hitDistance;

	public Renderer rend;

	public Text userName;

	private int levelSave;
	private int levelNumber;

	public ParticleSystem konfetti;
	public ParticleSystem konfetti2;
	public ParticleSystem konfetti3;
	public ParticleSystem konfetti4;

	public GameObject soundd;

	public GameObject removeAd;

	public static int adMob;
	public int i;

	public GameObject adRemover;

	public GameObject blackPanel;

	public GameObject bar;
	private Image barsure;
	private float maxTime = 60f;

	private HealthBarCut barcut;
	private animationScript animScript;
	private yourClass MusicObj;
	private GAinitialize gaint;
	private AdMobIntestitial admobIntes;

	private AudioSource victorySource;
	public AudioClip victoryClip;

	private int keyCount;
	public GameObject chestRoomButton;
	public GameObject adRemoveGo;
	public GameObject failSound;

	public GameObject coronaMaske;
	public GameObject yilbasiSapka;
	public GameObject askerimigfer;
	public GameObject sapka;
	public GameObject dikenlimigfer;
	public GameObject maske;
	public GameObject spartamaske;
	public GameObject kulaklik;
	public GameObject gozluk;
	public GameObject roket;
	public GameObject kaykay;

	public GameObject coronaMaskeEnd;
	public GameObject yilbasiSapkaEnd;
	public GameObject askerimigferEnd;
	public GameObject sapkaEnd;
	public GameObject dikenlimigferEnd;
	public GameObject maskeEnd;
	public GameObject spartamaskeEnd;
	public GameObject kulaklikEnd;
	public GameObject gozlukEnd;
	public GameObject roketEnd;

	public GameObject coronaMaskeF;
	public GameObject yilbasiSapkaF;
	public GameObject askerimigferF;
	public GameObject sapkaF;
	public GameObject dikenlimigferF;
	public GameObject maskeF;
	public GameObject spartamaskeF;
	public GameObject kulaklikF;
	public GameObject gozlukF;
	public GameObject roketF;

	public GameObject coronaMaskeF2;
	public GameObject yilbasiSapkaF2;
	public GameObject askerimigferF2;
	public GameObject sapkaF2;
	public GameObject dikenlimigferF2;
	public GameObject maskeF2;
	public GameObject spartamaskeF2;
	public GameObject kulaklikF2;
	public GameObject gozlukF2;
	public GameObject roketF2;

	public GameObject coronaMaskeP;
	public GameObject yilbasiSapkaP;
	public GameObject askerimigferP;
	public GameObject sapkaP;
	public GameObject dikenlimigferP;
	public GameObject maskeP;
	public GameObject spartamaskeP;
	public GameObject kulaklikP;
	public GameObject gozlukP;
	public GameObject roketP;

	public GameObject coronaMaskeC;
	public GameObject yilbasiSapkaC;
	public GameObject askerimigferC;
	public GameObject sapkaC;
	public GameObject dikenlimigferC;
	public GameObject maskeC;
	public GameObject spartamaskeC;
	public GameObject kulaklikC;
	public GameObject gozlukC;
	public GameObject roketC;
	public GameObject kaykayC;


	public Text timeFallDownText;
	public GameObject timeFallDownGO;

	public GameObject failAnimOBJ;
	private float failanimsure;

	private Vector3 textpos;
	private float screenWidth;
	private float screenHeight;
	private float screenSize;
	private int skin;
	private int equipment;

	//public GameObject animOBJ;
	//public GameObject animOBJ2;
	public GameObject animFail1;
	public GameObject animFail2;
	public GameObject animPause;
	public GameObject animNext;

	public GameObject fail1Skin;
	public GameObject fail2Skin;
	public GameObject pauseSkin;
	public GameObject nextSkin;
	public GameObject oyunicSkin;
	public GameObject karakterChangeSkin;

	public GameObject fail1eyeR;
	public GameObject fail1eyeL;

	public GameObject fail2eyeR;
	public GameObject fail2eyeL;

	public GameObject pauseeyeR;
	public GameObject pauseeyeL;

	public GameObject nexteyeR;
	public GameObject nexteyeL;

	public GameObject oyunicieyeR;
	public GameObject oyunicieyeL;

	public GameObject karakterChangeeyeR;
	public GameObject karakterChangeeyeL;


	public GameObject purchaseCanvas;
	public GameObject rateusCanvas;

	public GameObject particle;
	public GameObject particleFail;
	public GameObject particleFail2;
	public GameObject nextParticle;

	public void Awake()
	{
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		screenSize = (((screenHeight / screenWidth) * 180)) / 1.66f;
		Debug.Log("w:" + screenWidth + "+" + "h:" + screenHeight + "+" + "size:" + screenSize);

		barcut = GameObject.Find("HealthBarCut").GetComponent<HealthBarCut>();
		animScript = GameObject.Find("LevelObject").GetComponent<animationScript>();
		MusicObj = GameObject.Find("MusicObject").GetComponent<yourClass>();
		gaint = GameObject.Find("GameAnalytics").GetComponent<GAinitialize>();

		if (PlayerPrefs.GetInt("removeAd") == 1)
		{
			adRemoveGo.SetActive(false);
			adRemoveGo.GetComponent<AdMobBanner>().enabled = false;
			adRemoveGo.GetComponent<AdMobIntestitial>().enabled = false;
		}

		particle.GetComponent<ParticleSystem>().Stop();

		skinController();
	}
	public void Start()
	{

		skin = PlayerPrefs.GetInt("skin");
		KayroSelect();
		victorySource = GameObject.Find("kazanma").GetComponent<AudioSource>();

		//anahtar alınmışsa anahtarı göster.
		if (keyCountText != null)
			keyCountText.text = PlayerPrefs.GetInt("key").ToString();

		//adremove satın alınmışsa AdMobları kaldırır.
		if (PlayerPrefs.GetInt("removeAd") == 1)
		{
			adRemover.SetActive(false);
		}
		else
			admobIntes = GameObject.Find("AdMobRemove").GetComponent<AdMobIntestitial>();

		barsure = bar.GetComponent<Image>();

		animator = GetComponent<Animator>();
		//blackPanel.SetActive(false);
		//PlayerPrefs.DeleteAll();



		totalGem = PlayerPrefs.GetInt("totalGem");
		if (totalGem >= 10000)
		{
			if (totalGemText != null)
				totalGemText.text = Mathf.RoundToInt(totalGem / 1000).ToString() + "K";
		}
		else
		{
			if (totalGemText != null)
				totalGemText.text = totalGem.ToString();
		}

		//update içinde bir defa çağırılıcak fonk. için boollar.
		callOneTime = false;
		callOneTimeMusic = false;
		callShowad = false;
		callComplete = false;
		callFail = false;

		sure = 60;
		pause.SetActive(true);
		//play.SetActive(true);
		//shieldButton.SetActive(true);

		if (userName != null)
			userName.text = PlayerPrefs.GetString("playerName").ToUpper();

		scene = SceneManager.GetActiveScene();
		levelNumber = scene.buildIndex - 2;
		levelSave = PlayerPrefs.GetInt("lastLevel");

		/*if (rateUS.star == 0 && PlayerPrefs.GetInt("rateus") == 0)
		{
			if ((levelSave + 1) == 5 || (levelSave + 1) == 9 || (levelSave + 1) == 15 ||
				(levelSave + 1) == 20 || (levelSave + 1) == 30 || (levelSave + 1) == 40 ||
				(levelSave + 1) == 50)
			{
				Time.timeScale = 0;
				rateusCanvas.SetActive(true);
			}
		}
		else
			rateusCanvas.SetActive(false);*/

		if (PlayerPrefs.GetInt("ekstra") == 1)
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 3002).ToString();

			if (levelSave + 3002 >= 7002)
			{
				PlayerPrefs.SetInt("ekstra", 2);
			}
		}

		else if (PlayerPrefs.GetInt("ekstra") == 2)
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 6003).ToString();

			if (levelSave + 6003 >= 10003)
			{
				PlayerPrefs.SetInt("ekstra", 3);
			}
		}

		else if (PlayerPrefs.GetInt("ekstra") == 3)
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 9004).ToString();

			if (levelSave + 9004 >= 13004)
			{
				PlayerPrefs.SetInt("ekstra", 4);
			}
		}

		else if (PlayerPrefs.GetInt("ekstra") == 4)
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 12005).ToString();

			if (levelSave + 12005 >= 16005)
			{
				PlayerPrefs.SetInt("ekstra", 5);
			}
		}

		else if (PlayerPrefs.GetInt("ekstra") == 5)
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 15006).ToString();

			if (levelSave + 15006 >= 19006)
			{
				PlayerPrefs.SetInt("ekstra", 6);
			}
		}

		else if (PlayerPrefs.GetInt("ekstra") == 6)
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 18007).ToString();
		}

		else
		{
			if (levelText != null)
				levelText.text = "LEVEL " + "\n" + (levelSave + 1).ToString();
		}

		if (levelShadowText != null)
			levelShadowText.text = "LEVEL " + (levelSave + 1).ToString();

		path = Application.dataPath + "/StreamingAssets/levelScores.json";


		score0 = 1;
		score1 = 0;

		zeminCounter = GameObject.FindGameObjectsWithTag("zemin").Length;/* + GameObject.FindGameObjectsWithTag("tuzak").Length
		+GameObject.FindGameObjectsWithTag("slow").Length + GameObject.FindGameObjectsWithTag("slower").Length + GameObject.FindGameObjectsWithTag("slow2").Length;*/

		duvarCounter = GameObject.FindGameObjectsWithTag("duvar").Length;

		Debug.Log("zeminCounter = " + zeminCounter);

		/*slowerZ = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("slow").transform.position.z);
		slowerZ_2 = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("slow2").transform.position.z);

		//Debug.Log("slower2 X: " + slowerX + "+" + "slower1 Z:" + "+" + slowerZ);

		tuzakX = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("tuzak").transform.position.x);
		tuzakZ = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("tuzak").transform.position.z);


		slower = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("slower").transform.position.z);

		Debug.Log(tuzakX + "+" + tuzakZ);*/

		visitedNodes = new HashSet<Tuple<int, int>>();

		DOTween.Init();
		visitedNodes.Add(new Tuple<int, int>(Mathf.RoundToInt(kup.position.x), Mathf.RoundToInt(kup.position.z)));

	}

	public void Update()
	{
		failanimsure += Time.deltaTime;
		if ((PlayerPrefs.GetInt("lastLevel") + 1) % 10 == 0 && failanimsure >= 5f && failanimsure <= 5.2f)
		{
			failAnimOBJ.SetActive(true);

		}

		//anahtar alınmışsa anahtarı göster.
		if (keyCountText != null)
			keyCountText.text = PlayerPrefs.GetInt("key").ToString();

		//removeAd alındığı anda AdMobları kaldırır.
		if (PlayerPrefs.GetInt("removeAd") == 1)
		{
			adRemover.SetActive(false);
			adRemoveGo.SetActive(false);
		}

		if (sure <= 60)
			barsure.fillAmount -= 1 / maxTime * Time.deltaTime;
		else
			barsure.fillAmount = 1.0f;

		keyCount = PlayerPrefs.GetInt("key");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("New Scene");
			level = levelSave + 1;
			PlayerPrefs.SetInt("lastLevel", level);
		}

		//zamanı azaltır.
		if (timeBool == true)
			sure -= Time.deltaTime;
		scoreConverter = Mathf.RoundToInt(sure);

		float minutes = Mathf.Floor(sure / 60);
		float seconds = (sure % 60);

		if (sureText != null)
			sureText.text = sure.ToString("0");

		kup_newPos.position = kup.position;
		RaycastHit hit;
		kupX = Mathf.RoundToInt(kup_newPos.position.x);
		kupZ = Mathf.RoundToInt(kup_newPos.position.z);

		swipedRight = false;
		swipedLeft = false;
		swipedUp = false;
		swipedDown = false;

		//dokunmatik
		if (controlBool == true)
		{
			if (Input.touches.Length > 0)
			{
				Touch t = Input.GetTouch(0);
				if (t.phase == TouchPhase.Began)
				{
					startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
					startTime = Time.time;
				}
				if (t.phase == TouchPhase.Ended)
				{
					if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
						return;

					Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

					Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

					if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
						return;
					if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
					{ // Horizontal swipe
						if (swipe.x > 0)
						{
							swipedRight = true;


							if (Physics.Raycast(kup_newPos.position, transform.right, out hit, 25))
							{
								kayroRotate.DOLocalRotate(new Vector3(-90, 90, 0), 0);

								var gitSag = hit.distance + 0.5f;

								hitDistance = hit.distance;

								int puan = (int)(hit.distance - 0.5f);

								Debug.DrawRay(kup.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);

								if (hit.rigidbody != null && hit.distance > 0.5f)
								{
									controlBool = false;
									Vector3 go = new Vector3(gitSag - 0.5f, 0, 0);
									Vector3 go2 = new Vector3(gitSag + kup_newPos.position.x, 0, 0);
									int forcounter = Mathf.RoundToInt(go2.x - 1);
									goWay = Mathf.RoundToInt(go2.x - 1);


									tuzakDirection = 1;

									if (hit.distance <= 4)
									{
										kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0f);
										//kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}
									if (hit.distance >= 4.1f && hit.distance <= 6)
									{
										kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0.1f);
										//kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}
									if (hit.distance >= 6.1f)
									{
										kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("moveDikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0.125f);
										//kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}

									saydir(forcounter, kupX, puan);

									ifcase = 1;
								}

								else
								{
									return;
								}
							}
							print("sag");


						}
						else
						{
							swipedLeft = true;


							if (Physics.Raycast(kup_newPos.position, -transform.right, out hit, 25))
							{
								kayroRotate.DOLocalRotate(new Vector3(-90, -90, 0), 0);

								var gitSol = hit.distance - 0.5f;

								hitDistance = hit.distance;

								int puan = Mathf.RoundToInt(hit.distance - 0.5f);

								Debug.DrawRay(kup.position, transform.TransformDirection(-Vector3.right) * hit.distance, Color.yellow);

								if (hit.rigidbody != null & hit.distance > 0.5f)
								{
									controlBool = false;

									Vector3 go = new Vector3(gitSol + 0.5f, 0, 0);
									Vector3 go2 = new Vector3(-gitSol + kup_newPos.position.x, 0, 0);
									int forcounter = Mathf.RoundToInt(go2.x);
									goWay = Mathf.RoundToInt(go2.x);

									tuzakDirection = 2;

									if (hit.distance <= 4)
									{
										kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveX(goWay, 0.045f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0f);
										//kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}
									if (hit.distance >= 4.1f && hit.distance <= 6)
									{
										kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveX(goWay, 0.145f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0.1f);
										//kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}
									if (hit.distance >= 6.1)
									{
										kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("moveDikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveX(goWay, 0.245f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0.125f);
										//kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}

									saydirSol(forcounter, kupX, puan);

									ifcase = 2;


								}
								else
								{
									return;
								}
							}
							print("sol");
						}
					}


					else
					{ // Vertical swipe
						if (swipe.y > 0)
						{
							swipedUp = true;

							if (Physics.Raycast(kup_newPos.position, transform.forward, out hit, 25))
							{
								kayroRotate.DOLocalRotate(new Vector3(-90, 0, 0), 0);

								var gitYukarı = hit.distance - 0.5f;

								hitDistance = hit.distance;

								int puan = Mathf.RoundToInt(hit.distance - 0.5f);


								Debug.DrawRay(kup.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

								if (hit.rigidbody != null && hit.distance > 0.5f)
								{
									controlBool = false;

									Vector3 go = new Vector3(0, 0, gitYukarı + 0.5f);
									Vector3 go2 = new Vector3(0, 0, gitYukarı + kup_newPos.position.z);
									int forcounter = Mathf.RoundToInt(go2.z);
									goWay = Mathf.RoundToInt(go2.z);


									tuzakDirection = 3;

									if (hit.distance <= 4)
									{
										kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveZ(go2.z, 0.045f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0f);
										//kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}
									if (hit.distance >= 4.1f && hit.distance <= 6)
									{
										kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveZ(go2.z, 0.145f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0.1f);
										//kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}
									if (hit.distance >= 6.1f)
									{
										kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("movee")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										//kup.DOMoveZ(go2.z, 0.245f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
										kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										Invoke("particleWall", 0.125f);
										//kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
									}




									saydirYukari(forcounter, kupZ, puan);

									ifcase = 3;

								}
								else
								{
									return;
								}
							}
							print("yukarı");
						}
						else
						{
							swipedDown = true;


							if (Physics.Raycast(kup_newPos.position, -transform.forward, out hit, 25))
							{
								kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0);

								var gitAsagi = hit.distance - 0.5f;

								hitDistance = hit.distance;

								int puan = Mathf.RoundToInt(hit.distance - 0.5f);


								Debug.DrawRay(kup.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.yellow);

								if (hit.rigidbody != null && hit.distance > 0.5f)
								{

									controlBool = false;

									Vector3 go = new Vector3(0, 0, gitAsagi + 0.5f);
									Vector3 go2 = new Vector3(0, 0, -gitAsagi + kup_newPos.position.z);
									int forcounter = Mathf.RoundToInt(go2.z);
									goWay = Mathf.RoundToInt(go2.z);

									tuzakDirection = 4;

									if (hit.distance <= 4)
									{
										kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										//kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
										Invoke("particleWall", 0f);

									}
									if (hit.distance >= 4.1f && hit.distance <= 6)
									{
										kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										//kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
										Invoke("particleWall", 0.1f);

									}
									if (hit.distance >= 6.1f)
									{
										kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("movee")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
										kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
										//kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
										Invoke("particleWall", 0.125f);
									}


									saydirAsagi(forcounter, kupZ, puan);

									ifcase = 4;
								}
								else
								{
									return;
								}
							}
							print("asagi");
						}
					}
				}
			}
			else if (Input.GetMouseButtonDown(0))
            {
                startPos = new Vector2(Input.mousePosition.x / (float)Screen.width,Input.mousePosition.y / (float)Screen.width);
                startTime = Time.time;

            }
            else if (Input.GetMouseButton(0))
            {
               
                //UpdateCarPosition(Input.mousePosition);
                
            }
            else if (Input.GetMouseButtonUp(0))
            {
                {
                    if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                        return;

                    Vector2 endPos = new Vector2(Input.mousePosition.x / (float)Screen.width, Input.mousePosition.y / (float)Screen.width);

                    Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                    if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                        return;
                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                    { // Horizontal swipe
                        if (swipe.x > 0)
                        {
                            swipedRight = true;


                            if (Physics.Raycast(kup_newPos.position, transform.right, out hit, 25))
                            {
                                kayroRotate.DOLocalRotate(new Vector3(-90, 90, 0), 0);

                                var gitSag = hit.distance + 0.5f;

                                hitDistance = hit.distance;

                                int puan = (int)(hit.distance - 0.5f);

                                Debug.DrawRay(kup.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);

                                if (hit.rigidbody != null && hit.distance > 0.5f)
                                {
                                    controlBool = false;
                                    Vector3 go = new Vector3(gitSag - 0.5f, 0, 0);
                                    Vector3 go2 = new Vector3(gitSag + kup_newPos.position.x, 0, 0);
                                    int forcounter = Mathf.RoundToInt(go2.x - 1);
                                    goWay = Mathf.RoundToInt(go2.x - 1);


                                    tuzakDirection = 1;

                                    if (hit.distance <= 4)
                                    {
                                        kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0f);
                                        //kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }
                                    if (hit.distance >= 4.1f && hit.distance <= 6)
                                    {
                                        kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0.1f);
                                        //kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }
                                    if (hit.distance >= 6.1f)
                                    {
                                        kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("moveDikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0.125f);
                                        //kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }

                                    saydir(forcounter, kupX, puan);

                                    ifcase = 1;
                                }

                                else
                                {
                                    return;
                                }
                            }
                            print("sag");


                        }
                        else
                        {
                            swipedLeft = true;


                            if (Physics.Raycast(kup_newPos.position, -transform.right, out hit, 25))
                            {
                                kayroRotate.DOLocalRotate(new Vector3(-90, -90, 0), 0);

                                var gitSol = hit.distance - 0.5f;

                                hitDistance = hit.distance;

                                int puan = Mathf.RoundToInt(hit.distance - 0.5f);

                                Debug.DrawRay(kup.position, transform.TransformDirection(-Vector3.right) * hit.distance, Color.yellow);

                                if (hit.rigidbody != null & hit.distance > 0.5f)
                                {
                                    controlBool = false;

                                    Vector3 go = new Vector3(gitSol + 0.5f, 0, 0);
                                    Vector3 go2 = new Vector3(-gitSol + kup_newPos.position.x, 0, 0);
                                    int forcounter = Mathf.RoundToInt(go2.x);
                                    goWay = Mathf.RoundToInt(go2.x);

                                    tuzakDirection = 2;

                                    if (hit.distance <= 4)
                                    {
                                        kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveX(goWay, 0.045f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0f);
                                        //kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }
                                    if (hit.distance >= 4.1f && hit.distance <= 6)
                                    {
                                        kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveX(goWay, 0.145f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0.1f);
                                        //kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }
                                    if (hit.distance >= 6.1)
                                    {
                                        kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("moveDikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveX(goWay, 0.245f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0.125f);
                                        //kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }

                                    saydirSol(forcounter, kupX, puan);

                                    ifcase = 2;


                                }
                                else
                                {
                                    return;
                                }
                            }
                            print("sol");
                        }
                    }


                    else
                    { // Vertical swipe
                        if (swipe.y > 0)
                        {
                            swipedUp = true;

                            if (Physics.Raycast(kup_newPos.position, transform.forward, out hit, 25))
                            {
                                kayroRotate.DOLocalRotate(new Vector3(-90, 0, 0), 0);

                                var gitYukarı = hit.distance - 0.5f;

                                hitDistance = hit.distance;

                                int puan = Mathf.RoundToInt(hit.distance - 0.5f);


                                Debug.DrawRay(kup.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                                if (hit.rigidbody != null && hit.distance > 0.5f)
                                {
                                    controlBool = false;

                                    Vector3 go = new Vector3(0, 0, gitYukarı + 0.5f);
                                    Vector3 go2 = new Vector3(0, 0, gitYukarı + kup_newPos.position.z);
                                    int forcounter = Mathf.RoundToInt(go2.z);
                                    goWay = Mathf.RoundToInt(go2.z);


                                    tuzakDirection = 3;

                                    if (hit.distance <= 4)
                                    {
                                        kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveZ(go2.z, 0.045f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0f);
                                        //kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }
                                    if (hit.distance >= 4.1f && hit.distance <= 6)
                                    {
                                        kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveZ(go2.z, 0.145f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0.1f);
                                        //kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }
                                    if (hit.distance >= 6.1f)
                                    {
                                        kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("movee")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        //kup.DOMoveZ(go2.z, 0.245f).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
                                        kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        Invoke("particleWall", 0.125f);
                                        //kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                    }




                                    saydirYukari(forcounter, kupZ, puan);

                                    ifcase = 3;

                                }
                                else
                                {
                                    return;
                                }
                            }
                            print("yukarı");
                        }
                        else
                        {
                            swipedDown = true;


                            if (Physics.Raycast(kup_newPos.position, -transform.forward, out hit, 25))
                            {
                                kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0);

                                var gitAsagi = hit.distance - 0.5f;

                                hitDistance = hit.distance;

                                int puan = Mathf.RoundToInt(hit.distance - 0.5f);


                                Debug.DrawRay(kup.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.yellow);

                                if (hit.rigidbody != null && hit.distance > 0.5f)
                                {

                                    controlBool = false;

                                    Vector3 go = new Vector3(0, 0, gitAsagi + 0.5f);
                                    Vector3 go2 = new Vector3(0, 0, -gitAsagi + kup_newPos.position.z);
                                    int forcounter = Mathf.RoundToInt(go2.z);
                                    goWay = Mathf.RoundToInt(go2.z);

                                    tuzakDirection = 4;

                                    if (hit.distance <= 4)
                                    {
                                        kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        //kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                        Invoke("particleWall", 0f);

                                    }
                                    if (hit.distance >= 4.1f && hit.distance <= 6)
                                    {
                                        kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        //kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                        Invoke("particleWall", 0.1f);

                                    }
                                    if (hit.distance >= 6.1f)
                                    {
                                        kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("movee")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
                                        kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
                                        //kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => particle.GetComponent<ParticleSystem>().Play());
                                        Invoke("particleWall", 0.125f);
                                    }


                                    saydirAsagi(forcounter, kupZ, puan);

                                    ifcase = 4;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            print("asagi");
                        }
                    }
                }
            }
        }

		if (realScoreEND != null)
			realScoreEND.text = Mathf.RoundToInt(sure).ToString();
		if (realScorePAUSE != null)
			realScorePAUSE.text = Mathf.RoundToInt(sure).ToString();

		if (visitedNodes.Count == zeminCounter)
			openPopUp();

		if (sure <= 0)//&& CharAdReward.odulAlindi == 0
		{
			pausePU.SetActive(true);
			textpos = GameObject.Find("karakterPositionFail").transform.position;
			if ((levelSave + 1) % 2 == 0)
			{
				animFail1.SetActive(true);
				animFail1.transform.position = textpos;
				animFail1.transform.DOScale(new Vector3(screenSize, screenSize, screenSize), 0);
			}
			else
			{
				animFail2.SetActive(true);
				animFail2.transform.position = textpos;
				animFail2.transform.DOScale(new Vector3(screenSize, screenSize, screenSize), 0);
			}
			pause.SetActive(false);
			timeBool = false;
			controlBool = false;
			//charAnimFire.SetActive(true);
			adRemover.SetActive(false);
			blackPanel.SetActive(true);

			if (!callFail)
			{
				gaint.LevelFail(levelSave);
				Invoke("failParticle", 0.5f);
				callFail = true;
			}
		}
		else
		{
			animFail1.SetActive(false);
			animFail2.SetActive(false);
			timeBool = true;
			controlBool = true;
		}

		int say = 0;
		if (visitedNodes.Count == zeminCounter)
		{
			pause.SetActive(false);
			adRemover.SetActive(false);

			if (!callComplete)
			{
				gaint.LevelComplete(levelSave, (int)(sure));
				gaint.LevelDiamond(levelSave, totalGem);
				callComplete = true;
			}

			while (sure <= say)
			{
				sure--;
				if (levelGemText != null)
					levelGemText.text = sure.ToString();
			}
		}
	}
	private void LateUpdate()
	{
		score0 = 0;
		score1 = 0;
	}

	private void failParticle()
	{
		particleFail.GetComponent<ParticleSystem>().Play();
		particleFail2.GetComponent<ParticleSystem>().Play();
	}
	private void particleWall()
	{
		particle.GetComponent<ParticleSystem>().Play();

	}
	public void saydir(int git, int xPosition, int puan)
	{
		int zCoordinate = Mathf.RoundToInt(kup.position.z);


		for (int i = xPosition + 1; i <= git; i++)
		{
			if (!visitedNodes.Contains(new Tuple<int, int>(i, zCoordinate)))
			{
				visitedNodes.Add(new Tuple<int, int>(i, zCoordinate));
				print("ekleniyor");
				score0 += 1;


				if (zCoordinate == 1)
					map_creator.floor[i + 25].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 2)
					map_creator.floor[i + 50].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 3)
					map_creator.floor[i + 75].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 4)
					map_creator.floor[i + 100].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 5)
					map_creator.floor[i + 125].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 6)
					map_creator.floor[i + 150].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 7)
					map_creator.floor[i + 175].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 8)
					map_creator.floor[i + 200].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 9)
					map_creator.floor[i + 225].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 10)
					map_creator.floor[i + 250].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 11)
					map_creator.floor[i + 275].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 12)
					map_creator.floor[i + 300].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 13)
					map_creator.floor[i + 325].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 14)
					map_creator.floor[i + 350].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 15)
					map_creator.floor[i + 375].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 16)
					map_creator.floor[i + 400].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 17)
					map_creator.floor[i + 425].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 18)
					map_creator.floor[i + 450].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 19)
					map_creator.floor[i + 475].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 20)
					map_creator.floor[i + 500].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 21)
					map_creator.floor[i + 525].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 22)
					map_creator.floor[i + 550].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 23)
					map_creator.floor[i + 575].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);

				else if (zCoordinate == 24)
					map_creator.floor[i + 600].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, -90, 90), 0.5f);
			}
			else
			{
				Debug.Log("sag eklenemedi");
				score1 -= 1;
			}

		}


		sure += (score0 + score1);

		//barcut.eklecıkar(score0+score1);
		if ((score0 + score1) > 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.green;
			timeFallDownText.text = "+" + (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}
		else if ((score0 + score1) < 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.red;
			timeFallDownText.text = (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}

		if (sure >= 0)
		{
			if (scoreText != null)
				scoreText.text = sure.ToString();
			if (sureShadowText != null)
				sureShadowText.text = sure.ToString();
		}
		else
		{
			sure = 0;
			if (scoreText != null)
				scoreText.text = sure.ToString();

		}


	}

	public void saydirSol(int git, int xPosition, int puan)
	{
		int zCoordinate = Mathf.RoundToInt(kup.position.z);


		for (int i = xPosition - 1; i >= git; i--)
		{
			if (!visitedNodes.Contains(new Tuple<int, int>(i, zCoordinate)))
			{
				visitedNodes.Add(new Tuple<int, int>(i, zCoordinate));
				print("ekleniyor");
				score0 += 1;


				if (zCoordinate == 1)
					map_creator.floor[i + 25].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 2)
					map_creator.floor[i + 50].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 3)
					map_creator.floor[i + 75].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 4)
					map_creator.floor[i + 100].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 5)
					map_creator.floor[i + 125].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 6)
					map_creator.floor[i + 150].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 7)
					map_creator.floor[i + 175].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 8)
					map_creator.floor[i + 200].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 9)
					map_creator.floor[i + 225].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 10)
					map_creator.floor[i + 250].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 11)
					map_creator.floor[i + 275].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 12)
					map_creator.floor[i + 300].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 13)
					map_creator.floor[i + 325].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 14)
					map_creator.floor[i + 350].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 15)
					map_creator.floor[i + 375].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 16)
					map_creator.floor[i + 400].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 17)
					map_creator.floor[i + 425].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 18)
					map_creator.floor[i + 450].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 19)
					map_creator.floor[i + 475].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 20)
					map_creator.floor[i + 500].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 21)
					map_creator.floor[i + 525].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 22)
					map_creator.floor[i + 550].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 23)
					map_creator.floor[i + 575].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);

				else if (zCoordinate == 24)
					map_creator.floor[i + 600].GetComponent<Transform>().DOLocalRotate(new Vector3(0, -90, 90), 0.5f);
			}
			else
			{
				Debug.Log("sol eklenemedi");
				score1 -= 1;
			}
		}



		sure += (score0 + score1);
		//barcut.eklecıkar(score0+score1);

		if ((score0 + score1) > 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.green;
			timeFallDownText.text = "+" + (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}
		else if ((score0 + score1) < 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.red;
			timeFallDownText.text = (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}

		if (sure >= 0)
		{
			if (scoreText != null)
				scoreText.text = sure.ToString();
			if (sureShadowText != null)
				sureShadowText.text = sure.ToString();
		}
		else
		{
			sure = 0;
			if (scoreText != null)
				scoreText.text = sure.ToString();

		}



	}

	public void saydirYukari(int git, int zPosition, int puan)
	{
		int xCoordinate = Mathf.RoundToInt(kup.position.x);


		for (int i = zPosition + 1; i <= git; i++)
		{
			if (!visitedNodes.Contains(new Tuple<int, int>(xCoordinate, i)))
			{
				visitedNodes.Add(new Tuple<int, int>(xCoordinate, i));
				print("ekleniyor");
				score0 += 1;


				if (xCoordinate == 1)
					map_creator.floor[(i * 25) + 1].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 2)
					map_creator.floor[(i * 25) + 2].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 3)
					map_creator.floor[(i * 25) + 3].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 4)
					map_creator.floor[(i * 25) + 4].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 5)
					map_creator.floor[(i * 25) + 5].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 6)
					map_creator.floor[(i * 25) + 6].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 7)
					map_creator.floor[(i * 25) + 7].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 8)
					map_creator.floor[(i * 25) + 8].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 9)
					map_creator.floor[(i * 25) + 9].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 10)
					map_creator.floor[(i * 25) + 10].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 11)
					map_creator.floor[(i * 25) + 11].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 12)
					map_creator.floor[(i * 25) + 12].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 13)
					map_creator.floor[(i * 25) + 13].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 14)
					map_creator.floor[(i * 25) + 14].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 15)
					map_creator.floor[(i * 25) + 15].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 16)
					map_creator.floor[(i * 25) + 16].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 17)
					map_creator.floor[(i * 25) + 17].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 18)
					map_creator.floor[(i * 25) + 18].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 19)
					map_creator.floor[(i * 25) + 19].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 20)
					map_creator.floor[(i * 25) + 20].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 21)
					map_creator.floor[(i * 25) + 21].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 22)
					map_creator.floor[(i * 25) + 22].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 23)
					map_creator.floor[(i * 25) + 23].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

				else if (xCoordinate == 24)
					map_creator.floor[(i * 25) + 24].GetComponent<Transform>().DOLocalRotate(new Vector3(0, 0, 0), 0.5f);

			}
			else
			{
				Debug.Log("yukarı eklenemedi");
				score1 -= 1;
			}



		}

		sure += (score0 + score1);

		//barcut.eklecıkar(score1);

		if ((score0 + score1) > 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.green;
			timeFallDownText.text = "+" + (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}
		else if ((score0 + score1) < 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.red;
			timeFallDownText.text = (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}

		if (sure >= 0)
		{
			if (scoreText != null)
				scoreText.text = sure.ToString();
			if (sureShadowText != null)
				sureShadowText.text = sure.ToString();
		}
		else
		{
			sure = 0;
			if (scoreText != null)
				scoreText.text = sure.ToString();

		}



	}

	public void saydirAsagi(int git, int zPosition, int puan)
	{
		int xCoordinate = Mathf.RoundToInt(kup.position.x);


		for (int i = zPosition - 1; i >= git; i--)
		{
			if (!visitedNodes.Contains(new Tuple<int, int>(xCoordinate, i)))
			{
				visitedNodes.Add(new Tuple<int, int>(xCoordinate, i));
				print("ekleniyor");
				score0 += 1;


				if (xCoordinate == 1)
					map_creator.floor[(i * 25) + 1].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 2)
					map_creator.floor[(i * 25) + 2].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 3)
					map_creator.floor[(i * 25) + 3].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 4)
					map_creator.floor[(i * 25) + 4].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 5)
					map_creator.floor[(i * 25) + 5].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 6)
					map_creator.floor[(i * 25) + 6].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 7)
					map_creator.floor[(i * 25) + 7].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 8)
					map_creator.floor[(i * 25) + 8].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 9)
					map_creator.floor[(i * 25) + 9].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 10)
					map_creator.floor[(i * 25) + 10].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 11)
					map_creator.floor[(i * 25) + 11].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 12)
					map_creator.floor[(i * 25) + 12].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 13)
					map_creator.floor[(i * 25) + 13].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 14)
					map_creator.floor[(i * 25) + 14].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 15)
					map_creator.floor[(i * 25) + 15].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 16)
					map_creator.floor[(i * 25) + 16].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 17)
					map_creator.floor[(i * 25) + 17].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 18)
					map_creator.floor[(i * 25) + 18].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 19)
					map_creator.floor[(i * 25) + 19].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 20)
					map_creator.floor[(i * 25) + 20].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 21)
					map_creator.floor[(i * 25) + 21].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 22)
					map_creator.floor[(i * 25) + 22].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 23)
					map_creator.floor[(i * 25) + 23].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);

				else if (xCoordinate == 24)
					map_creator.floor[(i * 25) + 24].GetComponent<Transform>().DOLocalRotate(new Vector3(-180, 0, 0), 0.5f);
			}
			else
			{
				Debug.Log("asagi eklenemedi");
				score1 -= 1;
			}


		}

		sure += (score0 + score1);
		//barcut.eklecıkar(score1);

		if ((score0 + score1) > 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.green;
			timeFallDownText.text = "+" + (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}
		else if ((score0 + score1) < 0)
		{
			GameObject.Find("textAnim").GetComponent<textAnimation>().TimeAnimation(score0, score1);
			/*timeFallDownText.GetComponent<Text>().color = Color.red;
			timeFallDownText.text = (score0 + score1).ToString();
			timeFallDownText.GetComponent<Animator>().SetTrigger("bigText");*/

		}


		if (sure >= 0)
		{
			if (scoreText != null)
				scoreText.text = sure.ToString();
			if (sureShadowText != null)
				sureShadowText.text = sure.ToString();
		}
		else
		{
			sure = 0;
			if (scoreText != null)
				scoreText.text = sure.ToString();

		}
	}


	public void nextLevel()
	{
		SceneManager.LoadScene("New Scene");
		level = levelSave + 1;
		PlayerPrefs.SetInt("lastLevel", level);

	}

	public void ChestRoomLevel()
	{
		level = levelSave + 1;
		PlayerPrefs.SetInt("lastLevel", level);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void CharSelectScreen()
	{
		SceneManager.LoadScene("characterSelect");
		Time.timeScale = 1;

		//charSelect = 2 ise oyundan geçiş yapıldığını gösterir.
		PlayerPrefs.SetInt("charSelect", 2);

	}

	private void KeyCounter()
	{
		keyCount = PlayerPrefs.GetInt("key");

		if (keyCount >= 3)
		{
			nextButtonReal.SetActive(false);
			chestRoomButton.SetActive(true);
		}
		else
			chestRoomButton.SetActive(false);
	}

	public void sayac()
	{
		if (levelGemText != null)
			levelGemText.text = "+" + Mathf.RoundToInt(sure / 4).ToString();

		//totalGem += Mathf.RoundToInt(sure / 4);
		//PlayerPrefs.SetInt("totalGem", totalGem);
		gaint.LevelAnaliz(levelSave, sure);
		callOneTime = true;
	}

	void openPopUp()
	{
		if (visitedNodes.Count == zeminCounter)
		{
			PlayerPrefs.SetInt("sure", Mathf.RoundToInt(sure / 4));

			timeBool = false;
			controlBool = false;

			if ((levelSave + 1) <= 10 && (levelSave + 1) % 5 == 0)
			{
				Invoke("completeAnim", 1.15f);
			}

			else if ((levelSave + 1) > 10 && (levelSave + 1) % 2 == 0)
			{
				Invoke("completeAnim", 1.15f);

			}

			else
				Invoke("completeAnim", 1.15f);

			Invoke("openPanel", 1);

			if (!callShowad)
			{
				Invoke("GecisReklam", 1.15f);
				callShowad = true;
			}

			soundd.SetActive(true);
			/*konfetti.Play();
			konfetti2.Play();
			konfetti3.Play();
			konfetti4.Play();*/
			Invoke("UpLine", 0.05f);


			pausePU.SetActive(false);


			score0 = 1;
			score1 = 0;
			levelEnd = 1;
			shieldButton.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);

			if (!callOneTime)
				sayac();
		}

	}

	private void completeAnim()
	{
		animNext.SetActive(true);
		//nextParticle.GetComponent<ParticleSystem>().Play();
		animNext.transform.position = textpos;
		animNext.transform.DOScale(new Vector3(screenSize, screenSize, screenSize), 0);
	}

	private void GecisReklam()
	{
		if (PlayerPrefs.GetInt("removeAd") == 0)
		{
			if ((levelSave + 1) <= 10 && (levelSave + 1) % 5 == 0)
			{
				admobIntes.ShowAd();
			}

			else if ((levelSave + 1) > 10 && (levelSave + 1) % 2 == 0)
			{
				admobIntes.ShowAd();

			}
		}
	}

	void openPanel()
	{
		if (visitedNodes.Count == zeminCounter)
		{
			starPanel.SetActive(true);

			textpos = GameObject.Find("karakterPositionComplete").transform.position;

			timeBool = false;
			controlBool = false;
			shieldButton.SetActive(false);
			var zemin = GameObject.FindGameObjectsWithTag("zemin");
			var duvar = GameObject.FindGameObjectsWithTag("duvar");
			blackPanel.SetActive(true);
			adRemover.SetActive(false);

			KeyCounter();

			if (!callOneTimeMusic)
				victorySource.PlayOneShot(victoryClip, 1);

			callOneTimeMusic = true;
		}
	}


	public void Vibrate()
	{
		MMVibrationManager.Haptic(HapticTypes.LightImpact, true);
	}


	public void KayroSelect()
	{
		if (changeMaterial.selectSkin == 5 || skin == 5)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/ninjaMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/ninjaMat") as Material;

			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			if (charNameText != null)
				charNameText.text = "NINJA";



		}

		else if (changeMaterial.selectSkin == 2 || skin == 2)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/kissMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/kissMat") as Material;

			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "RAINBOW";

		}

		else if (changeMaterial.selectSkin == 3 || skin == 3)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/pandaMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/pandaMat") as Material;

			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "PANDA";

		}

		else if (changeMaterial.selectSkin == 4 || skin == 4)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/punisherMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/punisherMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "IMMORTAL";

		}

		else if (changeMaterial.selectSkin == 1 || skin == 1)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/bowinMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/bowinMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "BOWIN";

		}

		else if (changeMaterial.selectSkin == 6 || skin == 6)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/color1Mat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/color1Mat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "POLITE";

		}

		else if (changeMaterial.selectSkin == 7 || skin == 7)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/lemonMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/lemonMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "ZOMB";

		}

		else if (changeMaterial.selectSkin == 8 || skin == 8)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/strawberryMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/strawberryMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "SWEET";


		}

		else if (changeMaterial.selectSkin == 9 || skin == 9)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/nightMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/nightMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "NIGHT";

		}

		else if (changeMaterial.selectSkin == 10 || skin == 10)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/clownMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/clownMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "CLOWN";

		}

		else if (changeMaterial.selectSkin == 11 || skin == 11)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/covidMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/covidMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "COVID";

		}

		else if (changeMaterial.selectSkin == 12 || skin == 12)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/frenkieMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/frenkieMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "FRANKIE";


		}

		else if (changeMaterial.selectSkin == 13 || skin == 13)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/mummyMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/mummyMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			if (charNameText != null)
				charNameText.text = "MUMMY";

		}

		else if (changeMaterial.selectSkin == 14 || skin == 14)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/skeletonMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/skeletonMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "SKELETON";

		}

		else if (changeMaterial.selectSkin == 15 || skin == 15)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/superhero1Mat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/superhero1Mat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "HERO";

		}

		else if (changeMaterial.selectSkin == 16 || skin == 16)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/superhero2Mat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/superhero2Mat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "JUDGE";


		}

		else if (changeMaterial.selectSkin == 17 || skin == 17)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/partymaskMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/partymaskMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "MYSTIC";

		}

		else if (changeMaterial.selectSkin == 18 || skin == 18)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/balkabagiMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/balkabagiMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "PUMPKING";

		}

		else if (changeMaterial.selectSkin == 19 || skin == 19)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/terminatorMat") as Material;
			Material material2 = Resources.Load("Materials/karakterTextures/64/terminatorMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = material2;

			fail1eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail1eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nexteyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicieyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeeyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

			fail1Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			fail2Skin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			pauseSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			nextSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			oyunicSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;
			karakterChangeSkin.GetComponent<SkinnedMeshRenderer>().material = materiall;

			if (charNameText != null)
				charNameText.text = "DESTROYER";

		}
	}


	void UpLine()
	{
		Destroy(konfetti);
		Destroy(konfetti2);
		Destroy(konfetti3);
		Destroy(konfetti4);

	}

	public void musicOFF()
	{
		failSound.GetComponent<AudioSource>().mute = true;
	}

	public void PauseAd()
	{
		pause.SetActive(true);
		if (PlayerPrefs.GetInt("removeAd") == 1)
			adRemover.SetActive(false);
		else
			adRemover.SetActive(true);
	}

	private void skinController()
	{
		if (PlayerPrefs.GetInt("equip") == 1)
		{
			coronaMaske.SetActive(true);
			coronaMaskeC.SetActive(true);
			coronaMaskeEnd.SetActive(true);
			coronaMaskeF.SetActive(true);
			coronaMaskeF2.SetActive(true);
			coronaMaskeP.SetActive(true);
		}
		else
		{
			coronaMaske.SetActive(false);
			coronaMaskeC.SetActive(false);
			coronaMaskeEnd.SetActive(false);
			coronaMaskeF.SetActive(false);
			coronaMaskeF2.SetActive(false);
			coronaMaskeP.SetActive(false);

		}

		if (PlayerPrefs.GetInt("equip") == 2)
		{
			yilbasiSapka.SetActive(true);
			yilbasiSapkaC.SetActive(true);
			yilbasiSapkaEnd.SetActive(true);
			yilbasiSapkaF.SetActive(true);
			yilbasiSapkaF2.SetActive(true);
			yilbasiSapkaP.SetActive(true);
		}
		else
		{
			yilbasiSapka.SetActive(false);
			yilbasiSapkaC.SetActive(false);
			yilbasiSapkaEnd.SetActive(false);
			yilbasiSapkaF.SetActive(false);
			yilbasiSapkaF2.SetActive(false);
			yilbasiSapkaP.SetActive(false);
		}

		if (PlayerPrefs.GetInt("equip") == 6)
		{

			askerimigfer.SetActive(true);
			askerimigferC.SetActive(true);
			askerimigferEnd.SetActive(true);
			askerimigferF.SetActive(true);
			askerimigferF2.SetActive(true);
			askerimigferP.SetActive(true);

		}
		else
		{
			askerimigfer.SetActive(false);
			askerimigferC.SetActive(false);
			askerimigferEnd.SetActive(false);
			askerimigferF.SetActive(false);
			askerimigferF2.SetActive(false);
			askerimigferP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 5)
		{
			sapka.SetActive(true);
			sapkaC.SetActive(true);
			sapkaEnd.SetActive(true);
			sapkaF.SetActive(true);
			sapkaF2.SetActive(true);
			sapkaP.SetActive(true);
		}
		else
		{
			sapka.SetActive(false);
			sapkaC.SetActive(false);
			sapkaEnd.SetActive(false);
			sapkaF.SetActive(false);
			sapkaF2.SetActive(false);
			sapkaP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 8)
		{
			dikenlimigfer.SetActive(true);
			dikenlimigferC.SetActive(true);
			dikenlimigferEnd.SetActive(true);
			dikenlimigferF.SetActive(true);
			dikenlimigferF2.SetActive(true);
			dikenlimigferP.SetActive(true);
		}
		else
		{
			dikenlimigfer.SetActive(false);
			dikenlimigferC.SetActive(false);
			dikenlimigferEnd.SetActive(false);
			dikenlimigferF.SetActive(false);
			dikenlimigferF2.SetActive(false);
			dikenlimigferP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 7)
		{
			maske.SetActive(true);
			maskeC.SetActive(true);
			maskeEnd.SetActive(true);
			maskeF.SetActive(true);
			maskeF2.SetActive(true);
			maskeP.SetActive(true);
		}
		else
		{
			maske.SetActive(false);
			maskeC.SetActive(false);
			maskeEnd.SetActive(false);
			maskeF.SetActive(false);
			maskeF2.SetActive(false);
			maskeP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 11)
		{
			spartamaske.SetActive(true);
			spartamaskeC.SetActive(true);
			spartamaskeEnd.SetActive(true);
			spartamaskeF.SetActive(true);
			spartamaskeF2.SetActive(true);
			spartamaskeP.SetActive(true);
		}
		else
		{
			spartamaske.SetActive(false);
			spartamaskeC.SetActive(false);
			spartamaskeEnd.SetActive(false);
			spartamaskeF.SetActive(false);
			spartamaskeF2.SetActive(false);
			spartamaskeP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 9)
		{
			kulaklik.SetActive(true);
			kulaklikC.SetActive(true);
			kulaklikEnd.SetActive(true);
			kulaklikF.SetActive(true);
			kulaklikF2.SetActive(true);
			kulaklikP.SetActive(true);
		}
		else
		{
			kulaklik.SetActive(false);
			kulaklikC.SetActive(false);
			kulaklikEnd.SetActive(false);
			kulaklikF.SetActive(false);
			kulaklikF2.SetActive(false);
			kulaklikP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 3)
		{
			gozluk.SetActive(true);
			gozlukC.SetActive(true);
			gozlukEnd.SetActive(true);
			gozlukF.SetActive(true);
			gozlukF2.SetActive(true);
			gozlukP.SetActive(true);
		}
		else
		{
			gozluk.SetActive(false);
			gozlukC.SetActive(false);
			gozlukEnd.SetActive(false);
			gozlukF.SetActive(false);
			gozlukF2.SetActive(false);
			gozlukP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 10)
		{
			roket.SetActive(true);
			roketC.SetActive(true);
			roketEnd.SetActive(true);
			roketF.SetActive(true);
			roketF2.SetActive(true);
			roketP.SetActive(true);
		}
		else
		{
			roket.SetActive(false);
			roketC.SetActive(false);
			roketEnd.SetActive(false);
			roketF.SetActive(false);
			roketF2.SetActive(false);
			roketP.SetActive(false);
		}
		if (PlayerPrefs.GetInt("equip") == 4)
		{
			kaykay.SetActive(true);
			kaykayC.SetActive(true);
		}
		else
		{
			kaykay.SetActive(false);
			kaykayC.SetActive(false);
		}

		if (PlayerPrefs.GetInt("equip") == 0)
		{
			coronaMaske.SetActive(false);
			coronaMaskeC.SetActive(false);
			coronaMaskeEnd.SetActive(false);
			coronaMaskeF.SetActive(false);
			coronaMaskeF2.SetActive(false);
			coronaMaskeP.SetActive(false);
			yilbasiSapka.SetActive(false);
			yilbasiSapkaC.SetActive(false);
			yilbasiSapkaEnd.SetActive(false);
			yilbasiSapkaF.SetActive(false);
			yilbasiSapkaF2.SetActive(false);
			yilbasiSapkaP.SetActive(false);
			askerimigfer.SetActive(false);
			askerimigferC.SetActive(false);
			askerimigferEnd.SetActive(false);
			askerimigferF.SetActive(false);
			askerimigferF2.SetActive(false);
			askerimigferP.SetActive(false);
			sapka.SetActive(false);
			sapkaC.SetActive(false);
			sapkaEnd.SetActive(false);
			sapkaF.SetActive(false);
			sapkaF2.SetActive(false);
			sapkaP.SetActive(false);
			dikenlimigfer.SetActive(false);
			dikenlimigferC.SetActive(false);
			dikenlimigferEnd.SetActive(false);
			dikenlimigferF.SetActive(false);
			dikenlimigferF2.SetActive(false);
			dikenlimigferP.SetActive(false);
			maske.SetActive(false);
			maskeC.SetActive(false);
			maskeEnd.SetActive(false);
			maskeF.SetActive(false);
			maskeF2.SetActive(false);
			maskeP.SetActive(false);
			spartamaske.SetActive(false);
			spartamaskeC.SetActive(false);
			spartamaskeEnd.SetActive(false);
			spartamaskeF.SetActive(false);
			spartamaskeF2.SetActive(false);
			spartamaskeP.SetActive(false);
			kulaklik.SetActive(false);
			kulaklikC.SetActive(false);
			kulaklikEnd.SetActive(false);
			kulaklikF.SetActive(false);
			kulaklikF2.SetActive(false);
			kulaklikP.SetActive(false);
			gozluk.SetActive(false);
			gozlukC.SetActive(false);
			gozlukEnd.SetActive(false);
			gozlukF.SetActive(false);
			gozlukF2.SetActive(false);
			gozlukP.SetActive(false);
			roket.SetActive(false);
			roketC.SetActive(false);
			roketEnd.SetActive(false);
			roketF.SetActive(false);
			roketF2.SetActive(false);
			roketP.SetActive(false);
			kaykay.SetActive(false);
			kaykayC.SetActive(false);
		}
	}

	public void closePurchaseCanvas()
	{
		Time.timeScale = 1;
		purchaseCanvas.SetActive(false);
	}

	public void openPurchaseCanvas()
	{
		Time.timeScale = 0;
		purchaseCanvas.SetActive(true);
	}

	public void go2Purchase()
	{
		if (PlayerPrefs.GetInt("music") == 0)
		{
			GameObject.Find("satinalma_Music").GetComponent<AudioSource>().Play();
			GameObject.Find("satinalma_Music").GetComponent<AudioSource>().mute = false;
			GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = true;
		}

	}
	public void go2Game()
	{
		if (PlayerPrefs.GetInt("music") == 0)
		{
			GameObject.Find("satinalma_Music").GetComponent<AudioSource>().Stop();
			GameObject.Find("satinalma_Music").GetComponent<AudioSource>().mute = true;
			GameObject.Find("backGround_Music").GetComponent<AudioSource>().mute = false;
		}

	}
}
	