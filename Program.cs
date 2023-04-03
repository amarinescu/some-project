using SomeProject;

int inactivityInterval = 2 * 60 * 1000;

// Set the interval at which the mouse is clicked to 10 seconds
int clickInterval = 10 * 1000;

// Create a timer to check for inactivity
Timer inactivityTimer = new Timer(CheckInactivity, null, 0, clickInterval);

// Run the application until the user closes the console window
while (true)
{
    Thread.Sleep(1000);
}

static void CheckInactivity(object state)
{
    // Get the time of the last user input
    int idleTime = Win32.GetIdleTime();

    // If the user has been inactive for 2 minutes, click the middle mouse button
    if (idleTime > 2 * 60 * 1000)
    {
        Win32.keybd_event((byte)ConsoleKey.RightArrow, 0, 0, 0);
        Win32.keybd_event((byte)ConsoleKey.RightArrow, 0, 2, 0);
        Console.WriteLine("Prevented inactivity!");
    }
}
