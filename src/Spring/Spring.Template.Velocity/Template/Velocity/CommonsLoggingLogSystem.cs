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

using Microsoft.Extensions.Logging;
using NVelocity.Runtime;
using NVelocity.Runtime.Log;
using LogLevel = NVelocity.Runtime.Log.LogLevel;

namespace Spring.Template.Velocity;

/// <summary>
/// NVelocity LogSystem implementation for Commons Logging.
/// </summary>
/// <author>Erez Mazor</author>
public class CommonsLoggingLogSystem : ILogSystem
{
    /// <summary>
    /// Shared logger instance.
    /// </summary>
    protected static readonly ILogger<CommonsLoggingLogSystem> log = LogManager.GetLogger<CommonsLoggingLogSystem>();

    /// <summary>
    /// Initializes the specified runtime services.  No-op in current implementatin
    /// </summary>
    /// <param name="runtimeServices">the runtime services.</param>
    public void Init(IRuntimeServices runtimeServices)
    {
    }

    /// <summary>
    /// Log a NVelocity message using the commons logging system
    /// </summary>
    /// <param name="level">LogLevel to match</param>
    /// <param name="message">message to log</param>
    public void LogVelocityMessage(LogLevel level, string message)
    {
        switch (level)
        {
            case LogLevel.Error:
                log.LogError(message);
                break;
            case LogLevel.Warn:
                log.LogWarning(message);
                break;
            case LogLevel.Info:
                log.LogInformation(message);
                break;
            case LogLevel.Debug:
                log.LogDebug(message);
                break;
        }
    }
}
