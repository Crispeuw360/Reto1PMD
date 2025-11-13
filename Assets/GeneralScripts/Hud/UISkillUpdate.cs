using UnityEngine;
using UnityEngine.UI;

public class UISkillUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Sprite BaseSprite;
    [SerializeField] private Sprite ObtainedSprite;
    [SerializeField] private Sprite UsingSprite;


    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = BaseSprite;
    }

    public void Unlock()
    {
        image.sprite = ObtainedSprite;
    }
    public void UseSkill()
    {
        image.sprite = UsingSprite;
    }
    public void unUseSkill()
    {
        image.sprite = ObtainedSprite;
    }
    public void SpendSkill()
    {
        image.sprite = BaseSprite;
    }
}
