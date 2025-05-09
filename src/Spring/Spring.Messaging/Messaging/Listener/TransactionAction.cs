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

namespace Spring.Messaging.Listener;

/// <summary>
/// Action to perform on the MessageQueueTransaction when handling message listener exceptions.
/// </summary>
public enum TransactionAction
{
    /// <summary>
    /// Rollback the MessageQueueTransaction, returning the recieved message back onto the queue.
    /// </summary>
    Rollback,

    /// <summary>
    /// Commit the MessageQueueTransaction, removing the message from the queue.
    /// </summary>
    Commit
};
