﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.System;
using System;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace FluentSettingControls;

//// Note: ItemsRepeater will request all the available horizontal space: https://github.com/microsoft/microsoft-ui-xaml/issues/3842
[TemplatePart(Name = PART_ItemsRepeater, Type = typeof(ItemsRepeater))]
public partial class SettingsExpander : Control
{
    private const string PART_ItemsRepeater = "PART_ItemsRepeater";

    private ItemsRepeater? _itemsRepeater;

    /// <summary>
    /// The SettingsExpander is a collapsable control to host multiple SettingsCards.
    /// </summary>
    public SettingsExpander()
    {
        this.DefaultStyleKey = typeof(SettingsExpander);
        Items = new List<object>();
    }

    /// <inheritdoc />
    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        SetAccessibleName();

        if (_itemsRepeater != null)
        {
            _itemsRepeater.ElementPrepared -= this.ItemsRepeater_ElementPrepared;
        }

        _itemsRepeater = GetTemplateChild(PART_ItemsRepeater) as ItemsRepeater;

        if (_itemsRepeater != null)
        {
            _itemsRepeater.ElementPrepared += this.ItemsRepeater_ElementPrepared;

            // Update it's source based on our current items properties.
            OnItemsConnectedPropertyChanged(this, null!); // Can't get it to accept type here? (DependencyPropertyChangedEventArgs)EventArgs.Empty
        }
    }

    private void SetAccessibleName()
    {
        if (string.IsNullOrEmpty(AutomationProperties.GetName(this)))
        {
            if (Header is string headerString && !string.IsNullOrEmpty(headerString))
            {
                AutomationProperties.SetName(this, headerString);
            }
        }
    }

    /// <summary>
    /// Creates AutomationPeer
    /// </summary>
    /// <returns>An automation peer for <see cref="SettingsExpander"/>.</returns>
    protected override AutomationPeer OnCreateAutomationPeer()
    {
        return new SettingsExpanderAutomationPeer(this);
    }

    private void OnIsExpandedChanged(bool oldValue, bool newValue)
    {
        var peer = FrameworkElementAutomationPeer.FromElement(this) as SettingsExpanderAutomationPeer;
        peer?.RaiseExpandedChangedEvent(newValue);
    }
}
