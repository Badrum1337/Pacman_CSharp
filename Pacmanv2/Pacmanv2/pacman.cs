// Adam Haneling 16-04-2021
// v3: Ritat ut maten och fått pacman att röra sig inom "gatorna", men har inte riktigt fått pacman att kunna åka första möjliga högre när man klickar höger. Nästa vecka blir det att göra klart det och börja med poängräkningen. Spelet "spelas" i en 2d array med nummer beronde på vad som ligger på den rutan. Sedan ritar jag upp 2d arrayen med bilder så att man får en visuel reprensentation. Detta gör jag genom att ha en 2d array som är spelplanens bredd / pacmans bredd bred och spelplanens höjd/pacmans höjd hög, dvs 27 bred och 30 hög
//v4: Har lagt till kommentarer och har fixat förra veckans bugg med förflyttningen. Har även fixat kollision med mat och ökandet av poängen. Har även hittat och fixat en ny bugg vilket var att man kunde hålla inne knappen man ville gå åt för att få pacman att åka snabbare.
// v5: Har lagt till spöken och de kan röra sig men har inte gjort så att de kan åka i banorna
// v6: Fixat spöken och deras movements. Även fixad global highscore lista och hjälp-ruta som hanteras av PHP-script och JSON fil som ligger på labbservern. Spökerna rör sig snabbare för varje klarad nivå och de rör sig långsammare efter att Pacman har ätit. Har även lagt till en frukt som ger bonuspoäng.
// Kända buggar: Ibland, men sällan, kan pacman åka igenom spöket utan att det äts, anledningen till detta kan vara för att timerna som flyttar spöket inte riktigt är samma och det kan påverka spelet.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;

namespace Pacmanv2
{
    public partial class Form1 : Form
    {
        public int score = 0;
        public int amountOfFood = 0;
        public int[,] map = new int[30, 27];
        public PictureBox[] livesPb = new PictureBox[10];
        public PictureBox[,] foodImages = new PictureBox[30, 27];
        public int imageOn = 0;
        public int pacStartX = 0;
        public int pacStartY = 0;
        public int currentDirection;
        public int nextDirection;
        public int cordX = 0;
        public int cordY = 0;
        public bool isPowered = false;
        public Keys keyPressed;
        public PictureBox[] ghostImage = new PictureBox[4];
        private Ghost[] ghosts = new Ghost[4];
        private bool scaredOn = false;
        private bool turningOn = false;
        private bool endBool = false;
        public Random random = new Random();
        public int scaredCounter = 0;
        public int amount = 1;
        public int lives = 3;
        public int releaseGhost = 0;
        public int seconds = 0;
        public int timeScore = 0;
        public string playerName;
        public static readonly WebClient client = new WebClient();
        public int fruit = 0;
        List<Fruit> fruits = new List<Fruit>();
        public int lvl = 0;
        public bool eatenFruit = false;


        public Form1()
        {
            InitializeComponent();
            AddPacman();
            AddGhost();
            AddFruits();
            StartGame();
        }
        /// <summary>
        /// Lägger till alla pacmans olika bilder i en imagelist
        /// </summary>
        private void AddPacman()
        {
            pacman.Images.Add(Properties.Resources.pacmanClosed);
            pacman.Images.Add(Properties.Resources.pacmanUp_Half);
            pacman.Images.Add(Properties.Resources.pacmanUp_Open);
            pacman.Images.Add(Properties.Resources.pacmanUp_Half2);

            pacman.Images.Add(Properties.Resources.pacmanClosed);
            pacman.Images.Add(Properties.Resources.pacmanLeft_Half);
            pacman.Images.Add(Properties.Resources.pacmanLeft_Open);
            pacman.Images.Add(Properties.Resources.pacmanLeft_Half2);

            pacman.Images.Add(Properties.Resources.pacmanClosed);
            pacman.Images.Add(Properties.Resources.pacmanDown_Half);
            pacman.Images.Add(Properties.Resources.pacmanDown_Open);
            pacman.Images.Add(Properties.Resources.pacmanDown_Half2);

            pacman.Images.Add(Properties.Resources.pacmanClosed);
            pacman.Images.Add(Properties.Resources.pacmanRight_Half);
            pacman.Images.Add(Properties.Resources.pacmanRight_Open);
            pacman.Images.Add(Properties.Resources.pacmanRight_Half2);
            pacman.ImageSize = new Size(27, 28);
        }

