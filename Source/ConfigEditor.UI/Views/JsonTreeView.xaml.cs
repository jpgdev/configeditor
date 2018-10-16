using System.Windows;
using System.Windows.Controls;
using ConfigEditor.UI.Models;

namespace ConfigEditor.UI.Views
{
    public partial class JsonTreeView : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(
            nameof(Model), 
            typeof(JsonTreeViewModel), 
            typeof(JsonTreeView), 
            new PropertyMetadata(default(JsonTreeViewModel)));

        public JsonTreeViewModel Model
        {
            get => (JsonTreeViewModel) GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }

        public JsonTreeView()
        {
            InitializeComponent();
            
            DataContext = this;
        }
    }
}
