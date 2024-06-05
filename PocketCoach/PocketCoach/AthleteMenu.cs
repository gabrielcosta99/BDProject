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
    public partial class AthleteMenu : Form
    {
        public AthleteMenu()
        {
            InitializeComponent();
        }

        private void AthleteMenu_Load(object sender, EventArgs e)
        {

        }

        private void bttnSubscriptions_Click(object sender, EventArgs e)
        {
            Form subscriptions = new Subscriptions();
            subscriptions.Show();
            this.Hide();
        }

        private void bttnWorkouts_Click(object sender, EventArgs e)
        {
            Form workouts = new Workouts();
            workouts.Show();
            this.Hide();
        }


        private void bttnMyProgress_Click(object sender, EventArgs e)
        {
            Form progress = new AthleteWorkoutProgress();
            progress.Show();
            this.Hide();
        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            Form userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void bttnChat_Click(object sender, EventArgs e)
        {
            Form choosePT = new ChooseSomeoneToChat();
            choosePT.Show();
            this.Hide();
        }
    }
}
