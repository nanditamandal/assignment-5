using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student
{
    public partial class Student : Form
    {
        

        List<string> id = new List<string> { };
        List<string> name = new List<string> { };
        List<string> mobile = new List<string> { };
        List<string> age = new List<string> { };
        List<string> address = new List<string> { };
        List<string> gpa = new List<string> { };

        List<string> add = new List<string> { };

        int index = 0;
        string value = "";
       // string max;

        public Student()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        { 
           
            if(Validetion()==true)
            {


                id.Add(idTextBox.Text);
                name.Add(nameTextBox.Text);
                mobile.Add(mobileTextBox.Text);
                age.Add(ageTextBox.Text);
                address.Add(addressTextBox.Text);
                gpa.Add(gpaTextBox.Text);

                value += "id\t" + id[index] + Environment.NewLine +
                    "name\t" + name[index] + Environment.NewLine +
                    "mobile\t" + mobile[index] + Environment.NewLine +
                    "age\t" + age[index] + Environment.NewLine +
                    "address\t" + address[index] + Environment.NewLine +
                    "gpa\t" + gpa[index] + Environment.NewLine;
                
                add.Add(value);


                index++;
                 Cleartextbox(); 
            }


        }
           
        private bool Validetion()
        {
            string tname = nameTextBox.Text;
            string tid = idTextBox.Text;
            string tmobile = mobileTextBox.Text;
            string tage = ageTextBox.Text;
            string taddress = addressTextBox.Text;
            string tgpa = gpaTextBox.Text;


            if (tid == "")
            {
                MessageBox.Show("id can not empty ");
                return false;
            }
            if ( tid.Length >4 )
            {
                MessageBox.Show(" length can not be more then 4 character");
                return false;
            }
            if ( Checkid() == false)
            {
                MessageBox.Show(" duplicate id");
                return false;
            }


            if (tname == "" )
            {
                MessageBox.Show("name can not empty");
                return false;
            }
            if (tname.Length > 30)
            {
                MessageBox.Show(" length can not more then 30 character");
                return false;
            }

            if (tmobile == "" )
            {
                MessageBox.Show("mobile can not empty ");
                return false;
            }
            if (tmobile.Length < 4)
            {
                MessageBox.Show("mobile must be 4 character length");
                return false;
            }
            if (tmobile.Length > 11)
            {
                MessageBox.Show("mobile must be 11 character length");
                return false;
            }
            if (Checku() == false)
            {
                MessageBox.Show(" duplicate number");
                return false;
            }
            if (taddress == "")
            {
                MessageBox.Show("address can not empty");
                return false;

            }
            if (tage == "")
            {
                MessageBox.Show("age  can not empty");
                return false;

            }
            if (tage.Length>3)
            {
                MessageBox.Show("lenght not more then 3 digit");
                return false;

            }
            if (tgpa == "")
            {
                MessageBox.Show("gpa can not empty ");
                return false;

            }
            if (Gpacheck() == false)
            {
                MessageBox.Show(" 0- 4 scale");
                return false;

            }
            return true;
        }

        private void Cleartextbox()
        {
            nameTextBox.Text = "";
            idTextBox.Text = "";
            mobileTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            gpaTextBox.Text = "";
        }
        private bool Gpacheck()
        {
            string tgpa = gpaTextBox.Text;
            double checkgpa = Convert.ToDouble(tgpa);
            if (checkgpa > 4.00)
            {
                return false;
            }
            return true;

        }

        private bool Checku()
        {
            string tempmobile = mobileTextBox.Text;
            for (int i = 0; i < mobile.Count; i++)
            {
                if (tempmobile == mobile[i])
                {
                    return false;
                }
            }
            return true;
        }
        private bool Checkid()
        {
            string tempid = idTextBox.Text;
            for (int i = 0; i < id.Count; i++)
            {
                if (tempid == id[i])
                {
                    return false;
                }

            }
            return true;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < add.Count; i++)
            {
                displayrichTextBox.Text = add[i];
                Maximumgpa();
                Minimumgpa();
                Average();
            }

        }
        private void Maximumgpa()
        {
            double large = 0.0;
            string maxname="";
            for(int i=0; i<gpa.Count; i++)
            {
                if(large<Convert.ToDouble(gpa[i]))
                {
                    large = Convert.ToDouble(gpa[i]);
                    maxname = name[i];
                }
                maxtextBox.Text = Convert.ToString(large);
                maxnametextBox.Text = maxname;
            }
        }
       private void Minimumgpa()
        {
            double low= 5.00;
            string minname = "";
            for (int i = 0; i < gpa.Count; i++)
            {
                if (low > Convert.ToDouble(gpa[i]))
                {
                    low = Convert.ToDouble(gpa[i]);
                    minname = name[i];
                }
                mintextBox.Text = Convert.ToString(low);
                minnametextBox.Text = minname;
            }

        }
        private void Average()
        {
            double ave = 0;
            double total = 0;
            double count = 0;
            for(int i=0; i<gpa.Count; i++)
            {
                total += Convert.ToDouble(gpa[i]);
                count++;

            }
            ave = total / count;
            totaltextBox.Text = Convert.ToString(total);
            avetextBox.Text = Convert.ToString(ave);
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            Idsearch();
            Namesearch();
            Mobilesearch();
        }
        private void Idsearch()
        {
            if (idradioButton.Checked == true)
            {
                string tid = "";
                string value = "";
                tid = idTextBox.Text;
                for (int i = 0; i < id.Count; i++)
                {
                    if (tid == id[i])
                    {
                        value += "id\t"+id[i] +"name\t"+ name[i] +"age\t"+ age[i] +"mobile\t"+ mobile[i]+ 
                            "gpa\t"+ gpa[i]+"address\t" + address[i];
                    }
                }
                if (value == "")
                {
                    displayrichTextBox.Text = "id is not found..";
                }
                else
                {
                    displayrichTextBox.Text = value;
                }
            }
        }
        private void Namesearch()
        {
            if (nameradioButton.Checked == true)
            {
                string tname = "";
                string value = "";
                tname = nameTextBox.Text;
                for (int i = 0; i < name.Count; i++)
                {
                    if (tname == name[i])
                    {
                        value += "id\t" + id[i] + "name\t" + name[i] + "age\t" + age[i] + "mobile\t" + mobile[i] +
                           "gpa\t" + gpa[i] + "address\t" + address[i];
                    }
                }
                if (value == "")
                {
                    displayrichTextBox.Text = "name is not found..";
                }
                else
                {
                    displayrichTextBox.Text = value;
                }
            }
        }
        private void Mobilesearch()
        {
            if (mobileradioButton.Checked == true)
            {
                string tmobile = "";
                string value = "";
                tmobile = mobileTextBox.Text;
                for (int i = 0; i < mobile.Count; i++)
                {
                    if (tmobile == mobile[i])
                    {
                        value += "id\t" + id[i] + "name\t" + name[i] + "age\t" + age[i] + "mobile\t" + mobile[i] +
                           "gpa\t" + gpa[i] + "address\t" + address[i];
                    }
                }
                if (value == "")
                {
                    displayrichTextBox.Text = "name is not found..";
                }
                else
                {
                    displayrichTextBox.Text = value;
                }
            }
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gpaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
