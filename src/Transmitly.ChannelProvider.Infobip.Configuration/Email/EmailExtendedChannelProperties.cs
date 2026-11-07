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
using Transmitly.Template.Configuration;
using Transmitly.Util;

namespace Transmitly.ChannelProvider.Infobip.Configuration.Email
{
	internal sealed class EmailExtendedChannelProperties(IExtendedProperties extendedProperties) : IEmailExtendedChannelProperties
	{
		private readonly IExtendedProperties _extendedProperties = Guard.AgainstNull(extendedProperties);
		private const string ProviderKey = InfobipConstant.EmailPropertiesKey;

		// Created once and kept, so templates added through one accessor are still there at dispatch.
		public IContentTemplateConfiguration AmpHtml
		{
			get
			{
				var ampHtml = _extendedProperties.GetValue<IContentTemplateConfiguration?>(ProviderKey, nameof(AmpHtml));
				if (ampHtml == null)
				{
					ampHtml = new ContentTemplateConfiguration();
					AmpHtml = ampHtml;
				}
				return ampHtml;
			}
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(AmpHtml), value);
		}

		public string? ApplicationId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(ApplicationId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(ApplicationId), value);
		}

		public string? EntityId
		{
			get => _extendedProperties.GetValue<string?>(ProviderKey, nameof(EntityId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(EntityId), value);
		}

		public bool? IntermediateReport
		{
			get => _extendedProperties.GetValue<bool?>(ProviderKey, nameof(IntermediateReport));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(IntermediateReport), value);
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

		public long? TemplateId
		{
			get => _extendedProperties.GetValue<long?>(ProviderKey, nameof(TemplateId));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(TemplateId), value);
		}

		public bool Track
		{
			get => _extendedProperties.GetValue(ProviderKey, nameof(Track), true);
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(Track), value);
		}

		public bool? TrackClicks
		{
			get => _extendedProperties.GetValue<bool?>(ProviderKey, nameof(TrackClicks));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(TrackClicks), value);
		}

		public bool? TrackOpens
		{
			get => _extendedProperties.GetValue<bool?>(ProviderKey, nameof(TrackOpens));
			set => _extendedProperties.AddOrUpdate(ProviderKey, nameof(TrackOpens), value);
		}
	}
}
