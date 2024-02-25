
namespace ViewCs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.String  message = TextBox1.Text;
            int result;
            SampleWrapper.Common.SampleDocument objWrapper = new SampleWrapper.Common.SampleDocument();

            objWrapper.setMessage(message);
            result = objWrapper.countAlphabet();
            MessageBox.Show("文字列中のアルファベットの個数は " + result);
        }
    }

}