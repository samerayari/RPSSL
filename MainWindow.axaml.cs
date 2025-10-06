using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace gui 
{
    public partial class MainWindow : Window
    {
        private readonly string[] _opts = { "Rock", "Paper", "Scissors", "Lizard", "Spock" };
        private readonly Random _rng = new Random();
        private int _you = 0, _bot = 0;

        public MainWindow()
        {
            InitializeComponent();

            BtnRock.Click     += (_, __) => Play("Rock");
            BtnPaper.Click    += (_, __) => Play("Paper");
            BtnScissors.Click += (_, __) => Play("Scissors");
            BtnLizard.Click   += (_, __) => Play("Lizard");
            BtnSpock.Click    += (_, __) => Play("Spock");

            BtnReset.Click += Reset;
            BtnClose.Click += (_, __) => Close();
        }

        private void Play(string mine)
        {
            if (_you >= 3 || _bot >= 3)
            {
                TxtRound.Text = "Spillet er slut – tryk Nulstil.";
                return;
            }

            var theirs = _opts[_rng.Next(_opts.Length)];
            TxtChoices.Text = $"Du: {mine} | Agent: {theirs}";

            var r = Win(mine, theirs);
            if (r == 1) { _you++;  TxtRound.Text = $"Du vandt runden! ({mine} slår {theirs})"; }
            else if (r == -1) { _bot++; TxtRound.Text = $"Agenten vandt! ({theirs} slår {mine})"; }
            else TxtRound.Text = "Uafgjort!";

            TxtScore.Text = $"Stillingen — Du: {_you} | Agent: {_bot}";
            if (_you == 3)  TxtRound.Text = "🎉 Du vandt spillet! Nulstil for at spille igen.";
            if (_bot == 3)  TxtRound.Text = "🤖 Agenten vandt spillet. Prøv igen!";
        }

        
        private static int Win(string a, string b)
        {
            if (a == b) return 0;
            return (a, b) switch
            {
                ("Rock", "Scissors") => 1, ("Rock", "Lizard") => 1,
                ("Paper", "Rock") => 1,   ("Paper", "Spock") => 1,
                ("Scissors", "Paper") => 1, ("Scissors", "Lizard") => 1,
                ("Lizard", "Spock") => 1, ("Lizard", "Paper") => 1,
                ("Spock", "Scissors") => 1, ("Spock", "Rock") => 1,
                _ => -1
            };
        }

        private void Reset(object? s, RoutedEventArgs e)
        {
            _you = _bot = 0;
            TxtChoices.Text = "Du: - | Agent: -";
            TxtScore.Text = "Stillingen — Du: 0 | Agent: 0";
            TxtRound.Text = "Gør dit valg for at starte spillet!";
        }
    }
}
