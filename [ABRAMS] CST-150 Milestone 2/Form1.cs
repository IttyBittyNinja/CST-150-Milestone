using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _ABRAMS__CST_150_Milestone_2
{
    public partial class Form1 : Form
    {
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
            lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                Inventory i = new Inventory(items[0], items[1], items[2], items[3], items[4]);
                stock.Add(i);
            }
            listBoxOutput.Items.Add("Code" + "\t\t" + "Name" + "\t\t" + "Cost" + "\t\t" + "Quantity" + "\t\t" + "Category" + "\t\t");
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
                stock.Add(p);
            }

            foreach (Inventory p in stock)
            {
                listBoxOutput.Items.Add(p.printFormat());
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





            /*List<string> outContents = new List<string>();

            foreach (Inventory i in stock)
            {
                outContents.Add(i.fileFormat());
            }
            String outFile = @"C:\Users\j4red\Downloads\InventoryOut.txt";
            File.WriteAllLines(outFile, outContents);*/



            // Create Inventory object.
            //Inventory item = new Inventory();

            // Get the item data.
            //GetItemData(item);

            // Display the item data.
            //itemDisplayOutput.Items.Add(item.Code + "         " + item.Name + "         $" + item.Cost + "         " + item.Quantity + "         " + "         " + item.Category);
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
            if (radioButtonName.Checked)
            {
                listBoxOutput.ClearSelected();
                //var item = stock.Find(Name.searchInput.Text);
                //listBoxOutput.Items.Add(stock.Contains(searchInput.Text));
            }
            else if (radioButtonCode.Checked)
            {

            }
            else
            {
                MessageBox.Show("Select a Search Option");
            }
        }
    }
}