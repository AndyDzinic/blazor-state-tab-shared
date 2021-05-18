# Blazor state shared accross tabs
Sample project of state that is shared between tabs

## Startup.cs

In order to implement state shared accross tabs it is necesary to add a singleton service.

```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllers();
            services.AddHttpClient();
            services.AddSingleton<WeatherForecastService>();
            
            //Add the service here
            services.AddSingleton<AppState>();
        }
 ```

## /State/Appstate.cs

In order to keep state organized, it is possible to divide it into multiple objects inside your `AppState` class. This is why the `/State/Navigation/NavigationState.cs` 
class exists. The class is used as a property of the `AppState` class. The AppState class also contains a static event property and a static `NotifyStateChanged()` 
function that invokes the event. These properties are static in order to be accessible inside the state classes.

```
    public class AppState
    {
        public NavigationState NavigationState { get; private set; } = new NavigationState();

        public static event Action StateChanged;
        public static async void NotifyStateChanged() => StateChanged.Invoke();
    }
```

## /State/Navigation/NavigationState.cs

The `NavigationState` class is the class that actually holds the data. It is important that all the properties have private setters as to force the use of methods in order to
change the property value. `AppState.NotifyStateChanged()` is called at the end of each method to notify the components that the state has changed.

```
    public class NavigationState
    {
        public DateTime TimeNow { get; private set; } = new DateTime();
        public bool IsLeftSidebarOpen { get; private set; } = false;

        public async void ToggleLeftSidebar()
        {
            IsLeftSidebarOpen = !IsLeftSidebarOpen;
            AppState.NotifyStateChanged();
        }

        public async void SetLeftSidebar(bool isLeftSidebarOpen) {
            IsLeftSidebarOpen = isLeftSidebarOpen;
            AppState.NotifyStateChanged();
        }

        public async void GetDateTime() {
            TimeNow = DateTime.Now;
            AppState.NotifyStateChanged();
        }
    }
```
