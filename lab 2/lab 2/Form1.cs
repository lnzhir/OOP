using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab_2
{
    public partial class Form1 : Form
    {
        private string[] attributes1 = { "Level", "Role" };
        private string[] attributes2 = { "Experience", "Attitude" };
        private Function[][] functions =
        {
            new Function[] {
                new Function("Spawn", new string[] {}),
                new Function("Heal", new string[] {}),
                new Function("Death", new string[] {}),
                new Function("Sleep", new string[] {"Hours"}),
                new Function("LevelUp", new string[] {}),
                new Function("AddExperience", new string[] {"Value"}),
            },
            new Function[] {
                new Function("Spawn", new string[] {}),
                new Function("Heal", new string[] {}),
                new Function("Death", new string[] {}),
                new Function("Sleep", new string[] {"Hours"}),
                new Function("Say", new string[] {"What"}),
                new Function("Panic", new string[] {}),
            },
        };
        private Character curChar = null;
        private int classType = 0;


        public Form1()
        {
            InitializeComponent();

            splitContainerMain.Panel2.Hide();
            UpdateListBoxes();
        }

        private void UpdateListBoxes()
        {
            listBoxPC.Items.Clear();
            foreach (PlayerCharacter p in DBProvider.GetPlayers())
            {
                listBoxPC.Items.Add(p);
            }

            listBoxNPC.Items.Clear();
            foreach (NonPlayerCharacter npc in DBProvider.GetNonPlayers())
            {
                listBoxNPC.Items.Add(npc);
            }
        }

        private void UpdateData()
        {
            if (curChar != null)
            {
                if (classType == 0)
                {
                    DBProvider.ChangePlayer((PlayerCharacter)curChar);
                }
                else
                {
                    DBProvider.ChangeNonPlayer((NonPlayerCharacter)curChar);
                }
            }
        }

        private void SelectClass(int index)
        {
            classType = index;
            labelAttribute1.Text = attributes1[index];
            labelAttribute2.Text = attributes2[index];

            comboBoxFunctions.Items.Clear();
            foreach (Function i in functions[index]) {
                comboBoxFunctions.Items.Add(i.name);
            }
            comboBoxFunctions.SelectedIndex = 0;
        }

        private void UpdateDataPanel()
        {
            textBoxName.Text = curChar.Name;
            textBoxHealth.Text = curChar.Health.ToString();
            if (classType == 0)
            {
                textBoxAttribute1.Text = ((PlayerCharacter)curChar).Level.ToString();
                textBoxAttribute2.Text = ((PlayerCharacter)curChar).Experience.ToString();
            }
            else
            {
                textBoxAttribute1.Text = ((NonPlayerCharacter)curChar).Role;
                textBoxAttribute2.Text = ((NonPlayerCharacter)curChar).Attitude.ToString();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            switch (comboBoxFunctions.SelectedIndex)
            {
                case 0:
                    curChar.Spawn();
                    break;
                case 1:
                    curChar.Heal();
                    break;
                case 2:
                    curChar.Death();
                    break;
                case 3:
                    curChar.Sleep(int.Parse(dataGridParams.Rows[0].Cells[1].Value.ToString()));
                    break;
                case 4:
                    if (classType == 0)
                    {
                        ((PlayerCharacter)curChar).LevelUp();
                    }
                    else
                    {
                        ((NonPlayerCharacter)curChar).Say(dataGridParams.Rows[0].Cells[1].Value.ToString());
                    }
                    break;
                case 5:
                    if (classType == 0)
                    {
                        ((PlayerCharacter)curChar).AddExperience(int.Parse(dataGridParams.Rows[0].Cells[1].Value.ToString()));
                    }
                    else
                    {
                        ((NonPlayerCharacter)curChar).Panic();
                    }
                    break;
            }
            textBoxMessage.Text = curChar.Message;
            UpdateDataPanel();
        }

        private void comboBoxFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int index = comboBoxFunctions.SelectedIndex;

            dataGridParams.Rows.Clear();
            foreach (string paramName in functions[classType][index].parameters)
            {
                dataGridParams.Rows.Add(paramName, "");
            }
        }

        private void listBoxPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox.Focused && listBox.SelectedIndex >= 0)
            {
                curChar = (PlayerCharacter)listBox.SelectedItem;

                SelectClass(0);
                UpdateDataPanel();
                splitContainerMain.Panel2.Show();
            }
        }

        private void listBoxNPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox.Focused && listBox.SelectedIndex >= 0)
            {
                curChar = (NonPlayerCharacter)listBox.SelectedItem;

                SelectClass(1);
                UpdateDataPanel();
                splitContainerMain.Panel2.Show();
            }
        }

        private void buttonAddPC_Click(object sender, EventArgs e)
        {
            DBProvider.AddPlayer(new PlayerCharacter("New character", 100));
            UpdateListBoxes();
            listBoxPC.SelectedIndex = listBoxPC.Items.Count - 1;
        }

        private void buttonRemovePC_Click(object sender, EventArgs e)
        {
            DBProvider.DeletePlayer((PlayerCharacter)listBoxPC.SelectedItem);

            int index = listBoxPC.SelectedIndex;
            listBoxPC.Items.RemoveAt(listBoxPC.SelectedIndex);
            if (index > 0)
                listBoxPC.SelectedIndex = index - 1;
            else if (listBoxPC.Items.Count > 0)
            {
                listBoxPC.SelectedIndex = 0;
            }
            else
            {
                splitContainerMain.Panel2.Hide();
            }
        }

        private void buttonAddNPC_Click(object sender, EventArgs e)
        {
            DBProvider.AddNonPlayer(new NonPlayerCharacter("New character", 100));
            UpdateListBoxes();
            listBoxNPC.SelectedIndex = listBoxNPC.Items.Count - 1;
        }

        private void buttonRemoveNPC_Click(object sender, EventArgs e)
        {
            DBProvider.DeleteNonPlayer((NonPlayerCharacter)listBoxNPC.SelectedItem);

            int index = listBoxNPC.SelectedIndex;
            listBoxNPC.Items.RemoveAt(listBoxNPC.SelectedIndex);
            if (index > 0)
                listBoxNPC.SelectedIndex = index - 1;
            else if (listBoxNPC.Items.Count > 0)
            {
                listBoxNPC.SelectedIndex = 0;
            } 
            else
            {
                splitContainerMain.Panel2.Hide();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox textBox = sender as MaskedTextBox;
            if (textBox != null && textBox.Focused)
            {
                curChar.Name = textBox.Text;
                if (listBoxPC.SelectedIndex >= 0)
                {
                    listBoxPC.Items[listBoxPC.SelectedIndex] = listBoxPC.Items[listBoxPC.SelectedIndex];
                }
                if (listBoxNPC.SelectedIndex >= 0)
                {
                    listBoxNPC.Items[listBoxNPC.SelectedIndex] = listBoxNPC.Items[listBoxNPC.SelectedIndex];
                }
            }
        }

        private void textBoxHealth_TextChanged(object sender, EventArgs e)
        {
            curChar.Health = int.Parse(((MaskedTextBox)sender).Text.ToString());
        }

        private void textBoxAttribute1_TextChanged(object sender, EventArgs e)
        {
            if (classType == 0)
            {
                ((PlayerCharacter)curChar).Level = int.Parse(((MaskedTextBox)sender).Text.ToString());
            }
            else
            {
                ((NonPlayerCharacter)curChar).Role = ((MaskedTextBox)sender).Text;
            }
        }

        private void textBoxAttribute2_TextChanged(object sender, EventArgs e)
        {
            if (classType == 0)
            {
                ((PlayerCharacter)curChar).Experience = int.Parse(((MaskedTextBox)sender).Text.ToString());
            }
            else
            {
                ((NonPlayerCharacter)curChar).Attitude = int.Parse(((MaskedTextBox)sender).Text.ToString());
            }
        }

        private void listBoxPC_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateData();
        }

        private void listBoxNPC_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateData();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }

    public struct Function
    {
        public string name;
        public string[] parameters;

        public Function(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }
    }
}
