using System.ComponentModel;
using System.Windows;
using CommandPermissions.Commands;

namespace CommandPermissions
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, ISecurityCommand
    {
        private string text1;
        private string text2;
        
        public string Text1 { 
            get { return text1; }
            set
            {
                if(value == text1) return;
                text1 = value;
               OnPropertyChanged(nameof(Text1));
             
            } 
        } 

        public string Text2 { 
            get { return text2; }
            set
            {
                if(value == text2) return;
                text2 = value;
                OnPropertyChanged(nameof(Text2));
            } 
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MyCustomCommand Command1 { get; set; }
        public MyCustomCommand Command2 { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Command1 = new MyCustomCommand(execute: AnAction);
            Command2 = new MyCustomCommand(execute: OtherAction);
            this.DataContext = this;
            OnStart();
        }

        public void AnAction()
        {
            Text1 = "Alguna acción ejecutada";
            OnUpdate();
        }

        public void OtherAction()
        {
            Text2 = "Alguna acción ejecutada con otros permisos";
        }

        public void OnStart()
        {
            SecurityCommand.Add(Command1, new []{1,2,3});
            SecurityCommand.Add(Command2, new []{4,5,6});
        }

        public void OnUpdate()
        {
            SecurityCommand.Add(Command1, new []{1,2,3});
            SecurityCommand.Add(Command2, new []{3});
        }
    }
}
