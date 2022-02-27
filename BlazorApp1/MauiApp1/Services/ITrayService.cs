using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
	public interface ITrayService
	{
		void Initialize();

		Action ClickHandler { get; set; }
	}
}
