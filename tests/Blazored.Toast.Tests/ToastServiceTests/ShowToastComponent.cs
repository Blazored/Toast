using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ShowToastComponent
{
    private readonly ToastService _sut;

    public ShowToastComponent()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnShowComponentInvoked_When_ShowToastCalled()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShowComponent += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowToast<MyTestComponent>();

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowComponentEventContainsNoParameters_When_ShowToastCalled()
    {
        // arrange
        ToastParameters? parameters = null;
        _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

        // act
        _sut.ShowToast<MyTestComponent>();

        // assert
        Assert.NotNull(parameters);
    }

    // [Fact]
    // public void OnShowComponentEventContainsNoSettings_When_ShowToastCalled()
    // {
    //     // arrange
    //     ToastSettings? settings = null;
    //     _sut.OnShowComponent += (_, _, argSettings) =>
    //     {
    //         var instanceToastSettings = new ToastSettings();
    //         argSettings?.Invoke(instanceToastSettings);
    //     };
    //
    //     // act
    //     _sut.ShowToast<MyTestComponent>();
    //
    //     // assert
    //     Assert.Null(settings);
    // }

    [Fact]
    public void OnShowComponentInvoked_When_ShowToastCalledWithParameters()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShowComponent += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowToast<MyTestComponent>(new ToastParameters());

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowComponentEventContainsParameters_When_ShowToastCalledWithParameters()
    {
        // arrange
        ToastParameters? parameters = null;
        _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

        // act
        _sut.ShowToast<MyTestComponent>(new ToastParameters());

        // assert
        Assert.NotNull(parameters);
    }

    // [Fact]
    // public void OnShowComponentEventContainsNoSettings_When_ShowToastCalledWithParameters()
    // {
    //     // arrange
    //     ToastInstanceSettings? settings = null;
    //     _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;
    //
    //     // act
    //     _sut.ShowToast<MyTestComponent>(new ToastParameters());
    //
    //     // assert
    //     Assert.Null(settings);
    // }

    [Fact]
    public void OnShowComponentInvoked_When_ShowToastCalledWithSettings()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShowComponent += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowToast<MyTestComponent>(settings =>
        {
            settings.Timeout = 10;
            settings.ShowProgressBar = true;
        });

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowComponentEventContainsNoParameters_When_ShowToastCalledWithSettings()
    {
        // arrange
        ToastParameters? parameters = null;
        _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

        // act
        _sut.ShowToast<MyTestComponent>(settings =>
        {
            settings.Timeout = 10;
            settings.ShowProgressBar = true;
        });

        // assert
        Assert.Null(parameters);
    }

    // [Fact]
    // public void OnShowComponentEventContainsSettings_When_ShowToastCalledWithSettings()
    // {
    //     // arrange
    //     ToastInstanceSettings? settings = null;
    //     _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;
    //
    //     // act
    //     _sut.ShowToast<MyTestComponent>(settings =>
    //     {
    //         settings.Timeout = 10;
    //         settings.ShowProgressBar = true;
    //     });
    //
    //     // assert
    //     Assert.NotNull(settings);
    //     Assert.Equal(2, settings.Timeout);
    //     Assert.True(settings.ShowProgressBar);
    // }

    [Fact]
    public void OnShowComponentInvoked_When_ShowToastCalledWithParametersAndSettings()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShowComponent += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowToast<MyTestComponent>(new ToastParameters(), settings =>
        {
            settings.Timeout = 10;
            settings.ShowProgressBar = true;
        });

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowComponentEventContainsParameters_When_ShowToastCalledWithParametersAndSettings()
    {
        // arrange
        ToastParameters? parameters = null;
        _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

        // act
        _sut.ShowToast<MyTestComponent>(new ToastParameters(), settings =>
        {
            settings.Timeout = 10;
            settings.ShowProgressBar = true;
        });

        // assert
        Assert.NotNull(parameters);
    }

    // [Fact]
    // public void OnShowComponentEventContainsSettings_When_ShowToastCalledWithParametersAndSettings()
    // {
    //     // arrange
    //     ToastInstanceSettings? settings = null;
    //     _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;
    //
    //     // act
    //     _sut.ShowToast<MyTestComponent>(new ToastParameters(), settings =>
    //     {
    //         settings.Timeout = 2;
    //         settings.ShowProgressBar = true;
    //     });
    //
    //     // assert
    //     Assert.NotNull(settings);
    //     Assert.Equal(2, settings.Timeout);
    //     Assert.True(settings.ShowProgressBar);
    // }

    [Fact]
    public void ArgumentExceptionIsThrown_When_ShowToastCalledPassingIncorrectType()
    {
        // arrange / act
        Action action = () => _sut.ShowToast(typeof(int), null, null);

        // assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void OnShowComponentInvoked_When_ShowToastCalledWithCorrectTypeAndParametersAndSettings()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShowComponent += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowToast(typeof(IComponent), new ToastParameters(), settings =>
        {
            settings.Timeout = 10;
            settings.ShowProgressBar = true;
        });

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowComponentEventContainsParameters_When_ShowToastCalledWithCorrectTypeAndParametersAndSettings()
    {
        // arrange
        ToastParameters? parameters = null;
        _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

        // act
        _sut.ShowToast(typeof(IComponent), new ToastParameters(), settings =>
        {
            settings.Timeout = 10;
            settings.ShowProgressBar = true;
        });

        // assert
        Assert.NotNull(parameters);
    }

    // [Fact]
    // public void OnShowComponentEventContainsSettings_When_ShowToastCalledWithCorrectTypeAndParametersAndSettings()
    // {
    //     // arrange
    //     ToastSettings? settings = null;
    //     _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;
    //
    //     // act
    //     _sut.ShowToast(typeof(IComponent), new ToastParameters(), settings =>
    //     {
    //         settings.Timeout = 2;
    //         settings.ShowProgressBar = true;
    //     });
    //
    //     // assert
    //     Assert.NotNull(settings);
    //     Assert.Equal(2, settings.Timeout);
    //     Assert.True(settings.ShowProgressBar);
    // }
}
