using System.Windows;

namespace StudentManagementSystem
{
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

      private void SaveStudent_Click(object sender, RoutedEventArgs e)
{
    DatabaseHelper db = new DatabaseHelper();

    string name = txtName.Text;
    int age = int.Parse(txtAge.Text);
    string course = txtCourse.Text;

    db.AddStudent(name, age, course);

    MessageBox.Show("Student saved successfully!");
}
    }
}