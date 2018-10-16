using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ConfigEditor.Logging;
using ConfigEditor.UI.Models;
using Newtonsoft.Json;
using Prism.Commands;

namespace ConfigEditor.UI
{
    public partial class MainWindow : Window
    {
        #region Constants

        private readonly DelegateLoggerFactory m_loggerFactory;

        #endregion

        #region Fields

        private readonly ILogger m_logger;

        #endregion

        #region DependencyProperties 

        public static readonly DependencyProperty JsonProperty = DependencyProperty.Register(
            nameof(Json),
            typeof(string),
            typeof(MainWindow),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ConvertToJsonCommandProperty = DependencyProperty.Register(
            nameof(ConvertToJsonCommand),
            typeof(ICommand),
            typeof(MainWindow),
            new PropertyMetadata(default(ICommand))); 

        public static readonly DependencyProperty ConvertToTextCommandProperty = DependencyProperty.Register(
            nameof(ConvertToTextCommand), 
            typeof(ICommand), 
            typeof(MainWindow), 
            new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty LogLinesProperty = DependencyProperty.Register(
            nameof(LogLines),
            typeof(ObservableCollection<string>),
            typeof(MainWindow),
            new PropertyMetadata(new ObservableCollection<string>()));


        #endregion

        #region Properties

        public string Json
        {
            get => (string)GetValue(JsonProperty);
            set => SetValue(JsonProperty, value);
        }

        public ICommand ConvertToJsonCommand
        {
            get => (ICommand)GetValue(ConvertToJsonCommandProperty);
            set => SetValue(ConvertToJsonCommandProperty, value);
        }

        public ICommand ConvertToTextCommand
        {
            get => (ICommand) GetValue(ConvertToTextCommandProperty);
            set => SetValue(ConvertToTextCommandProperty, value);
        }
     
        public ObservableCollection<string> LogLines
        {
            get => (ObservableCollection<string>) GetValue(LogLinesProperty);
            set => SetValue(LogLinesProperty, value);
        }

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            m_loggerFactory = new DelegateLoggerFactory(Log);
            m_logger = m_loggerFactory.CreateLogger(this);

            ConvertToJsonCommand = new DelegateCommand(ConvertToJson);
            ConvertToTextCommand = new DelegateCommand(ConvertToText);

            /////////////////
            //TODO: Remove this, for testing purposes
            Json = @"{
                       'a' : 123,
                       'B' : 'Hdsfsf',
                       'C' : {
                         'C1' : 1,
                         'C2' : 'Test'
                       },
                       'D' : [ 1, 2, 3, 4, 5]
                     }";

            ConvertToJson();

            LogLines.Add("Test");
            LogLines.Add("Test");
            LogLines.Add("Test");
            LogLines.Add("Test");
            LogLines.Add("Test");
            LogLines.Add("Test");
            LogLines.Add("Test");

            //////////////////
        } 

        #endregion

        #region Public methods

        public void ConvertToJson()
        {
            m_logger.TraceDebug("Converting to JSON...");

            try
            {
                var source = new JsonParser(m_loggerFactory).Parse(Json);
                MainJsonTreeView.Model = new JsonTreeViewModel(source);
            }
            catch (Exception ex)
            {
                m_logger.TraceError(ex, "There was an error while converting text to JSON");
            }
        }

        public void ConvertToText()
        {
            m_logger.TraceDebug("Converting to Text...");

            try
            {
                Json = MainJsonTreeView.Model.SourceJson.ToString(Formatting.Indented);
            }
            catch (Exception ex)
            {
                m_logger.TraceError(ex, "There was an error while converting JSON to Text");
            }
        } 

        #endregion

        #region Private methods

        private void Log(LogData logData)
        {
            var line = $"[{logData.TimeStamp:HH:mm:ss.zzz}][{logData.LoggerName}][{logData.Level}] - {logData.Message}";

            if (logData.Exception != null)
            {
                line += $"\n{logData.Exception.Message}\n{logData.Exception.StackTrace}";
            }

            LogLines.Add(line);
        } 

        #endregion
    }
}
