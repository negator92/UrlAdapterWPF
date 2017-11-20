using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace UrlAdapterWPF
{
    public class ApplicationViewModel : PropertyChangedClass
    {
        public string InUrl { get; set; }
        public string OutUrl { get; set; } = "After pressing Adapt it would be filled with correct url";
        public ICommand AdaptCommand { get; set; }

        public ApplicationViewModel()
        {
            AdaptCommand = new RelayCommand(AdaptUrl, f => !(string.IsNullOrEmpty(InUrl) && string.IsNullOrWhiteSpace(InUrl)));
        }

        private void AdaptUrl(object obj)
        {
            try
            {
                int httpLastIndex = InUrl.LastIndexOf("http");
                OutUrl = InUrl.Substring(httpLastIndex, (InUrl.Contains(".html")
                    ? (InUrl.IndexOf(".html") + 5 - httpLastIndex)
                    : InUrl.Length - httpLastIndex)).Replace("%3A", ":").Replace("%2F", "/");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}