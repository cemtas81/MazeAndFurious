using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMatMenu : MonoBehaviour
{
	public GameObject animOBJ;
	public GameObject karakter;
	public GameObject karakterpos;
	private int skin;
	public GameObject eyeL;
	public GameObject eyeR;
	public Camera cmr;

    private void Awake()
    {
		if ((Screen.width * 2) < Screen.height)
			cmr.GetComponent<Camera>().orthographicSize = 2.9f;
		else if ((Screen.width * 2) == Screen.height)
			cmr.GetComponent<Camera>().orthographicSize = 2.7f;
	}

    private void Start()
    {
		skin = PlayerPrefs.GetInt("skin");
		KayroSelect();
    }

    private void Update()
    {
		karakter.transform.position = karakterpos.transform.position;
    }

    public void KayroSelect()
	{
		if (changeMaterial.selectSkin == 5 || skin == 5)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/ninjaMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 2 || skin == 2)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/kissMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 3 || skin == 3)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/pandaMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 4 || skin == 4)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/punisherMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;


		}

		else if (changeMaterial.selectSkin == 1 || skin == 1)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/bowinMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 6 || skin == 6)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/color1Mat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 7 || skin == 7)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/lemonMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 8 || skin == 8)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/strawberryMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;


		}

		else if (changeMaterial.selectSkin == 9 || skin == 9)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/nightMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 10 || skin == 10)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/clownMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 11 || skin == 11)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/covidMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 12 || skin == 12)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/frenkieMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;


		}

		else if (changeMaterial.selectSkin == 13 || skin == 13)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/mummyMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 14 || skin == 14)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/skeletonMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 15 || skin == 15)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/superhero1Mat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 16 || skin == 16)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/superhero2Mat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;


		}

		else if (changeMaterial.selectSkin == 17 || skin == 17)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/partymaskMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 18 || skin == 18)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/balkabagiMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

		else if (changeMaterial.selectSkin == 19 || skin == 19)
		{
			Material materiall = Resources.Load("Materials/karakterTextures/512/terminatorMat") as Material;
			animOBJ.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeL.GetComponent<SkinnedMeshRenderer>().material = materiall;
			eyeR.GetComponent<SkinnedMeshRenderer>().material = materiall;

		}

	}
}
