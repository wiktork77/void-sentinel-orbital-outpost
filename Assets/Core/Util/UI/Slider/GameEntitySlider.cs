using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntitySlider<E, D> : MonoBehaviour
{

    private List<E> entities;
    private D currentEntityData;

    private int currentIndex;
    private int lastIndex;

    public int CurrentIndex => currentIndex;
    public int LastIndex => lastIndex;

    public GameObject slideForwardButton;
    public GameObject slideBackwardButton;

    protected virtual void Start()
    {
        entities = PopulateEntities();

        currentIndex = 0;
        lastIndex = entities.Count - 1;

        OnSlideChange();
    }


    public void OnSlideForward()
    {
        if (currentIndex >= lastIndex)
        {
            currentIndex = lastIndex;
            return;
        }

        currentIndex++;
        OnSlideChange();
    }

    public void OnSlideBackward()
    {
        if (currentIndex <= 0)
        {
            currentIndex = 0;
            return;
        }

        currentIndex--;
        OnSlideChange();
    }

    public E getCurrentEntity()
    {
        return entities[currentIndex];
    }


    private void OnSlideChange()
    {
        currentEntityData = LoadEntityData();
        UpdateUI(currentEntityData);

        slideForwardButton.SetActive(!(currentIndex == lastIndex));
        slideBackwardButton.SetActive(!(currentIndex == 0));
    }


    protected abstract void UpdateUI(D entityData);

    protected abstract D LoadEntityData();

    protected abstract List<E> PopulateEntities();
}
