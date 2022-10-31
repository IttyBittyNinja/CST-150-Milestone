using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _ABRAMS__CST_150_Milestone_2
{
    public partial class Form1 : Form
    {
        // Takes inventory file and initiate lists to reading/writing store inventory objects and printing to listbox
        string filePath = @"C:\Users\j4red\Downloads\Inventory.txt";
        List<string> lines = new List<string>();
        List<Inventory> stock = new List<Inventory>();
        List<string> outContents = new List<string>();


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Read from inventory.txt
            lines = File.ReadAllLines(filePath).ToList();

            // for each line, seperate each word by the "," and add each word to the stock list.
            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                Inventory i = new Inventory(items[0], items[1], items[2], items[3], items[4]);
                stock.Add(i);
            }

            // Print to headers to listbox
            listBoxOutput.Items.Add("Code" + "\t\t" + "Name" + "\t\t" + "Cost" + "\t\t" + "Quantity" + "\t\t" + "Category" + "\t\t");

            // Print items to listbox
            foreach (Inventory i in stock)
            {
                listBoxOutput.Items.Add(i.printFormat());
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void addnewButton_Click(object sender, EventArgs e)
        {
            // New Object
            Inventory i = new Inventory(codeInput.Text, nameInput.Text, costInput.Text, quantityInput.Text, categoryInput.Text);

            // Add new object to inventory file
            outContents.Add(i.fileFormat());
            String outFile = @"C:\Users\j4red\Downloads\Inventory.txt";
            File.AppendAllLines(outFile, outContents);

            // Add new object to listbox
            listBoxOutput.Items.Add(i.printFormat());

            lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                Inventory p = new Inventory(items[0], items[1], items[2], items[3], items[4]);
                stock.Add(i);
            }

            // Remove Object
            outContents.Clear();

            // Clear the TextBox controls.
            codeInput.Text = "";
            nameInput.Text = "";
            costInput.Text = "";
            quantityInput.Text = "";
            categoryInput.Text = "";

            // Reset the focus.
            codeInput.Focus();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the TextBox controls.
            codeInput.Text = "";
            nameInput.Text = "";
            costInput.Text = "";
            quantityInput.Text = "";
            categoryInput.Text = "";

            // Reset the focus.
            codeInput.Focus();
        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            // If Name radio button is checked, search name.
            if (radioButtonName.Checked)
            {
                listBoxOutput.ClearSelected();
            }
            // If Code radio button is checked, search code.
            else if (radioButtonCode.Checked)
            {
                listBoxOutput.ClearSelected();
            }

            // If no radio button is checked, prompt user to select a search option.
            else
            {
                MessageBox.Show("Select a Search Option");
            }
        }
    }
}