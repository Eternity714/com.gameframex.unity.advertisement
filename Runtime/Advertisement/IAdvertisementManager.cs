using System;

namespace GameFrameX.Advertisement.Runtime
{
    /// <summary>
    /// 用于管理 MonoBehaviour 的接口。
    /// </summary>
    public interface IAdvertisementManager
    {        
        void Initialize(string adUnitId);
        void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult);
        void Load(Action<string> success, Action<string> fail);
    }
}