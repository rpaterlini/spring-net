/*
 * Copyright � 2002-2010 the original author or authors.
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

using Spring.Messaging.Ems.Common;

namespace Spring.Messaging.Ems.Core;

/// <summary> Callback for sending a message to a EMS destination.</summary>
/// <remarks>
/// <p>To be used with the EmsTemplate.Execute(IProducerCallback)
/// method, often implemented as an anonymous inner class.</p>
///
/// <p>The typical implementation will perform multiple operations on the
/// supplied EMS Session and MessageProducer. </p>
/// </remarks>
/// <author>Mark Pollack</author>
public interface IProducerCallback
{
    /// <summary> Perform operations on the given Session and MessageProducer.
    /// The message producer is not associated with any destination.
    /// </summary>
    /// <param name="session">the EMS <code>Session</code> object to use
    /// </param>
    /// <param name="producer">the EMS <code>MessageProducer</code> object to use
    /// </param>
    /// <returns> a result object from working with the <code>Session</code>, if any (can be <code>null</code>)
    /// </returns>
    object DoInEms(ISession session, IMessageProducer producer);
}
