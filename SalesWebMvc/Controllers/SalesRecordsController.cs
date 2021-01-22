﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new DateTime(2018, 01, 01);
            }
            if (!max.HasValue)
            {
                max = DateTime.Now;
            }
            ViewData["min"] = min.Value.ToString("yy-M-dd");
            ViewData["max"] = min.Value.ToString("yy-M-dd");
            var result = await _salesRecordService.FindByDateAsync(min, max);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new DateTime(2018, 01, 01);
            }
            if (!max.HasValue)
            {
                max = DateTime.Now;
            }
            ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["max"] = min.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupinAsync(min, max);
            return View(result);
        }
    }
}
