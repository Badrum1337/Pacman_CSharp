using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace Pacmanv2
{
    public partial class highscore : Form
    {
        public highscore()
        {
            InitializeComponent();
        }
        List<Highscores> scores = new List<Highscores>();
        private void highscore_Load(object sender, EventArgs e)
        {
            GetHighScore();
            // Skriver ut lite symboler i "knapparna" för att förtydliga användnignsområde
            sortScoreRev.Text += char.ConvertFromUtf32(8595);
            sortScore.Text += char.ConvertFromUtf32(0x00002191);
            sortTime.Text += char.ConvertFromUtf32(0x00002191);
            sortTimeRev.Text += char.ConvertFromUtf32(8595);
        }
        /// <summary>
        /// Hämtar data från en json fil som ligger på labbservern
        /// </summary>
        private void GetHighScore()
        {
            // Försök att hämta datan från JSON filen, om det inte går ska ett felmeddelande öppnas utan att programmet kraschar
            try
            {
                // Hämtar all data i json-filen
                string json = (new WebClient()).DownloadString("http://labb.vgy.se/~adamhg/prog/pacman.json");
                // Lägger in json-objekten i en lista som består utav en likadan c#-class. DVS json-filen innehåller name, score, time och c#-klassen gör det också
                scores = JsonConvert.DeserializeObject<List<Highscores>>(json);
                // Sorterar listan med hjälp av linq för att på den med högst poäng först
                List<Highscores> high = scores.OrderBy(o => o.score).Reverse().ToList();
                for (int i = 0; i < high.Count; i++)
                {
                    // Skriver ut alla namn, poäng och tid i en listview
                    string time = TimeSpan.FromSeconds(high[i].time).ToString("mm\\:ss");
                    string[] row = new string[] { (i + 1).ToString(), high[i].name, high[i].score.ToString(), time };
                    ListViewItem lvi = new ListViewItem(row);
                    highscoreList.Items.Add(lvi);
                }
                // Sätter så att columnerns bredd anpassar sig efter den största datan
                foreach (ColumnHeader x in highscoreList.Columns)
                {
                    x.Width = -2;
                }
                // Tar bort scroll
                highscoreList.Scrollable = false;
            }
            catch (Exception f)
            {
                MessageBox.Show("There was an error fetching the score " + f.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                throw f;
            }

            
        }

        /// <summary>
        /// Stänger fönstret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sorterar listan enligt alfabetisk ordning (A först)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortAlph_Click(object sender, EventArgs e)
        {
            List<Highscores> sortedAlph = scores.OrderBy(o => o.name).ToList();
            UpdateHighscore(sortedAlph);
        }
        /// <summary>
        /// Sorterar listan i omvänd alfabetisk ordning (Z först)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortAlphRev_Click(object sender, EventArgs e)
        {
            List<Highscores> sortedAlphRev = scores.OrderBy(o => o.name).Reverse().ToList();
            UpdateHighscore(sortedAlphRev);
        }

        /// <summary>
        /// Sorterar listan i poäng, störst först
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortScore_Click(object sender, EventArgs e)
        {
            List<Highscores> sortedScore = scores.OrderBy(o => o.score).Reverse().ToList(); // Linq retunerar en lista med minst först, så därför måste man vända på den (Reverse)
            UpdateHighscore(sortedScore);
        }

        /// <summary>
        /// Sorterar listan i poäng, minst först
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortScoreRev_Click(object sender, EventArgs e)
        {
            List<Highscores> sortedScoresRev = scores.OrderBy(o => o.score).ToList();
            UpdateHighscore(sortedScoresRev);
        }

        /// <summary>
        /// Sortar listan i tid, snabbast först
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortTime_Click(object sender, EventArgs e)
        {
            List<Highscores> sortedTime = scores.OrderBy(o => TimeSpan.FromMinutes(o.time)).ToList();
            UpdateHighscore(sortedTime);
        }

        /// <summary>
        /// Sorterar listan i tid, långsammast först
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortTimeRev_Click(object sender, EventArgs e)
        {
            List<Highscores> sortedTimeRev = scores.OrderBy(o => TimeSpan.FromMinutes(o.time)).Reverse().ToList();
            UpdateHighscore(sortedTimeRev);
        }
        /// <summary>
        /// Uppdaterar listan med vilked slags sortering vi ville ha
        /// </summary>
        /// <param name="sorted"></param>
        private void UpdateHighscore(List<Highscores> sorted)
        {
            highscoreList.Items.Clear();
            for (int i = 0; i < sorted.Count; i++)
            {
                string time = TimeSpan.FromSeconds(sorted[i].time).ToString("mm\\:ss");
                string [] row = new string[] { (i + 1).ToString(), sorted[i].name, sorted[i].score.ToString(), time };
                ListViewItem lvi = new ListViewItem(row);
                highscoreList.Items.Add(lvi);
            }
            foreach (ColumnHeader x in highscoreList.Columns)
            {
                x.Width = -2;
            }
        }
    }
    /// <summary>
    /// En klass för json filens data. Detta gör så att man lätt kan komma åt t.ex. namnet på spelaren 
    /// </summary>
    public class Highscores
    {
        [JsonProperty("name")]
        public string name { get; set; } // Spelarens namn
        [JsonProperty("score")]
        public int score { get; set; } // Spelarens poäng
        [JsonProperty("time")]
        public int time { get; set; } // Spelarens tid
    }
}
