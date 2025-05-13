using Microsoft.AspNetCore.Components;

namespace Blazor.NavigationStack;

public partial class NavigationStack {


    /// <summary>
    /// Provides context for rendering the whole layout of the <see cref="NavigationStack"/>.
    /// </summary>
    public readonly struct LayoutContext {
        /// <summary>
        /// Render all headers in <see cref="NavigationStack"/>. 
        /// </summary>
        public required RenderFragment HeaderStack { get; init; }

        /// <summary>
        /// Render menus in the current <see cref="StackPage"/>.
        /// </summary>
        public required RenderFragment MenuStack { get; init; }

        /// <summary>
        /// Render the current content of <see cref="NavigationStack"/>.
        /// </summary>
        public required RenderFragment Content { get; init; }

        /// <summary>
        /// Render a back button.
        /// </summary>
        public required RenderFragment BackButton { get; init; }
    }

    /// <summary>
    /// Provides context for rendering the header stack.
    /// </summary>
    public readonly struct HeaderStackContext {
        /// <summary>
        /// Each rendering a part of the header associates with a <see cref="StackPage"/>
        /// ordering from top of the stack to the bottom.
        /// </summary>
        public required IEnumerable<RenderFragment> Headers { get; init; }

        /// <summary>
        /// Fragment used to render a separator between header elements in the stack.
        /// Used for visual separation of consecutive headers.
        /// </summary>
        public required RenderFragment Separator { get; init; }
    }

    public readonly struct HeaderContext {
        /// <summary>
        /// Name of the <see cref="StackPage"/> associate with this header.
        /// </summary>
        public required string? Name { get; init; }

        /// <summary>
        /// Is the content of the header being shown in <see cref="NavigationStack"/>?
        /// </summary>
        public required bool IsActive { get; init; }
    }

    /// <summary>
    /// Provides context for rendering a menu.
    /// </summary>
    public readonly struct MenuContext {
        /// <summary>
        /// Each rendering a part of the menu in the current <see cref="StackPage"/>.
        /// </summary>
        public required IEnumerable<RenderFragment> Options { get; init; }
    }

    /// <summary>
    /// Provides context for rendering a back button.
    /// </summary>
    public readonly struct BackContext {
        /// <summary>
        /// When invoked, the current <see cref="StackPage"/> will be popped with the
        /// <see cref="Result{T}.IsCanceled"/> set.
        /// </summary>
        public required Action Back { get; init; }
    }

    public readonly struct Result<T> {
        public static readonly Result<T> Canceled = new() { IsCanceled = true, Value = default };
        public required T? Value { get; init; }
        public required bool IsCanceled { get; init; }
    }

}