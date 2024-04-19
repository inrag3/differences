using System.Collections;
using UnityEngine;

namespace Code.Game.Common
{
    public interface ICoroutinePerformer
    {
        public Coroutine StartPerform(IEnumerator coroutine);

        public void StopPerform(Coroutine coroutine);
    }
}