using BlazorStateTest1.State.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStateTest1.State
{
    public class AppState
    {
        public NavigationState NavigationState { get; private set; } = new NavigationState();

        public static event Action StateChanged;
        public static async void NotifyStateChanged() => StateChanged.Invoke();
    }
}
