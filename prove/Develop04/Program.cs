using System;
using System.Threading;
using System.Timers;

namespace Activity
{

    // Base class for all activities.
    public abstract class Activity
    {
        protected string Description { get; set; }
        protected int Duration { get; set; }
        protected string Name { get; set; }

        public abstract void StartActivity();

        public void SetDuration(int duration)
        {
            Duration = duration;
        }
    }

    // Class for the breathing activity
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void StartActivity()
        {
            Console.WriteLine($"Starting {Name} activity for {Duration} seconds...");
            Console.WriteLine(Description);
            Console.WriteLine("Get Ready!!");
            DisplayTimer(2);

            for (int i = 0; i < Duration/3; i++)
            {
                Console.WriteLine("Breathe in...");
                DisplayTimer(3);
                Console.WriteLine("Breathe out...");
                DisplayTimer(3);
            }

            Console.WriteLine($"You have finished the {Name} activity for {Duration} seconds!");
        }

        public static void DisplayTimer(int x)
        {
            int time = 0;
            while (true)
            {
                time++;
                Console.Write("\r|");
                Thread.Sleep(250);
                Console.Write("\r/");
                Thread.Sleep(250);
                Console.Write("\r-");
                Thread.Sleep(250);
                Console.Write("\r\\");
                Thread.Sleep(250);
                if(x==time)
                {
                    Console.WriteLine();
                    break;
                }
                    

            }
        }
    }

    // Class for the reflection activity
    public class ReflectionActivity : Activity
    {
        public ReflectionActivity()
        {
            Name = "Reflection";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        public override void StartActivity()
        {
            Console.WriteLine($"Starting {Name} activity for {Duration} seconds...");
            Console.WriteLine(Description);
            Console.WriteLine("Get Ready!!");
            BreathingActivity.DisplayTimer(2);

            // Prompts
            string[] prompts =
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            for (int i = 0; i < Duration/3; i++)
            {
                Console.WriteLine(prompts[i % prompts.Length]);
                BreathingActivity.DisplayTimer(3);
            }

            Console.WriteLine($"You have finished the {Name} activity for {Duration} seconds!");
        }
    }

    // Class for the listing activity
    public class ListingActivity : Activity
    {
        public ListingActivity()
        {
            Name = "Listing";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void StartActivity()
        {
            Console.WriteLine($"Starting {Name} activity for {Duration} seconds...");
            Console.WriteLine(Description);
            Console.WriteLine("Get Ready!!");
            BreathingActivity.DisplayTimer(2);

            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                //Console.WriteLine("Time's up!");
            }

            // Prompts
            string[] prompts =
            {
                "Who are people that you appreciate?",
                "What are your personal strengths of yours?",
                "Who are the people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };

            for (int i = 0; i < Duration/3; i++)
            {
                Console.WriteLine(prompts[i % prompts.Length]);
                Console.WriteLine("List as many items as you can until the timer runs out and press the Enter");


                System.Timers.Timer timer = new System.Timers.Timer((Duration/3)*1000);
                timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                timer.Start();

                string userInput = Console.ReadLine();

                timer.Stop();

            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"You have finished the {Name} activity for {Duration} seconds!");
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Menu Options");
                Console.WriteLine("1. Start breathing activity");
                Console.WriteLine("2. Start reflection activity");
                Console.WriteLine("3. Start listing activity");
                Console.WriteLine("4. Quit");

                int activityChoice = Convert.ToInt32(Console.ReadLine());

                switch (activityChoice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        Console.WriteLine("How many seconds do you want to do this activity for?");
                        int duration = Convert.ToInt32(Console.ReadLine());
                        breathingActivity.SetDuration(duration);
                        breathingActivity.StartActivity();
                        break;
                    case 2:
                        ReflectionActivity reflectionActivity = new ReflectionActivity();
                        Console.WriteLine("How many seconds do you want to do this activity for?");
                        duration = Convert.ToInt32(Console.ReadLine());
                        reflectionActivity.SetDuration(duration);
                        reflectionActivity.StartActivity();
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        Console.WriteLine("How many seconds do you want to do this activity for?");
                        duration = Convert.ToInt32(Console.ReadLine());
                        listingActivity.SetDuration(duration);
                        listingActivity.StartActivity();
                        break;
                    case 4:
                        quit = true;
                        break;
                }
            }
        }
    }

}