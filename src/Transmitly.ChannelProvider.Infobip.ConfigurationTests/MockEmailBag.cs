// ﻿﻿Copyright (c) Code Impressions, LLC. All Rights Reserved.
//  
//  Licensed under the Apache License, Version 2.0 (the "License")
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using Transmitly.Channel.Configuration.Email;
using Transmitly.ChannelProvider.Infobip.Configuration.Email;
using Transmitly.Template.Configuration;

namespace Transmitly.ChannelProvider.Infobip.ConfigurationTests
{
	class MockEmailBag : IEmailExtendedChannelProperties
	{
		public IContentTemplateConfiguration AmpHtml { get; set; } = new ContentTemplateConfiguration();
		public string? ApplicationId { get; set; }
		public string? EntityId { get; set; }
		public bool? IntermediateReport { get; set; }
		public string? NotifyUrl { get; set; }
		public Func<IDispatchCommunicationContext, Task<string?>>? NotifyUrlResolver { get; set; }
		public long? TemplateId { get; set; }
		public bool Track { get; set; }
		public bool? TrackClicks { get; set; }
		public bool? TrackOpens { get; set; }

		public IEmailExtendedChannelProperties Adapt(IEmailChannelConfiguration email)
		{
			return this;
		}
	}
}
