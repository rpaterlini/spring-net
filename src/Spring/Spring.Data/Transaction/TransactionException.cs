/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Runtime.Serialization;

namespace Spring.Transaction;

/// <summary>
/// Base class for all transaction exceptions.
/// </summary>
/// <author>Rod Johnson</author>
/// <author>Griffin Caprio (.NET)</author>
[Serializable]
public abstract class TransactionException : ApplicationException
{
    /// <summary>
    /// Creates a new instance of the TransactionException class.
    /// </summary>
    protected TransactionException()
    {
    }

    /// <summary>
    /// Creates a new instance of the TransactionException class, with the specified message.
    /// </summary>
    /// <param name="message">
    /// A message about the exception.
    /// </param>
    protected TransactionException(string message) : base(message)
    {
    }

    /// <summary>
    /// Creates a new instance of the TransactionException class with the specified message
    /// and root cause.
    /// </summary>
    /// <param name="message">
    /// A message about the exception.
    /// </param>
    /// <param name="rootCause">
    /// The root exception that is being wrapped.
    /// </param>
    protected TransactionException(string message, Exception rootCause)
        : base(message, rootCause)
    {
    }

    /// <inheritdoc />
    protected TransactionException(
        SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
