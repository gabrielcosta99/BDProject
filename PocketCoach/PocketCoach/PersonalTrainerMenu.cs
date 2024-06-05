using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketCoach
{
    public partial class PersonalTrainerMenu : Form
    {
        public PersonalTrainerMenu()
        {
            InitializeComponent();
        }

        private void PersonalTrainerMenu_Load(object sender, EventArgs e)
        {

        }

        private void bttnCreateWorkout_Click(object sender, EventArgs e)
        {
            Form workoutCreate = new CreateWorkout();
            workoutCreate.Show();
            this.Hide();
        }

        private void bttnChat_Click(object sender, EventArgs e)
        {
            Form chat = new ChooseSomeoneToChat();
            chat.Show();
            this.Hide();

        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form exerciseCreate = new CreateExercise();
            exerciseCreate.Show();
            this.Hide();
        }
    }
}
