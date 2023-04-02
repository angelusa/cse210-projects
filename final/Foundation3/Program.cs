using System;

    namespace EventPlanning
    {
        // Base Event Class
        class Event
        {
            // Private Member Variables
            private string eventTitle;
            private string eventDescription;
            private DateTime eventDate;
            private DateTime eventTime;
            private Address eventAddress;

            // Properties
            public string EventTitle
            {
                get { return eventTitle; }
                set { eventTitle = value; }
            }

            public string EventDescription
            {
                get { return eventDescription; }
                set { eventDescription = value; }
            }

            public DateTime EventDate
            {
                get { return eventDate; }
                set { eventDate = value; }
            }

            public DateTime EventTime
            {
                get { return eventTime; }
                set { eventTime = value; }
            }

            public Address EventAddress
            {
                get { return eventAddress; }
                set { eventAddress = value; }
            }

            // Constructor
            public Event(string title, string description, DateTime date, DateTime time, Address address)
            {
                eventTitle = title;
                eventDescription = description;
                eventDate = date;
                eventTime = time;
                eventAddress = address;
            }

            // Methods
            public string GetStandardDetails()
            {
                return $"Title: {eventTitle}\nDescription: {eventDescription}\nDate: {eventDate.ToShortDateString()}\nTime: {eventTime.ToShortTimeString()}\nAddress: {eventAddress.ToString()}";
            }

            public virtual string GetFullDetails()
            {
                return GetStandardDetails();
            }

            public string GetShortDescription()
            {
                return $"Event Type: {GetType().Name}, Title: {eventTitle}, Date: {eventDate.ToShortDateString()}";
            }
        }

        // Derived Lecture Class
        class Lecture : Event
        {
            // Private Member Variables
            private string speakerName;
            private int capacity;

            // Properties
            public string SpeakerName
            {
                get { return speakerName; }
                set { speakerName = value; }
            }

            public int Capacity
            {
                get { return capacity; }
                set { capacity = value; }
            }

            // Constructor
            public Lecture(string title, string description, DateTime date, DateTime time, Address address, string speaker, int cap) : base(title, description, date, time, address)
            {
                speakerName = speaker;
                capacity = cap;
            }

            // Methods
            public override string GetFullDetails()
            {
                return base.GetStandardDetails() + $"\nSpeaker: {speakerName}\nCapacity: {capacity}";
            }
        }

        // Derived Reception Class
        class Reception : Event
        {
            // Private Member Variables
            private string rsvpEmail;

            // Properties
            public string RSVPEmail
            {
                get { return rsvpEmail; }
                set { rsvpEmail = value; }
            }

            // Constructor
            public Reception(string title, string description, DateTime date, DateTime time, Address address, string email) : base(title, description, date, time, address)
            {
                rsvpEmail = email;
            }

            // Methods
            public override string GetFullDetails()
            {
                return base.GetStandardDetails() + $"\nRSVP Email: {rsvpEmail}";
            }
        }

        // Derived OutdoorGathering Class
        class OutdoorGathering : Event
        {
            // Private Member Variables
            private string weatherStatement;

            // Properties
            public string WeatherStatement
            {
                get { return weatherStatement; }
                set { weatherStatement = value; }
            }

            // Constructor
            public OutdoorGathering(string title, string description, DateTime date, DateTime time, Address address, string weather) : base(title, description, date, time, address)
            {
                weatherStatement = weather;
            }

            // Methods
            public override string GetFullDetails()
            {
                return base.GetStandardDetails() + $"\nWeather: {weatherStatement}";
            }
        }

        // Address Class
        class Address
        {
            // Private Member Variables
            private string street;
            private string city;
            private string state;
            private string zip;

            // Properties
            public string Street
            {
                get { return street; }
                set { street = value; }
            }

            public string City
            {
                get { return city; }
                set { city = value; }
            }

            public string State
            {
                get { return state; }
                set { state = value; }
            }

            public string Zip
            {
                get { return zip; }
                set { zip = value; }
            }

            // Constructor
            public Address(string street, string city, string state, string zip)
            {
                this.street = street;
                this.city = city;
                this.state = state;
                this.zip = zip;
            }

            // Method
            public override string ToString()
            {
                return $"{street}, {city}, {state} {zip}";
            }
        }

        // Program
        class Program
        {
            static void Main(string[] args)
            {
                // Create Address
                Address eventAddress = new Address("123 Main St", "New York", "NY", "10001");

                // Create Events
                Lecture lecture = new Lecture("Introduction to Programming", "Learn the basics of programming in this lecture", new DateTime(2020, 5, 8), new DateTime(2020, 5, 7), eventAddress, "John Doe", 100);
                Reception reception = new Reception("Welcome to New York", "Let's celebrate the opening of our new office!", new DateTime(2020, 5, 10), new DateTime(2020, 5, 9), eventAddress, "rsvp@company.com");
                OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "Let's enjoy the summer weather together!", new DateTime(2020, 5, 15), new DateTime(2020, 5, 16), eventAddress, "Partly Cloudy");

                // Output Messages
                Console.WriteLine("Standard Details:");
                Console.WriteLine(lecture.GetStandardDetails());
                Console.WriteLine(reception.GetStandardDetails());
                Console.WriteLine(outdoorGathering.GetStandardDetails());

                Console.WriteLine("\nFull Details:");
                Console.WriteLine(lecture.GetFullDetails());
                Console.WriteLine(reception.GetFullDetails());
                Console.WriteLine(outdoorGathering.GetFullDetails());

                Console.WriteLine("\nShort Description:");
                Console.WriteLine(lecture.GetShortDescription());
                Console.WriteLine(reception.GetShortDescription());
                Console.WriteLine(outdoorGathering.GetShortDescription());
                Console.ReadLine();
            }
        }
    }
