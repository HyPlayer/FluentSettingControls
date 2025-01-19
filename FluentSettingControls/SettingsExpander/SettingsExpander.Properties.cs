﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.System;
using System;

using Windows.UI.Xaml.Markup;

namespace FluentSettingControls;


[ContentProperty(Name = nameof(Content))]
public partial class SettingsExpander
{
    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="Header"/> property.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(Header),
        typeof(object),
        typeof(SettingsExpander),
        new PropertyMetadata(defaultValue: null));

    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="Description"/> property.
    /// </summary>
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description),
        typeof(object),
        typeof(SettingsExpander),
        new PropertyMetadata(defaultValue: null));

    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="HeaderIcon"/> property.
    /// </summary>
    public static readonly DependencyProperty HeaderIconProperty = DependencyProperty.Register(
        nameof(HeaderIcon),
        typeof(IconElement),
        typeof(SettingsExpander),
        new PropertyMetadata(defaultValue: null));


    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="Content"/> property.
    /// </summary>
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(object),
        typeof(SettingsExpander),
        new PropertyMetadata(defaultValue: null));

    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="Content"/> property.
    /// </summary>
    public static readonly DependencyProperty ItemsHeaderProperty = DependencyProperty.Register(
        nameof(ItemsHeader),
        typeof(UIElement),
        typeof(SettingsExpander),
        new PropertyMetadata(defaultValue: null));

    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="Content"/> property.
    /// </summary>
    public static readonly DependencyProperty ItemsFooterProperty = DependencyProperty.Register(
        nameof(ItemsFooter),
        typeof(UIElement),
        typeof(SettingsExpander),
        new PropertyMetadata(defaultValue: null));

    /// <summary>
    /// The backing <see cref="DependencyProperty"/> for the <see cref="IsExpanded"/> property.
    /// </summary>
    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
     nameof(IsExpanded),
     typeof(bool),
     typeof(SettingsExpander),
     new PropertyMetadata(defaultValue: false, (d, e) => ((SettingsExpander)d).OnIsExpandedPropertyChanged((bool)e.OldValue, (bool)e.NewValue)));

    /// <summary>
    /// 
    /// <summary>
    /// Gets or sets the Header.
    /// </summary>
    public object Header
    {
        get => (object)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the Description.
    /// </summary>
#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
    public new object Description
#pragma warning restore CS0109 // Member does not hide an inherited member; new keyword is not required
    {
        get => (object)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    /// <summary>
    /// Gets or sets the HeaderIcon.
    /// </summary>
    public IconElement HeaderIcon
    {
        get => (IconElement)GetValue(HeaderIconProperty);
        set => SetValue(HeaderIconProperty, value);
    }

    /// <summary>
    /// Gets or sets the Content.
    /// </summary>
    public object Content
    {
        get => (object)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    /// Gets or sets the ItemsFooter.
    /// </summary>
    public UIElement ItemsHeader
    {
        get => (UIElement)GetValue(ItemsHeaderProperty);
        set => SetValue(ItemsHeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the ItemsFooter.
    /// </summary>
    public UIElement ItemsFooter
    {
        get => (UIElement)GetValue(ItemsFooterProperty);
        set => SetValue(ItemsFooterProperty, value);
    }

    /// <summary>
    /// Gets or sets the IsExpanded state.
    /// </summary>
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }
    protected virtual void OnIsExpandedPropertyChanged(bool oldValue, bool newValue)
    {
        OnIsExpandedChanged(oldValue, newValue);

        if (newValue)
        {
            Expanded?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Collapsed?.Invoke(this, EventArgs.Empty);
        }
    }
}
