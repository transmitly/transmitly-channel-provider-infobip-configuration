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

using Transmitly.Channel.Configuration.Voice;
using Transmitly.ChannelProvider.Infobip.Configuration.Voice;

namespace Transmitly.ChannelProvider.Infobip.ConfigurationTests
{
	class MockVoiceBag : IVoiceExtendedChannelProperties
	{
		private readonly IExtendedProperties _properties;

		public MockVoiceBag()
		{

		}
		public MockVoiceBag(IExtendedProperties keys)
		{
			_properties = keys;
		}
		public int? CallTimeout { get => _properties.GetValue<int?>(nameof(CallTimeout)); set => _properties.AddOrUpdate(nameof(CallTimeout), value); }
		public MachineDetection MachineDetection { get; set; }
		public int? MaxDtmf { get; set; }
		public string? NotifyUrl { get; set; }
		public Func<IDispatchCommunicationContext, Task<string?>>? NotifyUrlResolver { get; set; }
		public int? Pause { get; set; }
		public bool? Record { get; set; }
		public int? RingTimeout { get; set; }
		public VoiceGender VoiceGender { get; set; }
		public string? VoiceName { get; set; }

		public IVoiceExtendedChannelProperties Adapt(IVoiceChannelConfiguration voice)
		{
			return new MockVoiceBag(voice.ExtendedProperties);
		}
	}
}
