using Android.Net.Http;
using Android.Webkit;
using Xamarin.Forms.Platform.Android;

namespace CustomRenderer.Droid
{
    public class JavascriptWebViewClient : FormsWebViewClient
    {
        string _javascript;

        public JavascriptWebViewClient(HybridWebViewRenderer renderer, string javascript) : base(renderer)
        {
            _javascript = javascript;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_javascript, null);
        }

        public override void OnReceivedSslError(WebView view, SslErrorHandler handler, SslError error)
        {
#if !DEBUG
            base.OnReceivedSslError(view, handler, error);
#endif

#if DEBUG
            //if (error.Certificate.IssuedBy.CName == "localhost" &&
            //  error.Certificate.IssuedTo.CName == "localhost" &&
            //  error.PrimaryError == Android.Net.Http.SslErrorType.Untrusted)
            //{
            //    // Accept self-signed certificate only:
            //    handler.Proceed();
            //}

            //handler.Cancel();

            handler.Proceed();
#endif
        }
    }
}
