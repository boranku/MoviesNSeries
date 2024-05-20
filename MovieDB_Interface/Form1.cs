namespace MovieDB_Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteInsertQuery("formdan yeni geldi",2015,4.8);
        }
    }
}
