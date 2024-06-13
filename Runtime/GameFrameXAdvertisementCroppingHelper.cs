using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.Runtime
{
    [Preserve]
    public class GameFrameXAdvertisementCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
            _ = typeof(IAdvertisementManager);
            _ = typeof(BaseAdvertisementManager);
            _ = typeof(AdvertisementComponent);
        }
    }
}