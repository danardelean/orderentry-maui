global using System;
global using System.Collections.ObjectModel;

global using OrderEntry.Model;
global using OrderEntry.Services;
global using OrderEntry.ViewModel;
global using OrderEntry.View;
global using OrderEntry.Resources.Localization;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using Microsoft.Extensions.Logging;

global using ZXing.Net.Maui.Controls;

#if IOS || ANDROID
global using BarcodeScanner.Mobile.Maui;
global using BarcodeScanner.Mobile.Core;
#else
global using ZXing.Net.Maui;
#endif

