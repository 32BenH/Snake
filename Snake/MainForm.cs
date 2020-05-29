using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
		private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
		private Random random = new Random();
		private Direction lastDirection = Direction.Left;
		private Direction direction = Direction.Left;
		private int score = 0;
		private bool pause = false;
		private int highScore = 0;
		private SoundPlayer eatSound;
		private SoundPlayer deathSound;

		public MainForm()
        {	
			string temp;

			InitializeComponent();

			try
			{
				eatSound = new SoundPlayer("C:\\Program Files (x86)\\Snake\\eat.wav");
				deathSound = new SoundPlayer("C:\\Program Files (x86)\\Snake\\death.wav");

				temp = File.ReadAllText(string.Format("C:\\Users\\{0}\\AppData\\Local\\Temp\\snakehighscore.txt", Environment.UserName));
				if (temp != "")
				{
					lblHighScore.Text = temp;
					highScore = int.Parse(temp);
				}
			}
			catch { }

			timer.Tick += UpdateScreen;
			timer.Start();

			StartGame();
        }

		private void StartGame()
		{
			Circle head = new Circle();

			snake.Clear();

			head.X = random.Next(0, pictureBox.Size.Width / 16);
			head.Y = random.Next(0, pictureBox.Size.Height / 16);
			snake.Add(head);

			GenerateFood();
		}

		private void GenerateFood()
		{
			food.X = random.Next(0, pictureBox.Size.Width / 16);
			food.Y = random.Next(0, pictureBox.Size.Height / 16);
			for (int i = 0; i < snake.Count; i++)
			{
				if(snake[i].X == food.X && snake[i].Y == food.Y)
				{
					GenerateFood();
				}
			}
		}

		private void UpdateScreen(object sender, EventArgs e)
		{ 
			if(Keyboard.IsKeyDown(Key.P))
			{
				if(pause)
				{
					pause = false;
				}
				else
				{
					pause = true;
				}
			}

			if(!pause)
			{
				MoveSnake();
				pictureBox.Invalidate();
			}
		}

		private void MoveSnake()
		{
			for (int i = snake.Count - 1; i >= 0; i--)
			{
				if(i == 0)
				{
					if (direction == Direction.Left && lastDirection != Direction.Right)
					{
						lastDirection = Direction.Left;
						snake[i].X--;
					}
					else if (direction == Direction.Right && lastDirection != Direction.Left)
					{
						lastDirection = Direction.Right;
						snake[i].X++;
					}
					else if (direction == Direction.Up && lastDirection != Direction.Down)
					{
						lastDirection = Direction.Up;
						snake[i].Y--;
					}
					else if (direction == Direction.Down && lastDirection != Direction.Up)
					{
						lastDirection = Direction.Down;
						snake[i].Y++;
					}
					else
					{
						lastDirection = Direction.Left;
						snake[i].X--;
					}

					if (snake[i].X < 0 || snake[i].Y < 0 || snake[i].X >= (pictureBox.Size.Width / 16) || snake[i].Y >= (pictureBox.Size.Height / 16))
					{
						try
						{
							deathSound.Play();
						}
						catch { }
						
						StartGame();
						if(score > highScore)
						{
							highScore = score;
							File.WriteAllText(string.Format("C:\\Users\\{0}\\AppData\\Local\\Temp\\snakehighscore.txt", Environment.UserName), highScore.ToString());
						}
						score = 0;
						lblScore.Text = score.ToString();
						lblHighScore.Text = highScore.ToString();
					}

					for (int j = 1; j < snake.Count; j++)
					{
						if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
						{
							try
							{
								deathSound.Play();
							}
							catch { }
							
							StartGame();
							if (score > highScore)
							{
								highScore = score;
								File.WriteAllText(string.Format("C:\\Users\\{0}\\AppData\\Local\\Temp\\snakehighscore.txt", Environment.UserName), highScore.ToString());
							}
							score = 0;
							lblScore.Text = score.ToString();
							lblHighScore.Text = highScore.ToString();
						}
					}

					if ((snake[i].X == food.X) && (snake[i].Y == food.Y))
					{
						Eat();
						GenerateFood();
						score++;
						if (score > highScore)
						{
							highScore = score;
							File.WriteAllText(string.Format("C:\\Users\\{0}\\AppData\\Local\\Temp\\snakehighscore.txt", Environment.UserName), highScore.ToString());
						}
						lblScore.Text = score.ToString();
						lblHighScore.Text = highScore.ToString();
					}
				}
				else
				{
					snake[i].X = snake[i - 1].X;
					snake[i].Y = snake[i - 1].Y;
				}
			}
		}

		private void Eat()
		{
			try
			{
				eatSound.Play();
			}
			catch { }
			
			snake.Add(new Circle(snake[snake.Count - 1].X, snake[snake.Count - 1].Y));
		}

		private void PictureBox_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Brush snakeColor;

			for (int i = 0; i < snake.Count; i++)
			{

				if (i == 0)
				{
					snakeColor = Brushes.Black;
				}
				else
				{
					snakeColor = Brushes.DarkGray;
				}
				graphics.FillEllipse(snakeColor, new Rectangle(snake[i].X * 16, snake[i].Y * 16, 16, 16));
				graphics.FillEllipse(Brushes.Red, new Rectangle(food.X * 16, food.Y * 16, 16, 16));
			}
		}

		private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				direction = Direction.Up;
			}
			else if(e.KeyCode == Keys.Down)
			{
				direction = Direction.Down;
			}
			else if(e.KeyCode == Keys.Right)
			{
				direction = Direction.Right;
			}
			else if(e.KeyCode == Keys.Left)
			{
				direction = Direction.Left;
			}
		}

		enum Direction
		{
			Up,
			Down,
			Left,
			Right
		}
	}
}
