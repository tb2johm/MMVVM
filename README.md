# MMVVM
My ModelView View Model helper framework

This package is directed to new users of MVVM, to make it a little simpler to start with. More senior users will most likley
already have this functionality implemented.

In the MVVM pattern there are many central concepts, but the two most common are properties, and commands.
With properties I mean how to show and update data on the screen.
Commands determines what happens for example when you press a button.

## Usage
####Properties:

* So create a ViewModel in a folder named ViewModel, and make it extend MMVVM.ViewModelBase.ViewModelBase.

```C#
namespace MyApplication.ViewModel
{
  public class ViewModel : MMVVM.ViewModelBase.ViewModelBase
  {
```

* Create your public and backing private properties
```C#
    private string _myText = "Hello";
    public string MyText
    {
      get {return _myText;}
      set
      {
        if (value != _myText)
        {
          _myText = value;
          Notify("MyText");
        }
      }
    }
```
* Bind your xaml and control to the ViewModel and the MyText property
```XAML
<Window ...
         xmln:vm="clr-namespace:MyApplication.ViewModel"
         ...>
  <Window.Resources>
    <vm:ViewModel x:Key="ViewModel">
  </Window.Resources>
  <StackPanel DataContext="{StaticStaticResource ViewModel}">
    <TextBox Text="{Binding MyText}" />
    <Button Content="Ok" />
  </StackPanel>
</Window>
```
DONE! So every time you change the MyText property, the window will automatically update the data

####Commands:
* In your ViewModel Create a public RelayCommand property and the wanted Action
```C#
  public MMVVM.Commands.RelayCommand ChangeMyText {get; set;}
  private void ChangeMyTextAction()
  {
    MyText = "World";
  }
```
* In the ctor (constructor) of the ViewModel, initiate the RelayCommand
```C# 
  public ViewModel()
  {
    ChangeMyText = new MMVVM.Commands.RelayCommand(ChangeMyTextAction);
  }
```
* [OPTIONAL] if you want you can set if the button is enabled or not. Do this by adding a function that makes the disition
   and add that function to the RelayCommand initiation
```C#
  private bool CanExecuteChangeMyTextAction()
  {
    return (MyText != "World");
  }
  public ViewModel()
  {
    ChangeMyText = new MMVVM.Commands.RelayCommand(ChangeMyTextAction, CanExecuteChangeMyTextAction);
  }
```
* Add the command to the button (or whatever control you have)
```C#
  <Button Content="Ok" Command="{Binding ChangeMyText}" />
```

Yheay! Now it's done!

For a better example, have a look at the UsageExample in the project
