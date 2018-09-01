using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour {

    //这个类将抓取自己附着对象的纹理，进行动画播放。


    public Texture2D texture;
    private Sprite mysprite;
    private SpriteRenderer sr;


    public int col = 12;//动画列数
    public int row = 8;//动画行数
    private int singleCol = 3;
    private int singleRow = 4;
    public int index = 0; //八拼一纹理中你所需要精灵的位置。
    public bool isWalking = true; //是否播放行走动画
    public int walkingFrequency = 10; //行走速度，这个值越大，行走频率越低。
    public int face = 0; //行走方向。0,1,2,3

    private int width;
    private int height;
    private int singleWidth; //单个精灵动画的宽度
    private int singleHeight; //单个精灵动画的高度
    private List<Sprite> animSprites;
    private int frameCounter = 0; //帧计数器，每帧更新一次
    private int spriteIndex = 0; //精灵图案索引
    private int spriteDir = 1; //精灵方向：正向播放或者逆向播放精灵动画

    // Use this for initialization
    void Start()
    {
        width = texture.width;
        height = texture.height;
        singleWidth = width / col ;
        singleHeight = height / row;

        animSprites = new List<Sprite>();

        int positionX = (index % 4) * singleWidth * singleCol; //单个精灵动画集的x坐标
        int positionY = height - (index / 4) * singleHeight * singleRow; //单个精灵动画集的y坐标

        //获取精灵动画数组
        for (int i=0; i<singleCol*singleRow; i++)
        {
            Rect rect = new Rect(positionX + ((i % singleCol) * singleWidth), positionY - singleHeight - (i / singleCol) * singleHeight, singleWidth, singleHeight);
            animSprites.Add(Sprite.Create(texture, rect, new Vector2(0.0f, 0.0f)));
        }    
        
        sr = GetComponent<SpriteRenderer>();
        spriteIndex = face * 3 + 1;

        //显示精灵
        sr.sprite = animSprites[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            UpdateAnim();
        }

        
    }

    //更新行走动画
    void UpdateAnim()
    {
        frameCounter++;
        if (frameCounter % walkingFrequency == 0)
        {
            spriteIndex += spriteDir;
            if (spriteIndex < face * 3 + 1)
            {
                spriteDir = 1;
            }
            else if (spriteIndex > face * 3 + 1)
            {
                spriteDir = -1;
            }
            frameCounter = 0; //重置帧计数器
        }
        sr.sprite = animSprites[spriteIndex];
    }

   
}
