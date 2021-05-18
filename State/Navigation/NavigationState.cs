using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStateTest1.State.Navigation
{
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
}
