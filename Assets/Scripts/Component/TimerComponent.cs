using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Components
{
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField] private TimerData[] _timers;

        public void SetTimer(int index)
        {
            var timer = _timers[index];

            StartCoroutine(StartTimer(timer));
        }

        private IEnumerator StartTimer(TimerData timer)
        {
            yield return new WaitForSeconds(timer.Delay);
            timer.OnTimesUp?.Invoke();

        }
        
        [Serializable]
        public class TimerData
        {
            public float Delay;
            public UnityEvent OnTimesUp;
        }
    }
}