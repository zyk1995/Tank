using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//属性值
	public float moveSpeed=3;
	private Vector3 bullectEulerAngles;
	private float timeVal;
	//引用
	private SpriteRenderer sr;
	public Sprite[] tankSprites;// 上 右 下 左
	public GameObject bulletPrefab;

	private void Awake(){
		sr = GetComponent<SpriteRenderer> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//攻击的CD
		if (timeVal >= 0.4f)
		{
			Attack();
		}
		else
		{
			timeVal += Time.fixedDeltaTime;
		}
	}

	private void FixedUpdate(){
		Move ();
		Attack ();
	}
	//坦克的攻击方法
	private void Attack(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			//子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
			Instantiate(bulletPrefab, transform.position,Quaternion.Euler(transform.eulerAngles+bullectEulerAngles));
			timeVal = 0;
		}
	}
	//坦克的移动方法
	private void Move(){
		float v = Input.GetAxisRaw("Vertical");
		transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
		if (v < 0)
		{
			sr.sprite = tankSprites[2];
			bullectEulerAngles = new Vector3(0, 0, -180);
		}

		else if (v > 0)
		{
			sr.sprite = tankSprites[0];
			bullectEulerAngles = new Vector3(0, 0, 0);
		}

		if (v != 0) {
			return;
		}

		float h = Input.GetAxisRaw("Horizontal");
		transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
		if (h < 0)
		{
			sr.sprite = tankSprites[3];
			bullectEulerAngles = new Vector3(0, 0, 90);
		}

		else if (h > 0)
		{
			sr.sprite = tankSprites[1];
			bullectEulerAngles = new Vector3(0, 0, -90);
		}
	}
}
