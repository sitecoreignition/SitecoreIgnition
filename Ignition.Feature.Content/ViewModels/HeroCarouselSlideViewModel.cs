using System;
using Glass.Mapper.Sc.Fields;
using Ignition.Feature.Content.DTOs;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Mvc;
using Sitecore.Data;
using Sitecore.Globalization;

namespace Ignition.Feature.Content.ViewModels
{
	public class HeroCarouselSlideViewModel : IgnitionViewModel, ICarouselSlide
	{
		protected ICarouselSlide Item { get; set; }

		public HeroCarouselSlideViewModel(ICarouselSlide item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			Item = item;
		}
		#region Decorator Overloads
		//public int CompareTo(IModelBase other)
		//{
		//	return Item.CompareTo(other);
		//}

		public bool Equals(IModelBase other)
		{
			return Item.Equals(other);
		}

		public Guid Id
		{
			get { return Item.Id; }
			set { Item.Id = value; }
		}

		public Language Language
		{
			get { return Item.Language; }
			set { Item.Language = value; }
		}

		public string DisplayName
		{
			get { return Item.DisplayName; }
			set { Item.DisplayName = value; }
		}

		public int Version
		{
			get { return Item.Version; }
			set { Item.Version = value; }
		}

		public string Path
		{
			get { return Item.Path; }
			set { Item.Path = value; }
		}

		public string Name
		{
			get { return Item.Name; }
			set { Item.Name = value; }
		}

		public string Url
		{
			get { return Item.Url; }
			set { Item.Url = value; }
		}

		public string Heading
		{
			get { return Item.Heading; }
			set { Item.Heading = value; }
		}

		public string Copy1
		{
			get { return Item.Copy1; }
			set { Item.Copy1 = value; }
		}

		public Image BackgroundImage
		{
			get { return Item.BackgroundImage; }
			set { Item.BackgroundImage = value; }
		}
		#endregion
	}
}