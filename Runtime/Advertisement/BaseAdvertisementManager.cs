using System;
using GameFrameX.Runtime;

namespace GameFrameX.Advertisement.Runtime
{
    public abstract class BaseAdvertisementManager : GameFrameworkModule, IAdvertisementManager
    {
        protected override void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        protected override void Shutdown()
        {
        }

        protected Action<bool> OnShowResult;
        protected Action<string> OnLoadSuccess;
        protected Action<string> OnLoadFail;
        public abstract void Initialize(string adUnitId);

        public abstract void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult);
        public abstract void Load(Action<string> success, Action<string> fail);

        protected void LoadSuccess(string json)
        {
            OnLoadSuccess?.Invoke(json);
        }

        protected void LoadFail(string json)
        {
            OnLoadFail?.Invoke(json);
        }
    }
}