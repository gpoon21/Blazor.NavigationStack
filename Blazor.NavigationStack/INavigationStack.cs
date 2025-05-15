using Microsoft.AspNetCore.Components;

namespace Blazor.NavigationStack;

public interface INavigationStack {
    /// <summary>
    /// Push a page onto the <see cref="NavigationStack"/> with a specific type return type.
    /// The task will be completed when <see cref="SetResult"/> method has been invoked or the back button was clicked.
    /// </summary>
    Task<NavigationStack.Result<T>> Push<T>(StackPage stackPage);

    /// <summary>
    /// Push a page onto the <see cref="NavigationStack"/>.
    /// The task will be completed when <see cref="SetResult"/> method has been invoked or the back button was clicked.
    /// </summary>
    /// <returns>
    /// Return true if the current page was <see cref="Pop"/>. Return false if the current page was <see cref="Cancel"/>
    /// or the back button was clicked.
    /// </returns>
    Task<bool> Push(StackPage stackPage);

    /// <summary>
    /// Complete the current <see cref="StackPage"/> by setting a result.
    /// This will cause the current <see cref="StackPage"/> to be popped and return to the previous page
    /// while the <see cref="value"/> will be passed to the awaiting <see cref="Push"/> method call.
    /// </summary>
    void SetResult(object? value);

    /// <summary>
    /// Pop the current page and set <see cref="NavigationStack.Result{T}.IsCanceled"/>.
    /// </summary>
    void Cancel();

    /// <summary>
    /// Set menu to the current <see cref="StackPage"/>.
    /// </summary>
    void SetMenu(RenderFragment renderFragment);

    /// <summary>
    /// Set name of the current <see cref="StackPage"/>.
    /// </summary>
    void SetName(string name);

    void Refresh();

    /// <summary>
    /// Pop the current page.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="SetResult"/> with null as parameter.
    /// </remarks>
    void Pop();
}