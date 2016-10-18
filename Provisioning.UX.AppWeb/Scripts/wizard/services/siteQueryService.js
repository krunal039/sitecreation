(function () {
    'use strict';

    angular
        .module('app.wizard')
        .service('$SharePointJSOMService', function ($q, $http) {
            this.checkUrlREST = function ($scope, value) {
                var deferred = $.Deferred();

                var executor = new SP.RequestExecutor($scope.spAppWebUrl);
                executor.executeAsync({
                    url: $scope.spAppWebUrl + "/_api/SP.AppContextSite(@target)/web/url" + "?@target='" + $scope.siteConfiguration.spNewSitePrefix + value + "'",
                    method: "GET",
                    headers: { "Accept": "application/json; odata=verbose" },
                    success: function (data, textStatus, xhr) {
                        var dataP = JSON.parse(data.body);
                        if (dataP.d.Url === $scope.siteConfiguration.spNewSitePrefix + value) {
                            deferred.resolve(data);
                        }else if (!$scope.siteConfiguration.properties.isSiteCollection) {
                            executor.executeAsync({
                                url: $scope.spAppWebUrl +
                                    "/_api/SP.AppContextSite(@target)/web/GetFolderByServerRelativeUrl('" +
                                  ($scope.siteConfiguration.spNewSitePrefix + value).split("/").pop() +
                                    "')?@target='" +
                                    $scope.siteConfiguration.spNewSitePrefix +
                                    "'",
                                method: "GET",
                                headers: { "Accept": "application/json; odata=verbose" },
                                success: function(data1, textStatus1, xhr1) {
                                    var dataP = JSON.parse(data1.body);
                                    if (dataP.d.Exists) {
                                        deferred.resolve(data);
                                    } else {
                                        deferred.reject(JSON.stringify(data));
                                    }
                                },
                                error: function(xhr1, textStatus1, errorThrown1) {
                                    deferred.reject(JSON.stringify(xhr1));
                                }
                            });
                        }else{
                            deferred.reject(JSON.stringify(xhr));
                        }
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        deferred.reject(JSON.stringify(xhr));
                    }
                });
                return deferred;
            };
        });
})();

