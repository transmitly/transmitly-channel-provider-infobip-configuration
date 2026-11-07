// Copyright (c) Code Impressions, LLC. All Rights Reserved.
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

using System;
using System.Threading.Tasks;
using Transmitly.Util;

namespace Transmitly.ChannelProvider.Infobip.Configuration.Voice
{
	internal sealed class VoiceExtendedChannelProperties(IExtendedProperties extendedProperties) : IVoiceExtendedChannelProperties
	{
		private readonly IExtendedProperties _extendedProperties = Guard.AgainstNull(extendedProperties);
		private const string ProviderKey = InfobipConstant.VoicePropertiesKey;

		public int? CallTimeout
		{
			get => _extendedProperties.GetValue<int?>(ProviderKey, nameof(CallTimeout));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(CallTimeout), value);
		}

		public MachineDetection MachineDetection
		{
			get => _extendedProperties.GetValue(ProviderKey, nameof(MachineDetection), MachineDetection.Enabled);
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(MachineDetection), value);
		}

		public int? MaxDtmf
		{
			get => _extendedProperties.GetValue<int?>(ProviderKey, nameof(MaxDtmf));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(MaxDtmf), value);
		}

		public string? NotifyUrl
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(NotifyUrl));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(NotifyUrl), value);
		}

		public Func<IDispatchCommunicationContext, Task<string?>>? NotifyUrlResolver
		{
			get => _extendedProperties.GetValue<Func<IDispatchCommunicationContext, Task<string?>>?>(ProviderKey, nameof(NotifyUrlResolver));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(NotifyUrlResolver), value);
		}

		public int? Pause
		{
			get => _extendedProperties.GetValue<int?>(ProviderKey, nameof(Pause));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(Pause), InRange(value, 0, 10, nameof(Pause)));
		}

		public bool? Record
		{
			get => _extendedProperties.GetValue<bool?>(ProviderKey, nameof(Record));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(Record), value);
		}

		public int? RingTimeout
		{
			get => _extendedProperties.GetValue<int?>(ProviderKey, nameof(RingTimeout));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(RingTimeout), InRange(value, 0, 45, nameof(RingTimeout)));
		}

		public VoiceGender VoiceGender
		{
			get => _extendedProperties.GetValue(ProviderKey, nameof(VoiceGender), VoiceGender.Unspecified);
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(VoiceGender), value);
		}

		public string? VoiceName
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(VoiceName));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(VoiceName), value);
		}

		private static int? InRange(int? value, int min, int max, string name) =>
			value < min || value > max ? throw new ArgumentOutOfRangeException(name, value, $"{name} must be between {min} and {max} seconds.") : value;
	}
}