        /// <summary>
        /// Lägger till alla spökbilder i imagelists
        /// </summary>
        private void AddGhost()
        {

            ghostImages.Images.Add(Properties.Resources.RedGost);
            ghostImages.Images.Add(Properties.Resources.RedGosUp1);
            ghostImages.Images.Add(Properties.Resources.RedGosUp2);
            ghostImages.Images.Add(Properties.Resources.RedGosRight1);
            ghostImages.Images.Add(Properties.Resources.RedGosRight2);
            ghostImages.Images.Add(Properties.Resources.RedGosDown1);
            ghostImages.Images.Add(Properties.Resources.RedGosDown2);
            ghostImages.Images.Add(Properties.Resources.RedGosLeft1);
            ghostImages.Images.Add(Properties.Resources.RedGosLeft2);

            ghostImages.Images.Add(Properties.Resources.BlueGhost);
            ghostImages.Images.Add(Properties.Resources.BlueGhostUp1);
            ghostImages.Images.Add(Properties.Resources.BlueGhostUp2);
            ghostImages.Images.Add(Properties.Resources.BlueGhostRight1);
            ghostImages.Images.Add(Properties.Resources.BlueGhostRight2);
            ghostImages.Images.Add(Properties.Resources.BlueGhostDown1);
            ghostImages.Images.Add(Properties.Resources.BlueGhostDown2);
            ghostImages.Images.Add(Properties.Resources.BlueGhostLeft1);
            ghostImages.Images.Add(Properties.Resources.BlueGhostLeft2);

            ghostImages.Images.Add(Properties.Resources.PinkGost);
            ghostImages.Images.Add(Properties.Resources.PinkGostUp1);
            ghostImages.Images.Add(Properties.Resources.PinkGostUp2);
            ghostImages.Images.Add(Properties.Resources.PinkGostRight1);
            ghostImages.Images.Add(Properties.Resources.PinkGostRight2);
            ghostImages.Images.Add(Properties.Resources.PinkGostDown1);
            ghostImages.Images.Add(Properties.Resources.PinkGostDown2);
            ghostImages.Images.Add(Properties.Resources.PinkGostLeft1);
            ghostImages.Images.Add(Properties.Resources.PinkGostLeft2);

            ghostImages.Images.Add(Properties.Resources.YellowGost);
            ghostImages.Images.Add(Properties.Resources.YellowGostUp1);
            ghostImages.Images.Add(Properties.Resources.YellowGostUp2);
            ghostImages.Images.Add(Properties.Resources.YellowGostRight1);
            ghostImages.Images.Add(Properties.Resources.YellowGostRight2);
            ghostImages.Images.Add(Properties.Resources.YellowGostDown1);
            ghostImages.Images.Add(Properties.Resources.YellowGostDown2);
            ghostImages.Images.Add(Properties.Resources.YellowGostLeft1);
            ghostImages.Images.Add(Properties.Resources.YellowGostLeft2);

            ghostImages.ImageSize = new Size(27, 28);

            scaredGhost.Images.Add(Properties.Resources.BonusBGhost1);
            scaredGhost.Images.Add(Properties.Resources.BonusWGhost1);
            scaredGhost.Images.Add(Properties.Resources.BonusBGhost2);
            scaredGhost.Images.Add(Properties.Resources.BonusWGhost2);
            scaredGhost.Images.Add(Properties.Resources.eyesUp);
            scaredGhost.Images.Add(Properties.Resources.eyesRight);
            scaredGhost.Images.Add(Properties.Resources.eyesLeft);
            scaredGhost.Images.Add(Properties.Resources.eyesDown);
            scaredGhost.ImageSize = new Size(27, 28);
        }
        /// <summary>
        /// Lägger till frukten i en lista
        /// </summary>
        private void AddFruits()
        {
            PictureBox cherry = new PictureBox();
            cherry.Size = new Size(27, 18);
            cherry.SizeMode = PictureBoxSizeMode.Zoom;
            cherry.Image = Properties.Resources.Cherry;
            fruits.Add(new Fruit(100, cherry, "cherry"));

            PictureBox strawberry = new PictureBox();
            strawberry.Size = new Size(27, 18);
            strawberry.SizeMode = PictureBoxSizeMode.Zoom;
            strawberry.Image = Properties.Resources.Strawberry;
            fruits.Add(new Fruit(300, strawberry, "strawberry"));

            PictureBox  orange= new PictureBox();
            orange.Size = new Size(27, 18);
            orange.SizeMode = PictureBoxSizeMode.Zoom;
            orange.Image = Properties.Resources.orange;
            fruits.Add(new Fruit(500, orange, "orange"));

            PictureBox apple = new PictureBox();
            apple.Size = new Size(27, 18);
            apple.SizeMode = PictureBoxSizeMode.Zoom;
            apple.Image = Properties.Resources.Apple;
            fruits.Add(new Fruit(700, apple, "apple"));

            PictureBox melon = new PictureBox();
            melon.Size = new Size(27, 18);
            melon.SizeMode = PictureBoxSizeMode.Zoom;
            melon.Image = Properties.Resources.Melon ;
            fruits.Add(new Fruit(1000, melon, "melon"));

            PictureBox galaxy = new PictureBox();
            galaxy.Size = new Size(27, 18);
            galaxy.SizeMode = PictureBoxSizeMode.Zoom;
            galaxy.Image = Properties.Resources.Galaxian_Boss;
            fruits.Add(new Fruit(2000, galaxy, "galaxy"));

            PictureBox bell = new PictureBox();
            bell.Size = new Size(27, 18);
            bell.SizeMode = PictureBoxSizeMode.Zoom;
            bell.Image = Properties.Resources.Bell;
            fruits.Add(new Fruit(3000, bell, "bell"));

            PictureBox key = new PictureBox();
            key.Size = new Size(27, 18);
            key.SizeMode = PictureBoxSizeMode.Zoom;
            key.Image = Properties.Resources.Key;
            fruits.Add(new Fruit(5000, key, "key"));


        }

