﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.JsonObjects
{
    public class WeatherResponse
    {
        public WeatherResponse(string currentConditions, string currentTemp, string minTemp, string maxTemp, string errors = "") 
        {
            this.currentConditions = currentConditions;
            this.currentTemp = currentTemp;
            this.maxTemp = maxTemp;
            this.minTemp = minTemp;
            this.errors = errors;
        }

        public string currentConditions;
        public string currentTemp;
        public string maxTemp;
        public string minTemp;
        public string errors;
    }
}