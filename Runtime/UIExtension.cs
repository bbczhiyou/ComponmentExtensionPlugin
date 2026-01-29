using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace OldAge
{
    public static partial class UIExtension
    {
        public static IEnumerator FadeToAlpha(this CanvasGroup canvasGroup, float alpha, float duration)
        {
            float time = 0f;
            float originalAlpha = canvasGroup.alpha;
            while (time < duration)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = alpha;
        }

        /// <summary>
        /// 边向上边消失
        /// </summary>
        /// <param name="text"></param>
        /// <param name="canvasGroup"></param>
        /// <param name="value"></param>
        /// <param name="duration"></param>
        /// <param name="originalAlpha"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static IEnumerator SmoothValue(this Text text, CanvasGroup canvasGroup, float upValue, float duration, float originalAlpha, float alpha)
        {


            float time = 0f;

            RectTransform rectTransform = text.GetComponent<RectTransform>();

            float originAlpha = rectTransform.anchoredPosition.y;

            while (time < duration)
            {
                time += Time.deltaTime;

                rectTransform.anchoredPosition += new Vector2(0, Mathf.Lerp(originAlpha, upValue, time / duration));

                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);


                yield return new WaitForEndOfFrame();
            }

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, upValue);
        }

        public static int OpenUI(this UIComponent uiComponent, string uiFormAssetName, object userData = null)
        {
            return uiComponent.OpenUIForm(AssetUtility.GetUIFormAsset(uiFormAssetName), "UINormal", userData);
        }

        public static int OpenHintUI(this UIComponent uiComponent,string hint)
        {
            return uiComponent.OpenUIForm(AssetUtility.GetUIFormAsset("UIMainHint"), "UINormal", hint);
        }

        public static void CloseUI(this UIComponent uiComponent, int serialId)
        {
            (uiComponent.GetUIForm(serialId).Logic as UGuiFormLogic).Close();
        }
    }
}