using System.Windows;

namespace StudentManagementSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DatabaseHelper db = new DatabaseHelper();
            db.InitializeDatabase();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent window = new AddStudent();
            window.Show();
        }

        private void ViewStudents_Click(object sender, RoutedEventArgs e)
        {
            ViewStudents window = new ViewStudents();
            window.Show();
        }
    }
}
