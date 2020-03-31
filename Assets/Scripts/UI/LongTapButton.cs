using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class LongTapButton : Button
    {
        private float endLongTouchTimer;
        private float startLongTouchTimer;
        private float endThreshold;
        private float startThreshold;
        public event Action OnLongClick;
        public event Action OnClick;
        private Coroutine _coroutine;

        public override void OnPointerClick(PointerEventData eventData)
        {
            
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            StartSequence();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            EndSequence();
        }

        public void StartSequence()
        {
            ResetTimers();
            _coroutine = StartCoroutine(LongTapCoroutine());
        }

        public void EndSequence()
        {
            if(startLongTouchTimer < startThreshold) OnClick?.Invoke();
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            ResetTimers();
        }

        private void ResetTimers()
        {
            startLongTouchTimer = 0f;
            endLongTouchTimer = 0f;
        }

        private IEnumerator LongTapCoroutine()
        {
            endThreshold = 1f;
            startThreshold = 0.2f;
            
            while (true)
            {
                startLongTouchTimer += Time.deltaTime;
                if(startLongTouchTimer > startThreshold)
                {
                    break;
                }

                yield return null;
            }

            var fireLongTap = false;
            while (true)
            {
                endLongTouchTimer += Time.deltaTime;
                if (!fireLongTap && endThreshold < endLongTouchTimer)
                {
                    Debug.Log(endLongTouchTimer);
                    OnLongClick?.Invoke();
                    fireLongTap = true;
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}