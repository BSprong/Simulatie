using LifeSimulation;
using System.Windows.Forms;
using UserManager;
using ReportManager;
using LifeSimulation.SimObjects;

namespace Life
{
    public partial class MainForm : Form
    {
        public ILifeApplication LifeApplication{ get; set; }
        public IUserManager UserManager{ get; set; }
        public IReportManager ReportManager{ get; set; }

        public MainForm()
        {
            InitializeComponent();

           
            LifeApplication = new LifeApplication();
            UserManager = new UserManager.UserManager();

            
            LifeApplication.CreateLayout("Layout 1", 200);
      
            Layout1 l1 = new Layout1(LifeApplication.Layouts[0]);

        }

        private void afsluitenMainMenu_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void startSimulatieToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();

            if (sf.DialogResult == DialogResult.OK)
            {

               
                ILifeSimulation simulation = new LifeSimulation.LifeSimulation(LifeApplication.Layouts[0], sf.nElements, LifeApplication.GetSpecies(), sf.plants, sf.carnivores, sf.herbivores, sf.omnivores, sf.nonivores, sf.obstacles, 100);
              
                LifeApplication.AddSimulation(simulation);

            
                SimulationForm simForm = new SimulationForm(simulation);
                simForm.MdiParent = this;
                simForm.Show();
            }  
        }
    }
}
