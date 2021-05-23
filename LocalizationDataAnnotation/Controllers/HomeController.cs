using LocalizationDataAnnotation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationDataAnnotation.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Create()
		{
			SetDayOfWeeksViewData();
			return View();
		}

		[HttpPost]
		public IActionResult Create(UserViewModel model)
		{
			SetDayOfWeeksViewData();

			// エラーなら差し戻し
			if (ModelState.IsValid == false) return View(model);

			// 正常に登録できた場合は Index に戻る
			return RedirectToAction(nameof(Index));
		}

		/// <summary>曜日の一覧を ViewData に設定します。</summary>
		private void SetDayOfWeeksViewData()
			=> ViewData["DayOfWeeks"] = ((DayOfWeek[])Enum.GetValues(typeof(DayOfWeek))).Select(x => new SelectListItem(x.ToString(), ((int)x).ToString()));
	}
}
