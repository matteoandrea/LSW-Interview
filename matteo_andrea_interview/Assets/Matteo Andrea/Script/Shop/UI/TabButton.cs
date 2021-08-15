
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private TabGroup _tabGroup;

    [HideInInspector] public Image backgorund;

    [SerializeField] private UnityEvent OnSelectEvent;
    [SerializeField] private UnityEvent OnDeselectEvent;

    private void Awake()
    {
        backgorund = GetComponent<Image>();
        _tabGroup.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData) => _tabGroup.OnTabSelected(this);

    public void OnPointerEnter(PointerEventData eventData) => _tabGroup.OnTabEnter(this);

    public void OnPointerExit(PointerEventData eventData) => _tabGroup.OnTabExit(this);

    public void Select() => OnSelectEvent.Invoke();
    public void Deselect() => OnDeselectEvent.Invoke();
}
