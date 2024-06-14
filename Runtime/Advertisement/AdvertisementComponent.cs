using System;
using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.Advertisement.Runtime
{
    /// <summary>
    /// Mono 组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Advertisement")]
    public class AdvertisementComponent : GameFrameworkComponent
    {
        /// <summary>
        /// 广告位ID
        /// </summary>
        [SerializeField] private string m_adUnitId = string.Empty;

        /// <summary>
        /// 广告位ID
        /// </summary>
        public string AdUnitId
        {
            get => m_adUnitId;
            set => m_adUnitId = value;
        }

        private IAdvertisementManager _advertisementManager;
        private EventComponent m_EventComponent;

        protected override void Awake()
        {
            ImplementationComponentType = Utility.Assembly.GetType(componentType);
            InterfaceComponentType = typeof(IAdvertisementManager);
            base.Awake();
            _advertisementManager = GameFrameworkEntry.GetModule<IAdvertisementManager>();
            if (_advertisementManager == null)
            {
                Log.Fatal("Advertisement manager is invalid.");
                return;
            }

            m_EventComponent = GameEntry.GetComponent<EventComponent>();
            if (m_EventComponent == null)
            {
                Log.Fatal("Event manager is invalid.");
                return;
            }
        }

        private void Start()
        {
            _advertisementManager.Initialize(AdUnitId);
        }

        /// <summary>
        /// 展示广告
        /// </summary>
        /// <param name="success">展示成功回调</param>
        /// <param name="fail">展示失败回调</param>
        /// <param name="onShowResult">展示成功后广告关闭回调。参数值为true表示广告应该发放奖励，为false表示没有完整播放完广告</param>
        public void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult)
        {
            _advertisementManager.Show(success, fail, onShowResult);
        }

        /// <summary>
        /// 加载广告
        /// </summary>
        /// <param name="success">加载成功回调</param>
        /// <param name="fail">加载失败回调</param>
        public void Load(Action<string> success, Action<string> fail)
        {
            _advertisementManager.Load(success, fail);
        }
    }
}