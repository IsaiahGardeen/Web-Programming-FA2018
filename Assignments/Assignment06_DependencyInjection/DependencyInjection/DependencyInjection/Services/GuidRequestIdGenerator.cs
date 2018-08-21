using System;

namespace DependencyInjection.Services
{
	/*
	* A class that generates unique request ids.
	*/
	public class GuidRequestIdGenerator
    {
		public string Generate { get { return Guid.NewGuid().ToString(); } }
    }
}
