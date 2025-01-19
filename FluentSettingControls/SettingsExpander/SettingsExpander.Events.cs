using System;

namespace FluentSettingControls;
public partial class SettingsExpander
{
    /// <summary>
    /// Fires when the SettingsExpander is opened
    /// </summary>
    public event EventHandler? Expanded;

    /// <summary>
    /// Fires when the expander is closed
    /// </summary>
    public event EventHandler? Collapsed;
}
