using System;
using UnityEngine;
using UnityEditor;
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

public class Tutorial : MonoBehaviour
{
	private int hareket = 0;
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
	//private GAinitialize gaint;
	//private AdMobIntestitial admobIntes;

	private AudioSource victorySource;
	public AudioClip victoryClip;

	private int keyCount;
	public GameObject chestRoomButton;
	public GameObject adRemoveGo;

	public GameObject hand;
	public GameObject hand2;
	public GameObject hand3;
	public GameObject hand4;

	public GameObject arrow;
	public GameObject arrow2;
	public GameObject arrow3;
	public GameObject arrow4;

	public GameObject blackpanel2;

	public GameObject timeViewer;
	public GameObject zamanSag;
	public GameObject zamanSol;
	public GameObject zamanYukari;
	public GameObject zamanAsagi;

	public static int tutorialScene = 1;
	private int moveLeft = 0;

	private bool hareketBool;
	private bool controlAnim;


	public void Awake()
	{
		barcut = GameObject.Find("HealthBarCut").GetComponent<HealthBarCut>();
		animScript = GameObject.Find("LevelObject").GetComponent<animationScript>();
		MusicObj = GameObject.Find("MusicObject").GetComponent<yourClass>();
		//gaint = GameObject.Find("GameAnalytics").GetComponent<GAinitialize>();
	}

