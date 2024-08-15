namespace WebView2Test3
{
    public partial class Form1 : Form
    {
        // Shared object between .NET and JavaScript
        private readonly Sample _sample = new Sample();

        public Form1()
        {
            InitializeComponent();

            webView21.EnsureCoreWebView2Async();
        }

        private void WebView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.Source = new Uri(Path.Combine(
                Application.StartupPath, @"Monaco\Index.html"));

            webView21.CoreWebView2.AddHostObjectToScript("sample", _sample);
        }
    }
}
