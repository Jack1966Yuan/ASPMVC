var myApp = angular.module('homeModule');

myApp.factory('pageService', function ($http) {
    return {
        async: function (page) {
            return $http.get('../api/values?page=' + page);
        }
    };
});

myApp.factory('filterService', function ($http) {
    return {
        async: function (filter) {
            var url = '../api/values?state=' + (filter.state == null ? '' : filter.state) + '&make=' + (filter.make == null ? '' : filter.make) + '&insurer=' + (filter.isurance == null ? '' : filter.isurance);
            return $http.get(url);
        }
    };
});

myApp.factory('detailService', function ($http) {
    return {
        async: function (id, type) {
            var url = '../api/values?id=' + id + '&type=' + type;
            return $http.get(url);
        }
    };
})