	void Start()
	{
		controlAnim = true;

		pausePU.SetActive(false);

		hareket = 1;
		tutorialScene = 1;
		/*if (tutorialScene == 1)
			hareket = 1;
		else
		{
			arrow.SetActive(false);
			timeViewer.SetActive(true);
			timeBool = false;
			blackpanel2.SetActive(true);
			hareket = 6;
		}*/
		hareketBool = false;

		victorySource = GameObject.Find("kazanma").GetComponent<AudioSource>();

		/*if (PlayerPrefs.GetInt("removeAd") == 1)
		{
			adRemover.SetActive(false);
			adRemoveGo.SetActive(false);
		}
		else
			admobIntes = GameObject.Find("AdMobRemove").GetComponent<AdMobIntestitial>();*/

		barsure = bar.GetComponent<Image>();

		animator = GetComponent<Animator>();
		//blackPanel.SetActive(true);
		//PlayerPrefs.DeleteAll();

		KayroSelect();

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


		callOneTime = false;
		callOneTimeMusic = false;
		callShowad = false;
		callComplete = false;
		callFail = false;

		sure = 60;
		pause.SetActive(false);
		//play.SetActive(true);
		//shieldButton.SetActive(true);

		if (userName != null)
			userName.text = PlayerPrefs.GetString("playerName").ToUpper();

		scene = SceneManager.GetActiveScene();
		levelNumber = scene.buildIndex - 2;
		levelSave = PlayerPrefs.GetInt("lastLevel");

		/*if (levelNumber != 1)
		{
			if (levelNumber >= levelSave)
				PlayerPrefs.SetInt("lastLevel", levelNumber);
		}*/

		if (levelText != null)
			levelText.text = "Tutorial";
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
	private void FixedUpdate()
	{

	}

	public void Update()
	{
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
		if (tutorialScene == 2 && hareket == 6)
		{
			if (sure >= 54 && sure <= 60)
			{
				controlAnim = false;
			}
		}

			if (controlBool == true)
		{

			if (!hareketBool)
				Animation();
			if (controlAnim == true)
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
							if (hareket == 1 || hareket == 5)
							{
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
											Debug.Log("tuzak Direction: " + tuzakDirection);


											if (hit.distance <= 4)
											{
												kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 4.1f && hit.distance <= 6)
											{
												kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 6.1f)
											{
												kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("moveDikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
												kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => zamanSag.transform.DOMove(GameObject.Find("timeText").transform.position, 1.5f));
												if (hareket != 5)
												{
													kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => zamanSag.SetActive(true));
													Invoke("TimeAnimGreen", 1.5f);
													Invoke("zamanSagClose", 1.51f);
												}
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
									//hand.transform.position = GameObject.Find("start").transform.position;
									/*if (tutorialScene == 3)
										hareket = 5;
									else
										hareket = 2;*/
									/*if (tutorialScene == 1)
										hareket = 2;
									else
										hareket = 6;*/


								}
							}
							if (hareket == 2 || hareket == 5)
							{
								if (swipe.x < 0)
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
											Debug.Log("tuzak Direction: " + tuzakDirection);


											if (hit.distance <= 4)
											{
												kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveX(goWay, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 4.1f && hit.distance <= 6)
											{
												kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2Dikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveX(goWay, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 6.1)
											{
												kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("moveDikey")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
												kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => zamanSol.transform.DOMove(GameObject.Find("timeText").transform.position, 1.5f));
												if (hareket != 5)
												{
													kup.DOMoveX(goWay, 0.245f).SetRelative(false).OnComplete(() => zamanSol.SetActive(true));
													Invoke("TimeAnimRed", 1.5f);
													Invoke("zamanSolClose", 1.51f);
												}
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
									//arrow2.SetActive(false);
									/*if (tutorialScene == 3)
										hareket = 5;
									else
										hareket = 3;*/
									/*if (tutorialScene == 1)
										hareket = 3;
									else
										hareket = 6;*/

									if (moveLeft == 1)
										moveLeft = 2;
								}
							}
						}


						else
						{ // Vertical swipe
							if (hareket == 3 || hareket == 5)
							{
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
											Debug.Log("tuzak Direction: " + tuzakDirection);

											if (hit.distance <= 4)
											{
												kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 4.1f && hit.distance <= 6)
											{
												kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 6.1f)
											{
												kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("movee")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0)).OnStepComplete(() => kayroRotate.DOLocalRotate(new Vector3(-90, 180, 0), 0.5f));
												kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
												kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => zamanYukari.transform.DOMove(GameObject.Find("timeText").transform.position, 1.5f));
												if (hareket != 5)
												{
													kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => zamanYukari.SetActive(true));
													Invoke("TimeAnimGreen", 1.5f);
													Invoke("zamanYukariClose", 1.51f);
												}
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
									//arrow3.SetActive(false);
									/*if (tutorialScene == 3)
										hareket = 5;
									else
										hareket = 4;*/
									/*if (tutorialScene == 1)
										hareket = 4;
									else
										hareket = 6;*/
								}
							}
							if (hareket == 4 || hareket == 5)
							{
								if (swipe.y < 0)
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
											Debug.Log("tuzak Direction: " + tuzakDirection);

											Debug.Log(kup_newPos.position);
											Debug.Log(go2.z);





											if (hit.distance <= 4)
											{
												kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnPlay(() => animator.SetTrigger("move3")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
												kup.DOMoveZ(go2.z, 0.045f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 4.1f && hit.distance <= 6)
											{
												kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnPlay(() => animator.SetTrigger("move2")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
												kup.DOMoveZ(go2.z, 0.145f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
											}
											if (hit.distance >= 6.1f)
											{
												kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnPlay(() => animator.SetTrigger("movee")).OnComplete(() => kup.transform.DOScale(new Vector3(1, 1, 1), 0));
												kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => controlBool = true).OnComplete(() => Vibrate());
												kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnStepComplete(() => zamanAsagi.transform.DOMove(GameObject.Find("timeText").transform.position, 1.5f));
												if (hareket != 5)
												{
													kup.DOMoveZ(go2.z, 0.245f).SetRelative(false).OnComplete(() => zamanAsagi.SetActive(true));
													Invoke("TimeAnimRed", 1.5f);
													Invoke("zamanAsagiClose", 1.51f);
												}
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
									//arrow4.SetActive(false);
									/*tutorialScene = 3;
									hareket = 5;*/
									/*if (tutorialScene == 1)
										hareket = 5;
									else
										hareket = 6;*/
								}
							}
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
			/*pausePU.SetActive(true);

			MusicObj.FailMenuMusicOn();

			if (PlayerPrefs.GetInt("music") == 0)
				GameObject.Find("fail").GetComponent<AudioSource>().mute = false;
			else
				GameObject.Find("fail").GetComponent<AudioSource>().mute = true;

			pause.SetActive(false);
			timeBool = false;
			controlBool = false;
			charAnimFire.SetActive(true);
			adRemover.SetActive(false);
			blackPanel.SetActive(true);

			if (!callFail)
			{
				gaint.LevelFail(levelSave);
				callFail = true;
			}*/

			SceneManager.LoadScene("Tutorial");
		}
		else
		{
			//timeBool = true;
			controlBool = true;
		}

		int say = 0;
		if (visitedNodes.Count == zeminCounter)
		{
			pause.SetActive(false);
			adRemover.SetActive(false);

			/*if (!callComplete)
			{
				gaint.LevelComplete(levelSave, (int)(sure));
				callComplete = true;
			}*/

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

	private void zamanSagClose()
	{
		zamanSag.SetActive(false);
		if (hareket == 5)
			hareket = 5;
		else
			hareket = 2;
		arrow.SetActive(false);
	}

	private void TimeAnimGreen()
    {
		GameObject.Find("timeText").GetComponent<Animator>().SetTrigger("1");
		sure += 7;
    }
	private void TimeAnimRed()
    {
		GameObject.Find("timeText").GetComponent<Animator>().SetTrigger("2");
		sure -= 7;
	}

	private void zamanSolClose()
    {
		zamanSol.SetActive(false);
		if (hareket == 5)
			hareket = 5;
		else
			hareket = 3;
		arrow2.SetActive(false);
    }

	private void zamanYukariClose()
	{
		zamanYukari.SetActive(false);
		if (hareket == 5)
			hareket = 5;
		else
			hareket = 4;
		arrow3.SetActive(false);
	}

	private void zamanAsagiClose()
	{
		zamanAsagi.SetActive(false);
		hareket = 5;
		arrow4.SetActive(false);
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


		//sure += (score0 + score1);

		//barcut.eklecıkar(score0 + score1);
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



		//sure += (score0 + score1);
		//barcut.eklecıkar(score0 + score1);

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

		//sure += (score0 + score1);

		//barcut.eklecıkar(score1);

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

		//sure += (score0 + score1);
		//barcut.eklecıkar(score1);

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

	}

	private void KeyCounter()
	{
		keyCount = PlayerPrefs.GetInt("key");

		if (keyCount == 3)
			chestRoomButton.SetActive(true);
		else
			chestRoomButton.SetActive(false);
	}

	public void sayac()
	{
		if (levelGemText != null)
			levelGemText.text = "+" + Mathf.RoundToInt(sure / 4).ToString();

		//totalGem += Mathf.RoundToInt(sure / 4);
		//PlayerPrefs.SetInt("totalGem", totalGem);
		//LevelAnaliz(levelSave, sure);
		callOneTime = true;

	}

	void openPopUp()
	{
		if (visitedNodes.Count == zeminCounter)
		{
			PlayerPrefs.SetInt("sure", Mathf.RoundToInt(sure / 4));

			timeBool = false;
			controlBool = false;

			Invoke("openPanel", 1);

			if (!callShowad)
			{
				Invoke("GecisReklam", 1.15f);
				callShowad = true;
			}

			soundd.SetActive(true);
			konfetti.Play();
			konfetti2.Play();
			konfetti3.Play();
			konfetti4.Play();
			Invoke("UpLine", 0.05f);


			pausePU.SetActive(false);

			blackpanel2.SetActive(false);
			timeViewer.SetActive(false);
			arrow2.SetActive(false);

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

	void GecisReklam()
	{
		/*if ((levelSave + 1) <= 10 && (levelSave + 1) % 5 == 0)
		{
			admobIntes.ShowAd();
		}

		else if ((levelSave + 1) > 10 && (levelSave + 1) % 2 == 0)
		{
			admobIntes.ShowAd();

		}*/
	}

	void openPanel()
	{
		if (visitedNodes.Count == zeminCounter)
		{
			starPanel.SetActive(true);
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
		if (changeMaterial.selectSkin == 1)
		{
			Material materiall = Resources.Load("Materials/ninjaMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = materiall;


			kayroSelect.GetComponent<Image>().sprite = spr1;


		}

		else if (changeMaterial.selectSkin == 2)
		{
			Material materiall = Resources.Load("Materials/simsekMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = materiall;

			kayroSelect.GetComponent<Image>().sprite = spr2;
		}

		else if (changeMaterial.selectSkin == 3)
		{
			Material materiall = Resources.Load("Materials/LGBTmat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = materiall;

			kayroSelect.GetComponent<Image>().sprite = spr3;
		}

		else if (changeMaterial.selectSkin == 4)
		{
			Material materiall = Resources.Load("Materials/pandaMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = materiall;

			kayroSelect.GetComponent<Image>().sprite = spr4;
		}

		else if (changeMaterial.selectSkin == 5)
		{
			Material materiall = Resources.Load("Materials/punisherMat") as Material;
			kup_newPos.GetComponent<SkinnedMeshRenderer>().material = materiall;

			kayroSelect.GetComponent<Image>().sprite = spr5;
		}
	}


	void UpLine()
	{
		Destroy(konfetti);
		Destroy(konfetti2);
		Destroy(konfetti3);
		Destroy(konfetti4);

	}

	public void PauseAd()
	{
		pause.SetActive(true);
		if (PlayerPrefs.GetInt("removeAd") == 1)
			adRemover.SetActive(false);
		else
			adRemover.SetActive(true);
	}

	private void Animation()
	{

		controlAnim = true;
		//hand.transform.position = GameObject.Find("start").transform.position;
		if (hareket == 1)
		{
			timeBool = false;
			Vector3 handposStart = GameObject.Find("start").transform.position;
			Vector3 handposFinish = GameObject.Find("finish").transform.position;
			hareketBool = true;
			hand.SetActive(true);
			hand.transform.DOMoveX(handposFinish.x, 1).OnStepComplete(() => hand.transform.DOMoveX(handposStart.x, 0)).OnComplete(() => hareketBool = false).OnKill(() => hand.SetActive(false));
		}
		else if (hareket == 2)
		{
			timeBool = false;
			arrow2.SetActive(true);
			Vector3 handposStart = GameObject.Find("start2").transform.position;
			Vector3 handposFinish = GameObject.Find("finish2").transform.position;
			hand2.SetActive(true);
			hareketBool = true;
			//arrow.transform.DOLocalRotate(new Vector3(0, 180, 0), 0);
			hand2.transform.DOMove(handposFinish, 1).OnStepComplete(() => hand2.transform.DOMove(handposStart, 0)).OnComplete(() => hareketBool = false).OnKill(() => hand.SetActive(false));
		}
		else if (hareket == 3)
		{
			timeBool = false;
			arrow3.SetActive(true);
			Vector3 handposStart = GameObject.Find("start3").transform.position;
			Vector3 handposFinish = GameObject.Find("finish3").transform.position;
			hand3.SetActive(true);
			hareketBool = true;
			//arrow.transform.DOLocalRotate(new Vector3(0, 0, 90), 0);
			hand3.transform.DOMove(handposFinish, 1).OnStepComplete(() => hand3.transform.DOMove(handposStart, 0)).OnComplete(() => hareketBool = false).OnKill(() => hand.SetActive(false));
		}
		else if (hareket == 4)
		{
			timeBool = false;
			arrow4.SetActive(true);
			Vector3 handposStart = GameObject.Find("start4").transform.position;
			Vector3 handposFinish = GameObject.Find("finish4").transform.position;
			hand4.SetActive(true);
			hareketBool = true;
			//arrow.transform.DOLocalRotate(new Vector3(0, 0, -90), 0);
			hand4.transform.DOMove(handposFinish, 1).OnStepComplete(() => hand4.transform.DOMove(handposStart, 0)).OnComplete(() => hareketBool = false).OnKill(() => hand.SetActive(false));
		}

		else if (hareket == 5)
		{
			hareketBool = true;
			timeBool = true;
			//blackpanel2.SetActive(true);
			//timeViewer.SetActive(true);
			//Vector3 bir = GameObject.Find("1").transform.position;
			//Vector3 iki = GameObject.Find("2").transform.position;
			//timeViewer.transform.DOMove(bir, 1).OnStepComplete(() => timeViewer.transform.DOMove(iki, 0)).OnComplete(() => hareketBool = false);
			//hareket = 6;
			tutorialScene = 3;
			//zamanAsagi.SetActive(false);
			zamanSag.SetActive(false);
			zamanSol.SetActive(false);
			zamanYukari.SetActive(false);
			openPopUp();
		}
		/*else if (tutorialScene == 2 && hareket == 6 || hareket == 2)
		{
			if (moveLeft == 0 || moveLeft == 1)
			{
				if (sure >= 54 && sure <= 60)
				{
					timeBool = true;
					hareketBool = true;
					Vector3 bir = GameObject.Find("1").transform.position;
					Vector3 iki = GameObject.Find("2").transform.position;
					timeViewer.transform.DOMove(bir, 1).OnStepComplete(() => timeViewer.transform.DOMove(iki, 0)).OnComplete(() => hareketBool = false);

				}
				else if (sure <= 53)
				{
					if (moveLeft == 0)
					{
						controlAnim = true;
						blackpanel2.SetActive(false);
						timeViewer.SetActive(false);
						arrow.SetActive(true);
						timeBool = false;
						Vector3 handposStart = GameObject.Find("start").transform.position;
						Vector3 handposFinish = GameObject.Find("finish").transform.position;
						hareketBool = true;
						hand.SetActive(true);
						hand.transform.DOMoveX(handposFinish.x, 1).OnStepComplete(() => hand.transform.DOMoveX(handposStart.x, 0)).OnComplete(() => hareketBool = false);
					}
					else if (moveLeft == 1)
					{

						blackpanel2.SetActive(false);
						timeViewer.SetActive(false);
						arrow.SetActive(false);
						hareketBool = true;
						Vector3 bir = GameObject.Find("1").transform.position;
						Vector3 iki = GameObject.Find("2").transform.position;
						timeViewer.transform.DOMove(bir, 1).OnStepComplete(() => timeViewer.transform.DOMove(iki, 0)).OnComplete(() => hareketBool = false);
						hareket = 6;
					}
				}

				else if (sure >= 61)
				{
					blackpanel2.SetActive(true);
					timeViewer.SetActive(true);
					Vector3 bir = GameObject.Find("1").transform.position;
					Vector3 iki = GameObject.Find("2").transform.position;
					timeViewer.transform.DOMove(bir, 1).OnStepComplete(() => timeViewer.transform.DOMove(iki, 0)).OnComplete(() => hareketBool = false);
					timeBool = false;
					arrow2.SetActive(true);
					Vector3 handposStart = GameObject.Find("start2").transform.position;
					Vector3 handposFinish = GameObject.Find("finish2").transform.position;
					hand2.SetActive(true);
					hareketBool = true;
					hand2.transform.DOMove(handposFinish, 1).OnStepComplete(() => hand2.transform.DOMove(handposStart, 0)).OnComplete(() => hareketBool = false);
					moveLeft = 1;
					hareket = 2;
				}

			}

			 else if(moveLeft==2)
			{
				controlAnim = true;
				hareket = 6;
				timeViewer.SetActive(false);
				blackpanel2.SetActive(false);
				arrow2.SetActive(false);
				openPopUp();
			}
		}*/
	}
}