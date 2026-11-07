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
using Transmitly.Util;

namespace Transmitly.ChannelProvider.Infobip.Configuration.Sms
{
	internal sealed class SmsExtendedDeliveryReportProperties(IExtendedProperties extendedProperties) : ISmsExtendedDeliveryReportProperties
	{
		private readonly IExtendedProperties _extendedProperties = Guard.AgainstNull(extendedProperties);
		private const string ProviderKey = InfobipConstant.SmsPropertiesKey;

		public string? ApplicationId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(ApplicationId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(ApplicationId), value);
		}

		public string? BulkId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(BulkId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(BulkId), value);
		}

		public string? CallbackData
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(CallbackData));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(CallbackData), value);
		}

		public DateTimeOffset? DoneAt
		{
			get => _extendedProperties.GetValue<DateTimeOffset?>(ProviderKey, nameof(DoneAt));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(DoneAt), value);
		}

		public string? EntityId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(EntityId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(EntityId), value);
		}

		public IErrorStatus? Error
		{
			get => _extendedProperties.GetValue<IErrorStatus?>(ProviderKey, nameof(Error));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(Error), value);
		}

		public string? From
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(From));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(From), value);
		}

		public string? MccMnc
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(MccMnc));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(MccMnc), value);
		}

		public string? MessageId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(MessageId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(MessageId), value);
		}

		public ISmsPrice? Price
		{
			get => _extendedProperties.GetValue<ISmsPrice?>(ProviderKey, nameof(Price));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(Price), value);
		}

		public DateTimeOffset? SentAt
		{
			get => _extendedProperties.GetValue<DateTimeOffset?>(ProviderKey, nameof(SentAt));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(SentAt), value);
		}

		public int? SmsCount
		{
			get => _extendedProperties.GetValue<int?>(ProviderKey, nameof(SmsCount));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(SmsCount), value);
		}

		public ICallbackStatus? Status
		{
			get => _extendedProperties.GetValue<ICallbackStatus?>(ProviderKey, nameof(Status));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(Status), value);
		}

		public string? To
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(To));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(To), value);
		}
	}
}
