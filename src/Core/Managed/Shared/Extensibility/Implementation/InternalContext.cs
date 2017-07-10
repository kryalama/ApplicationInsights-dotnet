﻿namespace Microsoft.ApplicationInsights.Extensibility.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility.Implementation.External;

    /// <summary>
    /// Encapsulates Internal information.
    /// </summary>
    public sealed class InternalContext
    {
        private string sdkVersion;
        private string agentVersion;
        private string nodeName;

        internal InternalContext()
        {
        }

        /// <summary>
        /// Gets or sets application insights SDK version.
        /// </summary>
        public string SdkVersion
        {
            get { return this.sdkVersion == string.Empty ? null : this.sdkVersion; }
            set { this.sdkVersion = value; }
        }

        /// <summary>
        /// Gets or sets application insights agent version.
        /// </summary>
        public string AgentVersion
        {
            get { return this.agentVersion == string.Empty ? null : this.agentVersion; }
            set { this.agentVersion = value; }
        }

        /// <summary>
        /// Gets or sets node name for the billing purposes. Use this filed to override the standard way node names got detected.
        /// </summary>
        public string NodeName
        {
            get { return this.nodeName == string.Empty ? null : this.nodeName; }
            set { this.nodeName = value; }
        }

        internal void UpdateTags(IDictionary<string, string> tags)
        {
            tags.UpdateTagValue(ContextTagKeys.Keys.InternalSdkVersion, this.SdkVersion);
            tags.UpdateTagValue(ContextTagKeys.Keys.InternalAgentVersion, this.AgentVersion);
            tags.UpdateTagValue(ContextTagKeys.Keys.InternalNodeName, this.NodeName);
        }

        internal void CopyFrom(TelemetryContext telemetryContext)
        {
            var target = telemetryContext.Internal;
            Tags.CopyTagValue(target.SdkVersion, ref this.sdkVersion);
            Tags.CopyTagValue(target.AgentVersion, ref this.agentVersion);
            Tags.CopyTagValue(target.NodeName, ref this.nodeName);
        }
    }
}
