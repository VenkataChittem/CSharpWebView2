using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebView2Test3
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class Sample
    {
        public string Name { get; set; } = "meziantou";

        public int ClickCount { get; private set; }

        // Use [IndexerName] if you want to use an indexer from JavaScript
        [System.Runtime.CompilerServices.IndexerName("Items")]
        public int this[int index] => index;

        // Public methods are accessible from JS
        public void OnClick()
        {
            ClickCount++;
        }

        // Task is not supported as return type. You need to use Task<T>. Otherwise, you get errors such as:
        // 'System.Threading.Tasks.VoidTaskResult' cannot be marshalled to a Variant.
        public async Task<int> DelayAsync(int milliseconds)
        {
            await Task.Delay(milliseconds);
            return 0;
        }
    }
}
