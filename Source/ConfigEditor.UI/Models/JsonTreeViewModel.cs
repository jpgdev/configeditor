using System.Windows;
using Newtonsoft.Json.Linq;

namespace ConfigEditor.UI.Models
{
    public class JsonTreeViewModel : DependencyObject
    {
        public static readonly DependencyProperty SourceJsonProperty = DependencyProperty.Register(
            nameof(SourceJson), 
            typeof(JObject), 
            typeof(JsonTreeViewModel), 
            new PropertyMetadata(default(JObject)));

        public JObject SourceJson
        {
            get => (JObject) GetValue(SourceJsonProperty);
            set => SetValue(SourceJsonProperty, value);
        }

        public JsonTreeViewModel(JObject sourceJson)
        {
            SourceJson = sourceJson;
        }
    }
}
