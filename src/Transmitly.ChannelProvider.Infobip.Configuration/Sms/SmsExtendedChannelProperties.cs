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

namespace Transmitly.ChannelProvider.Infobip.Configuration.Sms
{
	internal sealed class SmsExtendedChannelProperties(IExtendedProperties extendedProperties) : ISmsExtendedChannelProperties
	{
		private readonly IExtendedProperties _extendedProperties = Guard.AgainstNull(extendedProperties);
		private const string ProviderKey = InfobipConstant.SmsPropertiesKey;

		public string? ApplicationId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(ApplicationId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(ApplicationId), MaxLength50(value, nameof(ApplicationId)));
		}

		public string? EntityId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(EntityId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(EntityId), MaxLength50(value, nameof(EntityId)));
		}

		private static string? MaxLength50(string? value, string name) =>
			!string.IsNullOrWhiteSpace(value) && value!.Length > 50 ? throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than 50 characters.") : value;

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

		public long? ValidityPeriod
		{
			get => _extendedProperties.GetValue<long?>(ProviderKey, nameof(ValidityPeriod));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(ValidityPeriod), value);
		}
	}
}
