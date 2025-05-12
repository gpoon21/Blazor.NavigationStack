using Microsoft.AspNetCore.Components;

namespace Blazor.NavigationStack;

public interface INavigationStack {
    /// <summary>
    /// Push a page onto the <see cref="NavigationStack"/> with a specific type return type.
    /// The task will be completed when <see cref="SetResult"/> method has been invoked or the back button was clicked.
    /// </summary>
    Task<T?> Push<T>(StackPage stackPage);

    /// <summary>
    /// Push a page onto the <see cref="NavigationStack"/>.
    /// The task will be completed when <see cref="SetResult"/> method has been invoked or the back button was clicked.
    /// </summary>
    Task Push(StackPage stackPage);

    /// <summary>
    /// Complete the current <see cref="StackPage"/> by setting a result.
    /// This will cause the current <see cref="StackPage"/> to be popped and return to the previous page.
    /// </summary>
    void SetResult(object? value = null);

    /// <summary>
    /// Set menu to the current <see cref="StackPage"/>.
    /// </summary>
    void SetMenu(RenderFragment renderFragment);

    void SetName(string name);
    void Refresh();

}