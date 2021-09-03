using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ReticleManager : MonoBehaviour
{

    [SerializeField] Image m_imageFill;
    [SerializeField] float m_fillSpeed;

    private bool m_startFill = false;
    private float m_currentFill;

    // evento cuando se llene la cosa
    static public UnityEvent OnFillComplete;

    private void OnEnable()
    {
        InteractableObject.PointerEnter += OnPointerEnter;
        InteractableObject.PointerExit += OnPointerExit;
    }

    private void OnDisable()
    {
        InteractableObject.PointerEnter -= OnPointerEnter;
        InteractableObject.PointerExit -= OnPointerExit;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnFillComplete = new UnityEvent();
        m_currentFill = 0;
        m_imageFill.fillAmount = m_currentFill;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startFill)
        {
            m_currentFill += Time.deltaTime * m_fillSpeed;
            m_imageFill.fillAmount = m_currentFill;

            if (m_currentFill >= 1)
            {
                m_currentFill = 1;
                m_imageFill.fillAmount = m_currentFill;
                m_startFill = false;
                // cuando termine de llenarse que haga una accion el gaze
                OnFillComplete?.Invoke();
            }
        }
    }

    void OnPointerEnter()
    {
        m_startFill = true;
        m_currentFill = 0;

    }

    void OnPointerExit()
    {
        m_currentFill = 0;
        m_imageFill.fillAmount = m_currentFill;
        m_startFill = false;

    }

}
