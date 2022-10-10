namespace Blorc.Bindings
{
    using System;
    using System.Linq.Expressions;
    using Blorc.Converters;
    using Blorc.Linq.Expressions;

    /// <summary>
    /// Extension methods for the binding context.
    /// </summary>
    public static class BindingContextExtensions
    {
        /// <summary>
        /// Adds a new binding to the binding context.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <param name="source">The source.</param>
        /// <param name="sourcePropertyName">Name of the source property.</param>
        /// <param name="target">The target.</param>
        /// <param name="targetPropertyName">Name of the target property.</param>
        /// <param name="mode">The binding mode.</param>
        /// <param name="converter">The converter, can be set afterwards as well.</param>
        /// <returns>The <see cref="Binding"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="target"/> is <c>null</c>.</exception>
        public static Binding AddBinding(this BindingContext bindingContext, object source, string sourcePropertyName, 
            object target, string targetPropertyName, BindingMode mode = BindingMode.TwoWay, IValueConverter? converter = null)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(sourcePropertyName);
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(targetPropertyName);

            var binding = new Binding(source, sourcePropertyName, target, targetPropertyName, mode, converter);

            bindingContext.AddBinding(binding);

            return binding;
        }

        public static BindingBuilder CreateBinding(this BindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            return new BindingBuilder(bindingContext);
        }

        /// <summary>
        /// Adds a new binding to the source object.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <param name="sourcePropertyExpression">The source property expression.</param>
        /// <param name="targetPropertyExpression">The target property expression.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="converter">The converter, can be set afterwards as well.</param>
        /// <returns>The <see cref="Binding"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="sourcePropertyExpression"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="targetPropertyExpression"/> is <c>null</c>.</exception>
        public static Binding AddBinding(this BindingContext bindingContext, Expression<Func<object>> sourcePropertyExpression, 
            Expression<Func<object>> targetPropertyExpression, BindingMode mode = BindingMode.TwoWay, IValueConverter? converter = null)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);
            ArgumentNullException.ThrowIfNull(sourcePropertyExpression);
            ArgumentNullException.ThrowIfNull(targetPropertyExpression);

            var source = ExpressionHelper.GetOwner(sourcePropertyExpression);
            if (source is null)
            {
                throw new InvalidOperationException($"The binding source could not be determined from the source property expression");
            }

            var sourceProperty = ExpressionHelper.GetPropertyName(sourcePropertyExpression);
            if (sourceProperty is null)
            {
                throw new InvalidOperationException($"The binding source property could not be determined from the source property expression");
            }

            var target = ExpressionHelper.GetOwner(targetPropertyExpression);
            if (target is null)
            {
                throw new InvalidOperationException($"The binding target could not be determined from the target property expression");
            }

            var targetProperty = ExpressionHelper.GetPropertyName(targetPropertyExpression);
            if (targetProperty is null)
            {
                throw new InvalidOperationException($"The binding target property could not be determined from the target property expression");
            }

            return AddBinding(bindingContext, source, sourceProperty, target, targetProperty, mode, converter);
        }

        /// <summary>
        /// Adds a new binding to the source object and automatically instantiates the converter.
        /// </summary>
        /// <typeparam name="TConverter">The type of the t converter.</typeparam>
        /// <param name="bindingContext">The binding context.</param>
        /// <param name="source">The source.</param>
        /// <param name="sourcePropertyName">Name of the source property.</param>
        /// <param name="target">The target.</param>
        /// <param name="targetPropertyName">Name of the target property.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>The <see cref="Binding"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="target"/> is <c>null</c>.</exception>
        public static Binding AddBindingWithConverter<TConverter>(this BindingContext bindingContext, object source, 
            string sourcePropertyName, object target, string targetPropertyName, BindingMode mode = BindingMode.TwoWay)
            where TConverter : IValueConverter, new()
        {
            ArgumentNullException.ThrowIfNull(bindingContext);
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(sourcePropertyName);
            ArgumentNullException.ThrowIfNull(target);
            ArgumentNullException.ThrowIfNull(targetPropertyName);

            var converter = new TConverter();

            return AddBinding(bindingContext, source, sourcePropertyName, target, targetPropertyName, mode, converter);
        }

        /// <summary>
        /// Adds a new binding to the source object and automatically instantiates the converter.
        /// </summary>
        /// <typeparam name="TConverter">The type of the converter.</typeparam>
        /// <param name="bindingContext">The binding context.</param>
        /// <param name="sourcePropertyExpression">The source property expression.</param>
        /// <param name="targetPropertyExpression">The target property expression.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>The <see cref="Binding"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="sourcePropertyExpression"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="targetPropertyExpression"/> is <c>null</c>.</exception>
        public static Binding AddBindingWithConverter<TConverter>(this BindingContext bindingContext, 
            Expression<Func<object>> sourcePropertyExpression, Expression<Func<object>> targetPropertyExpression, BindingMode mode = BindingMode.TwoWay)
            where TConverter : IValueConverter, new()
        {
            ArgumentNullException.ThrowIfNull(bindingContext);
            ArgumentNullException.ThrowIfNull(sourcePropertyExpression);
            ArgumentNullException.ThrowIfNull(targetPropertyExpression);

            var converter = new TConverter();

            return AddBinding(bindingContext, sourcePropertyExpression, targetPropertyExpression, mode, converter);
        }


        /// <summary>
        /// Adds a new command binding to the element.
        /// </summary>
        /// <param name="bindingContext">The binding context.</param>
        /// <param name="element">The element.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="command">The command.</param>
        /// <param name="commandParameterBinding">The command parameter binding.</param>
        /// <returns>Catel.MVVM.CommandBinding.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="element"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="eventName"/> is <c>null</c> or whitespace.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="command"/> is <c>null</c>.</exception>
        public static CommandBinding AddCommandBinding(this BindingContext bindingContext, object element, string eventName, 
            ICommand command, Binding? commandParameterBinding = null)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);
            ArgumentNullException.ThrowIfNull(element);
            ArgumentNullException.ThrowIfNull(eventName);
            ArgumentNullException.ThrowIfNull(command);

            var commandBinding = new CommandBinding(element, eventName, command, commandParameterBinding);

            bindingContext.AddCommandBinding(commandBinding);

            return commandBinding;
        }
    }
}
