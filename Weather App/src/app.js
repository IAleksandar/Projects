$(document).ready(function () {

    $("#header").text("Weather Alert");
    $("#greetingResult").text("The most accurate weather forecast!");

    let aboutInfo = {
        creator: "Aleksandar Ivanovski",
        rank: "First place",
        year: 2021
    };
    let weatherData;
    const tempParam = "temp";
    const humidityParam = "humidity";
    const ascParam = "asc";
    const descParam = "desc";

    let helperService = {
        timestampToDate: function(timeStampSeconds){
            return new Date(timeStampSeconds * 1000);
        },
        sortHourlyData: function(param, order){
            debugger
            if(param === tempParam){
                if(order === ascParam){
                    weatherData.list.sort((item1, item2)=> item1.main.temp - item2.main.temp);
                    uiService.loadHourlyData(weatherData);
                    uiService.toggleElement(false, $('#sortTempAsc'));
                    uiService.toggleElement(true, $('#sortTempDesc'));
                }
                else{
                    weatherData.list.sort((item1, item2)=> item2.main.temp - item1.main.temp);
                    uiService.loadHourlyData(weatherData);
                    uiService.toggleElement(true, $('#sortTempAsc'));
                    uiService.toggleElement(false, $('#sortTempDesc'));
                }
            }
            else{
                if(order === ascParam){
                    weatherData.list.sort((item1, item2)=> item1.main.humidity - item2.main.humidity);
                    uiService.loadHourlyData(weatherData);
                    uiService.toggleElement(false, $('#sortHumidityAsc'));
                    uiService.toggleElement(true, $('#sortHumidityDesc'));
                }
                else{
                    weatherData.list.sort((item1, item2)=> item2.main.humidity - item1.main.humidity);
                    uiService.loadHourlyData(weatherData);
                    uiService.toggleElement(true, $('#sortHumidityAsc'));
                    uiService.toggleElement(false, $('#sortHumidityDesc'));
                }
            }
        },
        registerSortListeners: function(){
            $('#sortTempAsc').click(function(){
                helperService.sortHourlyData(tempParam, ascParam);
               
            });
            $('#sortHumidityAsc').click(function(){
                helperService.sortHourlyData(humidityParam, ascParam);
            });
            $('#sortTempDesc').click(function(){
                helperService.sortHourlyData(tempParam, descParam);
            });
            $('#sortHumidityDesc').click(function(){
                helperService.sortHourlyData(humidityParam, descParam);
            });
        },
        aggregateStatistics: function (data) {

            let res = {
                tempSum: 0,
                humiditySum: 0,
                lowestTemp: data.list[0],
                highestTemp: data.list[0],
                lowestHumidity: data.list[0],
                highestHumidity: data.list[0],
            }
            data.list.reduce(function(result, item){
                result.tempSum += item.main.temp;
                result.humiditySum += item.main.humidity;
                if (result.highestTemp.main.temp_max < item.main.temp_max) {
                    result.highestTemp = item;
                }
                if (result.lowestTemp.main.temp_min > item.main.temp_min) {
                    result.lowestTemp = item;
                }
                if (result.highestHumidity.main.humidity < item.main.humidity) {
                    result.highestHumidity = item;
                }
                if (result.lowestHumidity.main.humidity > item.main.humidity) {
                    result.lowestHumidity = item;
                }
                return result;
            }, res);
            return {
                temperature: {
                    highest: res.highestTemp.main.temp_max,
                    lowest: res.lowestTemp.main.temp_min,
                    average: res.tempSum / data.list.length
                },
                humidity: {
                    highest: res.highestHumidity.main.humidity,
                    lowest: res.lowestHumidity.main.humidity,
                    average: res.humiditySum / data.list.length
                },
                coldestTime: helperService.timestampToDate(res.lowestTemp.dt),
                warmestTime: helperService.timestampToDate(res.highestTemp.dt)
            }
        }
    };

   
    let uiService = {
        toggleElement: function(toggleCondition, element){
            if(toggleCondition){
                element.css("display", "block");
            }
            else{
                element.css("display", "none");
            }
        },
        showStatistics: function (statisticsData) {
            $("#statisticsResult").html(`
           <div class="container">
           <div class="row">
           <h2 class="col-sm-6">AVG TEMP: ${statisticsData.temperature.average}</h2>
           <h2 class="col-sm-6">AVG HUM: ${statisticsData.humidity.average}</h2>
           </div>
           <div class="row">
           <h2 class="col-sm-6">MAX TEMP: ${statisticsData.temperature.highest}</h2>
           <h2 class="col-sm-6">MAX HUM: ${statisticsData.humidity.highest}</h2>
           </div>
           <div class="row">
           <h2 class="col-sm-6">MIN TEMP: ${statisticsData.temperature.lowest}</h2>
           <h2 class="col-sm-6">MIN HUM: ${statisticsData.humidity.lowest}</h2>
           </div>
           <div class="row">
           <h2 class="col-sm-6">WARMEST TIME: ${statisticsData.warmestTime}</h2>
           <h2 class="col-sm-6">COLDEST TIME: ${statisticsData.coldestTime}</h2>
           </div>
           </div>`)
        },
        loadHourlyData: function (data) {
            $("#hourlyTableResult").html("");
            $('#hourlyTableResult').append(`
            <div class="row">
            <div class="col-md-2">Icon</div>
            <div class="col-md-2">Description</div>
            <div class="col-md-2">Date</div>
            <div class="col-md-2"><button id="sortTempAsc">ASC</button> <button id="sortTempDesc">DESC</button>Temp</div>
            <div class="col-md-2"><button id="sortHumidityAsc">ASC</button><button id="sortHumidityDesc">DESC</button>Hum</div>
            <div class="col-md-2">Wind speed km/h</div>
        </div>
            `);
            data.list.forEach(item => {
                $('#hourlyTableResult').append(`
                <div class="row">
                <div class="col-md-2"><img src="http://openweathermap.org/img/w/${item.weather[0].icon}.png"/></div>
                <div class="col-md-2">${item.weather[0].description}</div>
                <div class="col-md-2">${helperService.timestampToDate(item.dt).toDateString()}</div>
                <div class="col-md-2">${item.main.temp} C</div>
                <div class="col-md-2">${item.main.humidity}</div>
                <div class="col-md-2">${item.wind.speed}</div>
            </div>
                `);
            });
            helperService.registerSortListeners();
        },
        showAboutInfo: function () {
            $("#aboutResult").html(`
            <h2>This application was created by <b>${aboutInfo.creator}</b>.
            It is ranked on <b>${aboutInfo.rank}</b>. It was started in ${aboutInfo.year}.</h2>`)
        }
    };

    let weatherService = {
        apiKey: "f369d0b7d1652d9e091fe8121aa44ede",
        apiBaseUrl: "https://api.openweathermap.org/data/2.5/forecast",
        getData: function (city) {
            uiService.toggleElement(true, $("#loader"));
            $.ajax({
                url: `${this.apiBaseUrl}?q=${city}&units=metric&APPID=${this.apiKey}`,
                success: function (response) {
                    weatherData = response;
                    uiService.toggleElement(false, $("#loader"));
                    console.log("The request succeeded!");
                    console.log(response);

                    let aggregatedData = helperService.aggregateStatistics(response);
                    console.log(aggregatedData);

                    uiService.showStatistics(aggregatedData);
                    uiService.loadHourlyData(response);
                },
                error: function (errorResponse) {
                    uiService.toggleElement(false, $("#loader"));
                    console.log("The request failed!");
                    console.log(errorResponse);
                }
            })
        }
    };

    let navigationService = {
        navItems: $(".nav-item"),
        navSearchInput: $("#citySearchInput"),
        navSearchBtn: $("#citySearchBtn"),
        pages: $("#pages").children(),
        activateNavItem: function (item) {

            for (let navItem of this.navItems) {
                $(navItem).removeClass("active");
            }
            item.addClass("active");
        },
        showPage: function (pageIndex) {

            for (let page of this.pages) {
                $(page).css("display", "none");
            }
            $(this.pages[pageIndex]).css("display", "block");
        },
        registerEventListeners: function () {
            for (let i = 0; i < this.navItems.length; i++) {
                $(this.navItems[i]).click(function () {

                    navigationService.activateNavItem($(this)); 
                    navigationService.showPage(i);
                });
            }
            this.navSearchBtn.click(function () {
                if (!navigationService.navSearchInput.val()) {
                    alert('You must enter a city');
                    return;
                }

                weatherService.getData(navigationService.navSearchInput.val());

            });
        }
    };


    weatherService.getData("skopje");

    uiService.showAboutInfo();

    navigationService.registerEventListeners();
});