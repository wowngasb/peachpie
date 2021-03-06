﻿using System;
using System.Collections.Generic;
using System.Text;
using Pchp.Core.Reflection;

namespace Pchp.Core
{
    /// <summary>
    /// Well-known type used by library function's parameters.
    /// Instructs the compiler and runtime that the parameter is implicitly declared (its value is provided by the compiler and/or runtime).
    /// </summary>
    /// <typeparam name="T">The type of value to be obtained.</typeparam>
    public struct QueryValue<T>
    {
        /// <summary>
        /// The queried value.
        /// </summary>
        public T Value;

        /// <summary>
        /// Implicit construction operator.
        /// </summary>
        public static implicit operator QueryValue<T>(T value) => new QueryValue<T> { Value = value };
    }
}

namespace Pchp.Core.QueryValue
{
    /// <summary>
    /// Contains reference to the current script container.
    /// </summary>
    public struct CallerScript
    {
        /// <summary>
        /// Script type.
        /// </summary>
        public RuntimeTypeHandle ScriptTypeHandle;

        /// <summary>
        /// Script type.
        /// </summary>
        public Type ScriptType => Type.GetTypeFromHandle(ScriptTypeHandle);

        /// <summary>
        /// Implicit construction operator.
        /// </summary>
        public static implicit operator CallerScript(RuntimeTypeHandle value) => new CallerScript { ScriptTypeHandle = value };
    }

    /// <summary>
    /// Denotates a function parameter that will be filled with array of callers' parameters.
    /// </summary>
    /// <remarks>
    /// The parameter is used to access calers' arguments.</remarks>
    public struct CallerArgs
    {
        public PhpValue[] Arguments;

        /// <summary>
        /// Implicit construction operator.
        /// </summary>
        public static implicit operator CallerArgs(PhpValue[] value) => new CallerArgs { Arguments = value };
    }

    /// <summary>
    /// Contains a reference to the array of local PHP variables.
    /// </summary>
    /// <remarks>
    /// The parameter is used to let the function to read or modify caller routine local variables.
    /// </remarks>
    public struct LocalVariables
    {
        public PhpArray Locals;

        /// <summary>
        /// Implicit construction operator.
        /// </summary>
        public static implicit operator LocalVariables(PhpArray value) => new LocalVariables { Locals = value };
    }

    /// <summary>
    /// Contains a value of <c>$this</c> variable or <c>null</c> if variable is not defined.
    /// </summary>
    public struct ThisVariable
    {
        /// <summary>
        /// Reference to <c>$this</c>.
        /// </summary>
        public object This { get; set; }

        /// <summary>
        /// Implicit construction operator.
        /// </summary>
        public ThisVariable(object value)
        {
            This = value;
        }
    }

    /// <summary>
    /// Dummy struct denotating <c>.ctor</c> used as the class fields initializer.
    /// For more information see <see cref="PhpFieldsOnlyCtorAttribute"/>.
    /// </summary>
    public struct DummyFieldsOnlyCtor
    {
    }

    //
    // FOLLOWING IS NOT IN USE YET:
    //

    /// <summary>
    /// Contains current class.
    /// The parameter must be of type <see cref="RuntimeTypeHandle"/>, <see cref="PhpTypeInfo"/> or <see cref="string"/>.
    /// </summary>
    /// <remarks>
    /// The parameter is used to access callers class context.
    /// </remarks>
    public struct CallerClass
    {
        public PhpTypeInfo Class;
    }

    /// <summary>
    /// Denotates a function parameter that will be loaded with current late static bound class.
    /// The parameter must be of type <see cref="PhpTypeInfo"/>.
    /// </summary>
    /// <remarks>
    /// The parameter is used to access calers' late static class (<c>static</c>).
    /// The parameter must be before regular parameters.</remarks>
    public struct CallerStaticClass
    {
        public PhpTypeInfo LateStaticClass;
    }
}
