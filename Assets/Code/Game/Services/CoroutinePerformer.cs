﻿using System.Collections;
using UnityEngine;

namespace Game.Services
{
    public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
    {
        public Coroutine StartPerform(IEnumerator coroutine)
            => StartCoroutine(coroutine);

        public void StopPerform(Coroutine coroutine)
            => StopCoroutine(coroutine);
    }
}