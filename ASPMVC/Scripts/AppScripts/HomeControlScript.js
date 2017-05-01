/// <reference path="HomeServiceScript.js" />
var myApp = angular.module('homeModule', [])
.constant("productListActiveClass", "btn-info")
.controller('homeController', function (detailService, filterService, pageService, $scope, productListActiveClass) {
    var selectedView = 1;
    var selectid, selectedPage = 1;

    $scope.selectedFilter = { state: null, make: null, isurance: null };

    $scope.init = function (data) {
        $scope.homeData = data;
        $scope.State = $scope.homeData.FilterSelect.State;
        $scope.Make = $scope.homeData.FilterSelect.Make;
        $scope.FormerInsurance = $scope.homeData.FilterSelect.FormerInsurance;
        $scope.ids = data.ID;

        $scope.pages = [];
        for (var i = 0; i < data.PageCount; i++)
            $scope.pages.push(i);
    }

    $scope.viewFile = function () {
        if (selectedView === 1)
            return "../../template/ConsumeDetails.html";
        else if (selectedView === 2)
            return "../../template/VehicleDetails.html";
        else if (selectedView === 3)
            return "../../template/CoverageDetails.html";
    };

    $scope.details = function (id, view) {
        selectedView = view;
        selectid = id;
        var type = view == 1 ? 'consumer' : (view == 2 ? 'vehicle' : 'coverage');
        detailService.async(id, type).then(function (d) {
            $scope.detail = d.data;
        });
    }

    $scope.selectPage = function (page) {
        pageService.async(page).then(function (d) {
            $scope.homeDate = d.data;
            $scope.ids = d.data.ID;
        });
        selectedPage = page;
        $scope.detail = null;
    }

    $scope.getPageClass = function (page) {
        return selectedPage == page ? productListActiveClass : "";
    }

    $scope.getCategoryClass = function (id, view) {
        return selectedView == view && selectid == id ? productListActiveClass : "";
    }

    $scope.selectChanged = function () {
        console.log($scope.selectedFilter);
        filterService.async($scope.selectedFilter).then(function (d) {
            $scope.homeDate = d.data;
            $scope.ids = d.data.ID;
            $scope.pages = [];
            for (var i = 0; i < d.data.PageCount; i++)
                $scope.pages.push(i);
        });
        selectedPage = 1;
        $scope.detail = null;
    }
});