        /// <summary>
        /// Ändrar riktningen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Hindrar så att man kan hålla ned knappen så att pacman åker snabbare
            if (e.KeyCode == keyPressed)
            {
                return;
            }
            keyPressed = e.KeyCode;
            // Sätter igång en timer om den inte är startad ännu
            if (!pacmanTimer.Enabled)
            {
                pacmanTimer.Enabled = true;
            }
            if (!ghostTimer.Enabled)
            {
                ghostTimer.Enabled = true;
            }
            if (!clock.Enabled)
            {
                clock.Enabled = true;
            }
            // Ändrar riktning
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!endBool)
                    {
                        nextDirection = 1;
                        MovePacman(1);
                    }
                    break;
                case Keys.Left:
                    if (!endBool)
                    {
                        nextDirection = 2;
                        MovePacman(2);
                    }
                    break;
                case Keys.Down:
                    if (!endBool)
                    {
                        nextDirection = 3;
                        MovePacman(3);
                    }
                    break;
                case Keys.Right:
                    if (!endBool)
                    {
                        nextDirection = 4;
                        MovePacman(4);
                    }
                    break;
                case Keys.Enter:
                    if (endBool)
                    {
                        endBool = false;
                        Application.Restart();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Startar spelet
        /// </summary>
        private void StartGame()
        {
            // Sättar samma font på alla labels 
            foreach (Control x in Controls)
            {
                if (x is Label)
                {
                    if ((string)x.Tag != "menu")
                    {
                        x.Font = new System.Drawing.Font("Folio XBd BT", 14);
                    }
                }
            }
            // Generara Bilden för spelplanen
            BoardImage.Image = Properties.Resources.Board_1;

            pacStartX = getLocation(1);
            pacStartY = getLocation(0);
            // Rita ut liv och poäng
            CreatePlayer();
            CreateLives();

            // Rita ut matbitarna
            CreateFood();
            // Spöken
            CreateGhosts();
            // Bonuspoängen (mat)
            CreateFruit();
            // Pacman
            CreatePacman();
        }

        /// <summary>
        /// Tilldelar en map och ger pacmans startposition
        /// </summary>
        /// <param name="whatDimension"></param>
        /// <returns></returns>
        private int getLocation(int whatDimension)
        {
            // Spelplanen i en 2d array som kontorllerar vart man kan åka och vart man inte kan åka
            map = new int[,] {
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,02,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,02,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,01,10,10,10,10,10,00,10,10,00,10,10,10,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,10,10,10,00,10,10,00,10,10,10,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,00,00,00,00,00,00,00,00,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,11,11,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,15,15,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 00,00,00,00,00,00,01,00,00,00,10,10,10,15,15,10,10,10,00,00,00,01,00,00,00,00,00,00 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,00,00,00,00,04,00,00,00,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,02,01,01,10,10,01,01,01,01,01,01,01,00,03,01,01,01,01,01,01,01,10,10,01,01,02,10 },
                        { 10,10,10,01,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,01,10,10,10 },
                        { 10,10,10,01,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,01,10,10,10 },
                        { 10,01,01,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 }
            };
            // Hämtar pacmans startposition
            int startX = 0;
            int startY = 0;
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == 3)
                    {
                        startX = x;
                        startY = y;
                    }
                }
            }
            // Skickar jag med 1 som parametar så ska jag retunerar x-positionen för pacman
            if (whatDimension == 1)
            {
                return startX;
            }
            // Skickar jag inte med något ska jag retunera y-positionen för pacman
            else
            {
                return startY;
            }
        }
        /// <summary>
        /// Startar om poängen
        /// </summary>
        public void CreatePlayer()
        {
            // Sätter score till 0 och skriver ut det
            score = 0;
            UpdateLabel(0);
        }
        /// <summary>
        /// Uppdaterar poängen
        /// </summary>
        /// <param name="amount"> Hur mycket jag ska lägga till i poängen</param>
        public void UpdateLabel(int amount = 50)
        {
            score += amount;
            scoreText.Text = Convert.ToString(score);
        }
        /// <summary>
        /// Ritar ut liven längst ned på spelplanen
        /// </summary>
        public void CreateLives()
        {
            for (int i = 0; i < 3; i++)
            {
                livesPb[i] = new PictureBox();
                livesPb[i].Name = "Life" + i.ToString();
                livesPb[i].SizeMode = PictureBoxSizeMode.AutoSize;
                livesPb[i].Location = new Point(i * 30 + 3, 550);
                livesPb[i].Image = Properties.Resources.Life;
                this.Controls.Add(livesPb[i]);
                livesPb[i].BringToFront();
            }
        }

        /// <summary>
        /// Ritar ut liven om man har förlorat ett liv
        /// </summary>
        public void SetLives()
        {
            for (int i = 0; i < 3; i++)
            {
                livesPb[i].Visible = false;
            }
            for (int i = 0; i < lives; i++)
            {
                livesPb[i].Visible = true;
            }
        }
        /// <summary>
        /// Placerar ut alla matbitar på platser som har 1 i den 2d arrayen och powerups på alla platser som har 2
        /// </summary>
        private void CreateFood()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (map[i, j] == 1 || map[i, j] == 2)
                    {
                        foodImages[i, j] = new PictureBox();
                        amountOfFood++;
                        foodImages[i, j].Name = "food" + amountOfFood.ToString();
                        foodImages[i, j].SizeMode = PictureBoxSizeMode.AutoSize;
                        foodImages[i, j].Location = new Point(j * 16 - 1, i * 16 + 47);
                        // Om det är en vanlig matbit
                        if (map[i, j] == 1)
                        {
                            foodImages[i, j].Image = Properties.Resources.Block_1;
                        }
                        // Om det är en powerup
                        if (map[i, j] == 2)
                        {
                            foodImages[i, j].Image = Properties.Resources.Block_2;
                        }
                        this.Controls.Add(foodImages[i, j]);
                        foodImages[i, j].BringToFront();
                    }
                }
            }
        }
        /// <summary>
        /// Ritar ut frukten på spelplanen beroende på vilken nivå det är 
        /// </summary>
        public void CreateFruit()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (map[i,j] == 4)
                    {
                        int index = lvl;
                        if (index >= fruits.Count)
                        {
                            index = fruits.Count - 1;
                        }
                        fruits[index].image.Location = new Point(j * 16 - 12, i * 16 + 50);
                        fruits[index].image.Name = fruits[index].name;
                        this.Controls.Add(fruits[index].image);
                        fruits[index].image.BringToFront();
                    }
                }
            }
        }

        /// <summary>
        /// Skapar spökerna
        /// </summary>
        private void CreateGhosts()
        {
            for (int i = 0; i < 4; i++)
            {
                ghosts[i] = new Ghost();
                ghosts[i].number = i;
                ghostImage[i] = new PictureBox();
                ghostImage[i].Name = "GhostImage" + i.ToString();
                ghostImage[i].SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(ghostImage[i]);
                ghostImage[i].BringToFront();
            }
            GetGhostLocation();
            ResetGhost();
        }

        /// <summary>
        /// Hämtar startvärdet för spökerna och sätter in det i arrayen med spök-constructor
        /// </summary>
        private void GetGhostLocation()
        {
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (map[i, j] == 15)
                    {
                        ghosts[x].xStart = j;
                        ghosts[x].yStart = i;
                        x++;
                    }
                }
            }
        }

        /// <summary>
        /// Sätter spökerna till deras startposition
        /// </summary>
        private void ResetGhost()
        {
            var x = 0;
            foreach (Ghost spook in ghosts)
            {
                spook.xCord = spook.xStart;
                spook.yCord = spook.yStart;
                ghostImage[x].Location = new Point(spook.xStart * 16 - 5, spook.yStart * 16 + 43);
                ghostImage[x].Image = ghostImages.Images[x * 9];
                spook.Direction = 0;
                spook.state = 0;
                x++;
                ghostImage[spook.number].BringToFront();
            }
        }
        /// <summary>
        /// Skapar pacmanbilden
        /// </summary>
        private void CreatePacman()
        {
            pacmanImage.Location = new Point(pacStartX * 16 - 7, pacStartY * 16 + 43);
            currentDirection = 0;
            nextDirection = 0;
            cordX = pacStartX;
            cordY = pacStartY;
            pacmanImage.BringToFront();
        }

        /// <summary>
        /// Varje tick ska pacman flyttas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pacmanTimer_Tick(object sender, EventArgs e)
        {
            MovePacman(currentDirection);
        }

        /// <summary>
        /// Flyttar pacman 
        /// </summary>
        /// <param name="direction"> Den riktningen splaren vill gå i</param>
        private void MovePacman(int direction)
        {
            // Kollar om vi kan gå i den riktningen spelare vill gå i
            bool canMove = CheckDirection(nextDirection);

            DirectionChecker(direction, canMove);
        }
        /// <summary>
        /// Kollar ifall pacman kan gå åt det håll spelaren vill och ifall man akn gå åt det håll som man redan går
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="canMove"></param>
        private void DirectionChecker(int direction, bool canMove)
        {
            if (!canMove)
            {
                // Om vi inte kan i den riktningen kollar vi om vi kan gå i den riktningen vi redan går i, dvs att det inte ligger en vägg framför oss
                canMove = CheckDirection(currentDirection);
                // Riktningen vi ska gå i är den riktningen vi redan går i, dvs den ändras inte
                direction = currentDirection;
            }
            else
            {
                // Om vi kan gå i den riktningen vi vill så blir riktningen vi ska gå i den riktningen spelaren vill gå i
                direction = nextDirection;
            }
            MoveImage(direction, canMove);
        }
        /// <summary>
        /// Flyttar bilden i åt det hållet man vill om det går
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="canMove"></param>
        private void MoveImage(int direction, bool canMove)
        {
            // Om vi kan gå i den riktningen vi vill går vi in här
            if (canMove)
            {
                switch (direction)
                {
                    // Flyttar pacmanbilden respektive steg beroende på riktning
                    case 1:
                        pacmanImage.Top -= 16;
                        cordY--;
                        break;
                    case 2:
                        pacmanImage.Left -= 16;
                        cordX--;
                        break;
                    case 3:
                        pacmanImage.Top += 16;
                        cordY++;
                        break;
                    case 4:
                        pacmanImage.Left += 16;
                        cordX++;
                        break;
                    default:
                        break;
                }
                // Ändrar riktningen vi går i till den riktningen som spelaren tryckte på
                currentDirection = direction;
                // Kollar om pacman krockar med mat
                CheckCollisionFood();
                // Kollar om pacman krockat med fruit
                CheckCollisionFruit();
                // Uppdaterar pacmanbilden (animation)
                UpdateImage();
            }
        }
        /// <summary>
        /// Kollar om vi kan gå i den riktningen man vill gå i med hjälp av den 2d arrayen
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool CheckDirection(int direction)
        {
            switch (direction)
            {
                // Beorende på riktning så flyttar vi oss repsektive steg i arrayen
                case 1:
                    return IsDirectionValid(cordX, cordY - 1);
                case 2:
                    return IsDirectionValid(cordX - 1, cordY);
                case 3:
                    return IsDirectionValid(cordX, cordY + 1);
                case 4:
                    return IsDirectionValid(cordX + 1, cordY);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Flyttar pacman till andra sidan om man är i "tunneln" och retunerar sant eller falskt om nästa steg i arrayen är okej
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns> Sant om vi kan gå, falskt om vi inte kan gå </returns>
        public bool IsDirectionValid(int x, int y)
        {
            if (x > 27)
            {
                cordX = 0;
                pacmanImage.Left = -5;
                return true;
            }
            if (x < 0)
            {
                cordX = 27;
                pacmanImage.Left = 427;
                return true;
            }
            // Nästa steg är inte en vägg (0 är väg, 1 är mat, 2 är power, 3 är pacman, 4 är fruit)
            if (map[y, x] < 5)
            {
                return true;
            }
            // Om nästa steg i arrayen är en 4 eller högre så är det inte okej att gå det och det retunerar sant eller falskt
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kollar om vi krockar med mat
        /// </summary>
        public void CheckCollisionFood()
        {
            switch (map[cordY, cordX])
            {
                // Om pacmans koordinat i mapen har en 1 på sig så är en på en vanlig matbit
                case 1:
                    EatFood(cordY, cordX); // Skickar med koordinaterna för att metoden ska veta vilke matbit som ska tas bort
                    break;
                // Är det en två ska man äta en powerUp
                case 2:
                    EatSuper(cordY, cordX);
                    break;
            }
        }
        /// <summary>
        /// Kollar om pacman krockar med frukten
        /// </summary>
        private void CheckCollisionFruit()
        {
            int index = lvl;
            if (index >= fruits.Count)
            {
                index = fruits.Count - 1;
            }
            foreach (Control x in Controls)
            {
                if ((string)x.Name == fruits[index].name)
                {
                    if ((Math.Abs(pacmanImage.Left - fruits[index].image.Left) < 20) && (Math.Abs(pacmanImage.Top - fruits[index].image.Top) < 20) && x.Visible)
                    {
                        UpdateLabel(fruits[index].value);
                        x.Visible = false;
                        eatenFruit = true;
                    }
                }
            }
        }
        /// <summary>
        /// Uppdaterar (animerar) pacman
        /// </summary>
        public void UpdateImage()
        {
            if (currentDirection != 0)
            {
                pacmanImage.Image = pacman.Images[((currentDirection - 1) * 4) + imageOn];
                imageOn++;
                if (imageOn > 3)
                {
                    imageOn = 0;
                }
            }
        }

        /// <summary>
        /// Krockar man med mat så ska den matbiten försvinna
        /// </summary>
        /// <param name="x"> positionen man är på </param>
        /// <param name="y"> positionen man är på </param>
        public void EatFood(int x, int y)
        {
            if ((Math.Abs(pacmanImage.Left - foodImages[x, y].Left) < 20) && (Math.Abs(pacmanImage.Top - foodImages[x, y].Top) < 20) && foodImages[x, y].Visible)
            {
                foodImages[x, y].Visible = false;
                map[x, y] = 0;
                UpdateLabel(10);
                amountOfFood--;
                releaseGhost++;
                // Om alla matbitar är borta har man vunnit
                if (amountOfFood < 1)
                {
                    Restart();
                }
            }
        }

        /// <summary>
        /// Äter man super ska man få poäng samt att man ska kunna äta spöken
        /// </summary>
        /// <param name="x"> positionen man är på</param>
        /// <param name="y"> positionen man är på </param>
        public void EatSuper(int x, int y)
        {
            if ((Math.Abs(pacmanImage.Left - foodImages[x, y].Left) < 20) && (Math.Abs(pacmanImage.Top - foodImages[x, y].Top) < 20) && foodImages[x, y].Visible)
            {
                amountOfFood--;
                if (amountOfFood < 1)
                {
                    Restart();
                }
                foodImages[x, y].Visible = false;
                map[x, y] = 0;
                UpdateLabel(100);
                ChangeGhostState();
            }
        }
        /// <summary>
        /// Om maten är slut, starta om matchen med samma poäng och tid
        /// </summary>
        public void Restart()
        {
            foreach (Control x in Controls)
            {
                if ((string)x.Name == fruits[lvl].name)
                {
                    this.Controls.Remove(x);
                }
            }
            eatenFruit = false;
            lvl++;
            ghostTimer.Interval -= lvl * 10;
            if (ghostTimer.Interval < 1)
            {
                ghostTimer.Interval = 1;
            }
            ResetMap();
            // Ritar ut maten igen
            CreateFood();
            // Ritar ut frukten
            CreateFruit();
            // När spöket ska släpas ut
            releaseGhost = 0;
            // Sätter spökerna på startpostionen
            ResetGhost();
            // Sätter pacman på startpositionen
            CreatePacman();
        }

        public void ResetMap()
        {
            // Spelplanen i en 2d array som kontorllerar vart man kan åka och vart man inte kan åka
            map = new int[,] {
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,02,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,02,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,01,10,10,10,10,10,00,10,10,00,10,10,10,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,10,10,10,00,10,10,00,10,10,10,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,00,00,00,00,00,00,00,00,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,11,11,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,15,15,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 00,00,00,00,00,00,01,00,00,00,10,10,10,15,15,10,10,10,00,00,00,01,00,00,00,00,00,00 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,00,00,00,00,04,00,00,00,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,02,01,01,10,10,01,01,01,01,01,01,01,00,03,01,01,01,01,01,01,01,10,10,01,01,02,10 },
                        { 10,10,10,01,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,01,10,10,10 },
                        { 10,10,10,01,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,01,10,10,10 },
                        { 10,01,01,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 }
            };
        }
        /// <summary>
        /// Om man har vunnit
        /// </summary>
        public void GameOver()
        {
            endBool = true;
            pacmanTimer.Enabled = false; ;
            ghostTimer.Enabled = false; ;
            turningTimer.Enabled = false; ;
            homeTimer.Enabled = false; ;
            stateTimer.Enabled = false; ;
            scaredTimer.Enabled = false; ;
            clock.Enabled = false; ;
            time.Text = "Press enter to restart";
            userInput child = new userInput();
            child.DataAvailable += new EventHandler(Child_DataAvailable);
            child.Show();
            // När man stänger rutan där man får skriva in sitt namn ska UpdateJson köras
            child.FormClosed += UpdateJson;
        }

        /// <summary>
        /// När man skrivit in sitt namn så ska JSON filen på labbservern uppdateras via php scriptet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJson(object sender, FormClosedEventArgs e)
        {
            // Lägger in alla variabler som används i highscore lsitan i en NameValueCollection
            var values = new NameValueCollection();
            values["name"] = playerName;
            values["score"] = score.ToString();
            values["player_time"] = seconds.ToString();

            // Försök att nå servern
            try
            {
                // Skicka informationen med metoden post till ett php-script som ligger på labbservern. Skickar med datan för att jämföra i php-scriptet
                var response = client.UploadValues("http://labb.vgy.se/~adamhg/prog/pacman.php", "POST", values);
            }
            // Om det inte gick att nå servern t.ex. ifall den ligger nere (Error 500) så slipper programmet krascha
            catch (Exception f)
            {
                // En dialogruta visas med felmeddelandet
                MessageBox.Show("There was an error uploading your score: " + f.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw f;
            }
            Form high = new highscore();
            high.Show();
        }
        /// <summary>
        /// En timer för att flytta spöket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ghostTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ghosts.Length; i++)
            {
                if (ghosts[i].state > 0)
                {
                    continue;
                }
                MoveGhost(i);
            }
        }

        /// <summary>
        /// Flyttar spöket
        /// </summary>
        /// <param name="x">Vilket spöke det är som ska flyttas</param>
        private void MoveGhost(int x)
        {
            CheckPacman();
            CheckFruit();
            // Om riktningen inte är åt något håll ska vi slumpa ut ett tal. Är talet 3 så ska spökerna lämna "boet"
            if (ghosts[x].Direction == 0)
            {
                if (releaseGhost / 5 == x || x == 0)
                {
                    ghosts[x].Direction = 1;
                }
            }
            else
            {
                DecideDirection(x);
            }
        }
        /// <summary>
        /// Hanterar bestämmandet av riktning för spökerna
        /// </summary>
        private void DecideDirection(int x)
        {
            // Ändrar riktning
            bool canMove = false;
            OtherDirection(ghosts[x].Direction, x);

            while (!canMove)
            {
                // Kollar nuvarande riktning
                canMove = CheckDirectionGhost(ghosts[x].Direction, x);
                if (!canMove)
                {
                    // Kan man inte gå ska man byta riktning
                    ChangeDirection(ghosts[x].Direction, x);
                }
            }
            if (canMove)
            {
                MoveGhostDirection(x);

                WhatState(x);
            }
        }
        /// <summary>
        /// Flyttar bilden på spöket
        /// </summary>
        /// <param name="x"></param>
        private void MoveGhostDirection(int x)
        {
            // Beroende på vilket håll spöket går åt ska vi ändra position på bilden
            switch (ghosts[x].Direction)
            {
                case 1:
                    ghostImage[x].Top -= 16;
                    ghosts[x].yCord--;
                    break;
                case 2:
                    ghostImage[x].Left += 16;
                    ghosts[x].xCord++;
                    break;
                case 3:
                    ghostImage[x].Top += 16;
                    ghosts[x].yCord++;
                    break;
                case 4:
                    ghostImage[x].Left -= 16;
                    ghosts[x].xCord--;
                    break;
            }
        }
        /// <summary>
        /// Ändrar bild beroende på State
        /// </summary>
        /// <param name="x"></param>
        private void WhatState(int x)
        {
            int ghostImg = x * 9 + (ghosts[x].Direction * 2);
            // Beroende på om spökerna är rädda, ätna eller vanliga ska bilderna ändras
            switch (ghosts[x].state)
            {
                // Vanliga
                case 0:
                    StateNormal(x, ghostImg);
                    break;
                //Rädda
                case 1:
                    StateScared(x);
                    break;
                // Håller på att ändra tillbaka
                case 2:
                    StateTurning(x);
                    break;
                // Ätna
                case 3:
                    StateEaten(x);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Normal state -> vanlig bild medn animering
        /// </summary>
        /// <param name="x"></param>
        /// <param name="ghostImg"></param>
        private void StateNormal(int x, int ghostImg)
        {
            if (ghostImage[x].Left % 5 == 0 || ghostImage[x].Top % 5 == 0)
            {
                ghostImage[x].Image = ghostImages.Images[ghostImg];
            }
            else
            {
                ghostImage[x].Image = ghostImages.Images[ghostImg - 1];
            }
        }
        /// <summary>
        /// Scared state -> blått spöke med animering
        /// </summary>
        /// <param name="x"></param>
        private void StateScared(int x)
        {
            if (scaredOn)
            {
                ghostImage[x].Image = scaredGhost.Images[0];
            }
            else
            {
                ghostImage[x].Image = scaredGhost.Images[2];
            }
        }
        /// <summary>
        /// Turning state -> Blinkar blått och vitt med animering
        /// </summary>
        /// <param name="x"></param>
        private void StateTurning(int x)
        {
            if (scaredOn)
            {
                if (turningOn)
                {
                    ghostImage[x].Image = scaredGhost.Images[0];
                }
                else
                {
                    ghostImage[x].Image = scaredGhost.Images[2];
                }
            }
            else
            {
                if (turningOn)
                {
                    ghostImage[x].Image = scaredGhost.Images[1];
                }
                else
                {
                    ghostImage[x].Image = scaredGhost.Images[3];
                }
            }
        }
        /// <summary>
        /// Eaten state -> ögon med animering
        /// </summary>
        /// <param name="x"></param>
        private void StateEaten(int x)
        {
            ghostImage[x].Image = scaredGhost.Images[ghosts[x].Direction + 3];
        }
        /// <summary>
        /// Gör så att spökerna kan ändra riktning mitt i en längd, gör dem mindre förutsägbara
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="ghost"></param>
        private void OtherDirection(int dir, int ghost)
        {
            if (map[ghosts[ghost].yCord, ghosts[ghost].xCord] < 5)
            {
                bool[] directions = new bool[5];
                int x = ghosts[ghost].xCord;
                int y = ghosts[ghost].yCord;
                switch (dir)
                {
                    // Om vi kan gå åt något av hållen blir dem true och sätts in i arrayen
                    case 1:
                    case 3:
                        directions[2] = IsDirectionValid(x + 1, y, ghost);
                        directions[4] = IsDirectionValid(x - 1, y, ghost);
                        break;
                    case 2:
                    case 4:
                        directions[1] = IsDirectionValid(x, y + 1, ghost);
                        directions[3] = IsDirectionValid(x, y - 1, ghost);
                        break;
                    default:
                        break;
                }
                // Slumpar fram ett tal mellan 0 och 4
                int which = random.Next(0, 5);
                // Om vi kan gå åt det hållet som vi slumpade fram ska spöket ändra håll
                if (directions[which])
                {
                    ghosts[ghost].Direction = which;
                }
            }
        }

        /// <summary>
        /// Kollar ifall spöket kan gå i den riktningen på samma sätt som hos pacman
        /// </summary>
        /// <param name="direction">Hållet spöket går åt</param>
        /// <param name="ghost">Spöket</param>
        /// <returns></returns>
        private bool CheckDirectionGhost(int direction, int ghost)
        {
            switch (direction)
            {
                case 1:
                    return IsDirectionValid(ghosts[ghost].xCord, ghosts[ghost].yCord - 1, ghost);
                case 2:
                    return IsDirectionValid(ghosts[ghost].xCord + 1, ghosts[ghost].yCord, ghost);
                case 3:
                    return IsDirectionValid(ghosts[ghost].xCord, ghosts[ghost].yCord + 1, ghost);
                case 4:
                    return IsDirectionValid(ghosts[ghost].xCord - 1, ghosts[ghost].yCord, ghost);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Samma som för pacman retunerar sant om man kan gå och falskt om man itne kan gå. Är man i "tunneln" flyttas spöket över till andra sidan
        /// </summary>
        /// <param name="x">Spökets x-koordinat</param>
        /// <param name="y">spökets y-koordinat</param>
        /// <param name="ghost">Spöket</param>
        /// <returns></returns>
        private bool IsDirectionValid(int x, int y, int ghost)
        {
            if (x < 0)
            {
                ghosts[ghost].xCord = 27;
                ghostImage[ghost].Left = 429;
                return true;
            }
            if (x > 27)
            {
                ghosts[ghost].xCord = 0;
                ghostImage[ghost].Left = -5;
                return true;
            }
            if (map[y, x] < 5 || map[y, x] > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Om man inte kan gå åt ett håll ändras riktnignen
        /// </summary>
        /// <param name="dir">Vilket håll spöket går åt innan</param>
        /// <param name="ghost"> Vilket spöke det är som ska ändra riktning</param>
        private void ChangeDirection(int dir, int ghost)
        {
            int which = random.Next(0, 2);
            switch (dir)
            {
                case 1:
                case 3:
                    if (which == 1)
                    {
                        ghosts[ghost].Direction = 2;
                    }
                    else
                    {
                        ghosts[ghost].Direction = 4;
                    }
                    break;
                case 2:
                case 4:
                    if (which == 1)
                    {
                        ghosts[ghost].Direction = 1;
                    }
                    else
                    {
                        ghosts[ghost].Direction = 3;
                    }
                    break;
            }
        }
        /// <summary>
        /// Ändrar spökets state, dvs om man ätit powerup så ska den ändras
        /// </summary>
        private void ChangeGhostState()
        {
            foreach (Ghost spook in ghosts)
            {
                if (spook.state == 0 || spook.state == 2)
                {
                    spook.state = 1;
                    ghostImage[spook.number].Image = scaredGhost.Images[0];
                    scaredTimer.Enabled = true;
                }
            }
            scaredTimer.Stop();
            scaredTimer.Enabled = true;
            scaredTimer.Start();
            stateTimer.Stop();
            stateTimer.Enabled = true;
            stateTimer.Start();
            turningTimer.Stop();
        }

        /// <summary>
        /// Flyttar spöket långsammare om det är rädd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scaredTimer_Tick(object sender, EventArgs e)
        {
            scaredOn = !scaredOn;
            foreach (Ghost spook in ghosts)
            {
                if (spook.state == 1 || spook.state == 2)
                {
                    MoveGhost(spook.number);
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Spöket är rädd i 10 sek sedan byter den state till 2 vilket är när den håller på att ändra tillbaka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stateTimer_Tick(object sender, EventArgs e)
        {
            foreach (Ghost spook in ghosts)
            {
                if (spook.state == 1)
                {
                    spook.state = 2;
                }
            }
            stateTimer.Enabled = false;
            turningTimer.Stop();
            turningTimer.Enabled = true;
            turningTimer.Start();
        }

        // I två sekunder ska spöket ändra tillbaka, och när den ändrar tillbaka blir amount 1, vilket används för att räkna ut hur många poöng man ska få per spöke
        private void turningTimer_Tick(object sender, EventArgs e)
        {
            turningOn = !turningOn;
            foreach (Ghost spook in ghosts)
            {
                if (spook.state == 2)
                {
                    spook.state = 0;
                    amount = 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckFruit()
        {
            int index = lvl;
            if (index >= fruits.Count)
            {
                index = fruits.Count - 1;
            }
            foreach (Ghost spook in ghosts)
            {
                foreach (Control x in Controls)
                {
                    if ((string)x.Name == fruits[index].name)
                    {
                        if ((Math.Abs(ghostImage[spook.number].Left - fruits[index].image.Left) < 20) && (Math.Abs(ghostImage[spook.number].Top - fruits[index].image.Top) < 20) && x.Visible && spook.state == 0)
                        {
                            fruitTimer.Stop();
                            fruitTimer.Enabled = true;
                            fruitTimer.Start();
                            x.Visible = false;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Kollar om man kolliderar med pacman, är man rädd eller turning så ska man ätas, är man vanlig blir pacman av med ett liv
        /// </summary>
        private void CheckPacman()
        {
            foreach (Ghost spook in ghosts)
            {
                // Rädd eller turnining
                if (spook.state == 1 || spook.state == 2)
                {
                    // Om pacman och spöket kolliderar
                    if ((Math.Abs(pacmanImage.Left - ghostImage[spook.number].Left) < 20) && (Math.Abs(pacmanImage.Top - ghostImage[spook.number].Top) < 20))
                    {
                        // Öka poängen
                        UpdateLabel(200 * amount);
                        amount*=2;
                        // Byter bild
                        ghostImage[spook.number].Image = scaredGhost.Images[spook.Direction + 3];
                        // Sätter igång timer
                        homeTimer.Enabled = true;
                        // Ändrar state till äten
                        spook.state = 3;
                    }
                }
                // Om man krockar och spöket är vanligt blir man av med liv
                else if ((Math.Abs(pacmanImage.Left - ghostImage[spook.number].Left) < 20) && (Math.Abs(pacmanImage.Top - ghostImage[spook.number].Top) < 20) && spook.state == 0)
                {
                    LoseLife();
                }
            }
        }

        /// <summary>
        /// Om man blir av med ett liv
        /// </summary>
        private void LoseLife()
        {
            // Minskar liven
            lives--;
            if (lives > 0)
            {
                // När spöket ska släpas ut
                releaseGhost = 0;
                // Sätter spökerna på startpostionen
                ResetGhost();
                // Sätter pacman på startpositionen
                CreatePacman();
                // Ritar ut nya liv
                SetLives();
            }
            // Om man har 0 liv
            else if (lives == 0)
            {
                GameOver();
            }
        }

        /// <summary>
        /// Om spöket blivit ätet ska det åka tillbaka till startpostionen, sen kan den börja jaga pacman igen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeTimer_Tick(object sender, EventArgs e)
        {
            foreach (Ghost spook in ghosts)
            {
                if (spook.state == 3)
                {
                    int xPos = spook.xStart * 16 - 3;
                    int yPos = spook.yStart * 16 + 43;
                    if (ghostImage[spook.number].Left > xPos)
                    {
                        ghostImage[spook.number].Left--;
                    }
                    if (ghostImage[spook.number].Left < xPos)
                    {
                        ghostImage[spook.number].Left++;
                    }
                    if (ghostImage[spook.number].Top > yPos)
                    {
                        ghostImage[spook.number].Top--;
                    }
                    if (ghostImage[spook.number].Top < yPos)
                    {
                        ghostImage[spook.number].Top++;
                    }
                    if (ghostImage[spook.number].Top == yPos && ghostImage[spook.number].Left == xPos)
                    {
                        spook.state = 0;
                        spook.xCord = spook.xStart;
                        spook.yCord = spook.yStart;
                        ghostImage[spook.number].Top = spook.yStart * 16 + 43;
                        ghostImage[spook.number].Left = spook.xStart * 16 - 3;
                    }
                }
            }
        }
        /// <summary>
        /// Skriver ut tiden i en label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clock_Tick(object sender, EventArgs e)
        {
            seconds++;
            time.Text = "Time: " + TimeSpan.FromSeconds(seconds).ToString("mm\\:ss");
        }
        /// <summary>
        /// Kollar ifall det finns något namn inskrivet i userinput, hämtar det och sätter in det i playerName variabeln
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Child_DataAvailable(object sender, EventArgs e)
        {
            userInput child = sender as userInput;
            if (child != null)
            {
                playerName = child.Data;
            }
        }
        /// <summary>
        /// Öppnar hjälp-rutan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpBtn_Click(object sender, EventArgs e)
        {
            help help = new help();
            help.Show();
        }

        /// <summary>
        /// Öppnar highscore-rutan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void highscoreBtn_Click(object sender, EventArgs e)
        {
            highscore high = new highscore();
            high.Show();
        }
        /// <summary>
        /// Gör så att alla bilder inte laggar
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        /// Om spöket kolliderar med frukten ska den försvinna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fruitTimer_Tick(object sender, EventArgs e)
        {
            int index = lvl;
            if (index >= fruits.Count)
            {
                index = fruits.Count - 1;
            }
            foreach (Control x in Controls)
            {
                if ((string)x.Name == fruits[index].name && !eatenFruit)
                {
                    x.Visible = true;
                }
            }
        }


    }
    /// <summary>
    /// En klass för spökerna, istället för att göra ett antal array för information om spökerna som riktning och status och position gjorde jag en constructor för spökerna och satta in dem i en array. På så sätt slipper jag göra massa arrayer
    /// </summary>
    class Ghost
    {
        // All information om spökerna
        // Status: Är spöket ätit, rädd eller normalt
        public int state;
        // X-koord: Platsen i den 2d array som är kartan
        public int xCord;
        // Y-koord: Platsen i den 2d array som är kartan
        public int yCord;
        // Start-X: Platsen som spöket startar på
        public int xStart;
        // Start-Y: Platsen som spöket startar på
        public int yStart;
        // Direction: Vilket håll spöket går åt
        public int Direction;
        // Vilket spöke det är
        public int number;
        /// <summary>
        /// Constructor för klassen så att man kan skapa objekt av spökerna
        /// </summary>
        public Ghost()
        {
            state = 0;
            xCord = 0;
            yCord = 0;
            Direction = 0;
            xStart = 0;
            yStart = 0;
            number = 0;
        }

    }
    /// <summary>
    /// Samma som ovan, en klass för frukten för att slippa göra massa arrayer för all data. Gör koden mer clean och lättare att komma åt
    /// </summary>
    class Fruit
    {
        // Vilken position i våran lista, så att jag vet vilken nivå ska visa vilken frukt
        public int value { get; set; }
        // Namnet på frukten
        public string name { get; set; }
        // Vilken bild som ska visas
        public PictureBox image { get; set; }

        /// <summary>
        /// Constructor för att kunna lägga till objekt i en lista
        /// </summary>
        /// <param name="Value"> Positionen i listan</param>
        /// <param name="pic"> en string som är bilden </param>
        /// <param name="Name"> namnet </param>
        public Fruit(int Value, PictureBox pic, string Name)
        {
            value = Value;
            image = pic;
            name = Name;
        }
    }
}
